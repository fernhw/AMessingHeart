using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main:MonoBehaviour {


    const float LIMIT_CAM_TWEEN = 0.4f;
    const float CAM_CLOSENESS = -183;
    const float CAM_SPEED = 5;

    const float CAM_LIMIT_X = 230;

    const float ANIMATION_PAUSE_TO_ITEM = 1;
    const float ANIMATION_PAUSE_TO_VIEW = .7f;





    public TypeSequence currentState = TypeSequence.ITEM_SEARCH;
    TypeSequence screenPreInventory = TypeSequence.ITEM_SEARCH;
    TypeSequence screenPreItemFocus = TypeSequence.ITEM_SEARCH;

    string focusedItem;

    ObjectManager objs;
    Vector3 start;
    Vector3 targetItem;
    SpeechControl speechControl;
    Progress progress;
    bool interactionLock = false;
    bool disableUI = false;
    bool inventoryButtonInOnItemView = true;

    void Start () {
        start = transform.localPosition;
        targetItem = transform.localPosition;
        objs = ( ObjectManager )FindObjectOfType(typeof(ObjectManager));
        speechControl = new SpeechControl();
        progress = new Progress();

        progress.SetItem("winder", objs.winderStage, objs.winderInventory);
        progress.SetItem("button", objs.buttonStage, objs.buttonInventory);
        progress.SetItem("thread", objs.threadStage, objs.threadInventory);
        progress.SetItem("photo_1", objs.photo1Stage, objs.photo1Inventory);
        progress.SetItem("photo_2", objs.photo2Stage, objs.photo2Inventory);
        progress.SetItem("ballerina", objs.ballerinaStage, objs.ballerinaInventory);

    }

    // Update is called once per frame
    void Update () {
        float delta = Time.deltaTime;

        switch (currentState) {
        case TypeSequence.ITEM_SEARCH:
        LerpToCamera(start, delta);
        break;
        case TypeSequence.ON_ITEM:
        LerpToCamera(targetItem, delta);
        break;

        default:
        break;
        }

    }


    void LerpToCamera (Vector3 cameraTarget, float delta) {

        float deltaTween = delta * CAM_SPEED;
        if (deltaTween > LIMIT_CAM_TWEEN) {
            deltaTween = LIMIT_CAM_TWEEN;
        }

        float camX = this.transform.localPosition.x;
        float camY = this.transform.localPosition.y;
        float camZ = this.transform.localPosition.z;

        float targetCamX = cameraTarget.x;
        float targetCamY = cameraTarget.y;
        float targetCamZ = cameraTarget.z;

        targetCamX += Random.value * .2f - .1f;
        targetCamY += Random.value * .2f - .1f;


        if (targetCamX > CAM_LIMIT_X) {
            targetCamX = CAM_LIMIT_X;
        }

        if (targetCamX < -CAM_LIMIT_X) {
            targetCamX = -CAM_LIMIT_X;
        }

        float camTargX = camX + ( targetCamX - camX ) * deltaTween;
        float camTargY = camY + ( targetCamY - camY ) * deltaTween;
        float camTargZ = camZ + ( targetCamZ - camZ ) * deltaTween;

        this.transform.localPosition = new Vector3(camTargX, camTargY, camTargZ);

    }

    public void ClickedData (string objectN, TypeOfTarget type, ClickedHack obj) {

        if (disableUI)
            return;

        print(objectN);
        switch (type) {

        case TypeOfTarget.FIXER:
        if (currentState != TypeSequence.ITEM_SEARCH)
            break;
        targetItem = obj.transform.localPosition + Vector3.forward * CAM_CLOSENESS;
        ChangeState(TypeSequence.ON_ITEM, true);
        DisableUIOnAnim(.8f);
        DisableUIWhileAnimation(ANIMATION_PAUSE_TO_ITEM);
        focusedItem = obj.objectIdentifier;
        break;

        case TypeOfTarget.ITEM:
        case TypeOfTarget.UI:
        HandleButton(objectN, obj);
        break;
        case TypeOfTarget.UI_INVENTORY:
        if (inventoryLayer == 0) {
            HandleInvButton(objectN, obj);
        } else {
            HandleInv2Button(objectN, obj);
        }
        break;
        default:
        break;
        }
    }

    int inventoryLayer = 0;
    string prevKey = "";
    void HandleInvButton (string key, ClickedHack obj) {
        inventoryLayer = 0;
        prevKey = key;
        switch (focusedItem) {


        case "oso":
        switch (key) {
        case "button":
        speechControl.Start(Events.bearButton);
        inventoryLayer = 1;
        break;
        case "stringstring":
        speechControl.Start(Events.bearButtonThread);
        inventoryLayer = 1;
        break;
        default:
        speechControl.Start(Events.bearButtonPhotos);
        break;
        }
        break;


        case "caja_musica":
        switch (key) {
        case "winder":
        speechControl.Start(Events.boxButtonWinder);
        inventoryLayer = 1;
        break;
        case "ballerina":
        speechControl.Start(Events.boxButtonBall);
        inventoryLayer = 1;
        break;
        }
        break;


        case "retrato":
        switch (key) {
        case "photo1":
        speechControl.Start(Events.pictureButtonP2);
        inventoryLayer = 1;
        break;
        case "photo2":
        speechControl.Start(Events.pictureButtonP1);
        inventoryLayer = 1;
        break;
        }


        break;
        default:
        //speechControl.Start(Events.what);
        //FLAVOR TEXTS

        speechControl.Start(Events.time);
        switch (key) {
        case "button":
        inventoryLayer = 1;
        break;
        }
        break;

        }

        ChangeState(TypeSequence.DIALOG, inventoryButtonInOnItemView);
    }

    void HandleInv2Button (string key, ClickedHack obj) {

        if (focusedItem == "oso") {
            if (prevKey == "button" && key == "stringstring") {
                speechControl.Start(Events.fixBear);
            }
        }
        if (focusedItem == "caja_musica") {
            if (prevKey == "ballerina" && key == "winder") {
                speechControl.Start(Events.fixBox);
            } else if (prevKey == "winder" && key == "ballerina") {
                speechControl.Start(Events.fixBox);
            }
        }
        if (focusedItem == "retrato") {
            if (prevKey == "photo1" && key == "photo2") {
                speechControl.Start(Events.pictureButtonFinale);
            } else if (prevKey == "photo2" && key == "photo1") {
                speechControl.Start(Events.pictureButtonFinale);
            }
        }
        ChangeState(TypeSequence.DIALOG, inventoryButtonInOnItemView);
    }

    void HandleButton (string key, ClickedHack obj) {
        switch (key) {
        case "back_button":
        BackButton();
        break;

        case "inventory_button":
        InventoryButton();
        break;

        case "look_button":
        StartDialog();
        break;

        case "screen":
        Continue();
        break;


        default:
        break;
        }

        if (obj.objectIdentifier == "item") {
            targetItem = obj.transform.localPosition + Vector3.forward * CAM_CLOSENESS;
            DisableUIOnAnim(.8f);
            DisableUIWhileAnimation(ANIMATION_PAUSE_TO_ITEM);
            focusedItem = obj.idString;
            extra = obj.objectIdentifier;
            ChangeState(TypeSequence.ON_ITEM, false);
        }
    }
    string extra = "";
    void Continue () {
        switch (currentState) {
        case TypeSequence.DIALOG:
        // it remembers screen pre inventory
        currentState = objs.NextSpeechAndNewTypeSequence(speechControl, progress);

        //DisableUIWhileAnimation(ANIMATION_PAUSE_TO_VIEW);

        break;

        default:
        break;
        }
    }

    void StartDialog () {
        switch (focusedItem) {
        case "retrato":
        speechControl.Start(Events.frameCutscene);
        break;

        case "oso":
        speechControl.Start(Events.bearCutscene);
        break;

        case "caja_musica":
        speechControl.Start(Events.dollCutscene);
        break;
        case "stringstring":
        speechControl.Start(Events.stringStringFlavor);
        break;
        case "button":
        speechControl.Start(Events.ButtonFlavor);
        break;
        case "ballerina":
        speechControl.Start(Events.ballerinaFlavor);
        break;
        case "photo_1":
        speechControl.Start(Events.Photo1Flavor);
        break;
        case "photo_2":
        speechControl.Start(Events.Photo2Flavor);
        break;
        case "winder":
        speechControl.Start(Events.winderFlavor);
        break;
        }
        ChangeState(TypeSequence.DIALOG, inventoryButtonInOnItemView);
    }

    void BackButton () {
        switch (currentState) {
        case TypeSequence.ON_ITEM:
        //
        ChangeState(TypeSequence.ITEM_SEARCH, inventoryButtonInOnItemView);
        DisableUIOnAnim(.8f);

        break;

        case TypeSequence.INVENTORY:
        // it remembers screen pre inventory
        ChangeState(screenPreInventory, inventoryButtonInOnItemView);
        //DisableUIWhileAnimation(ANIMATION_PAUSE_TO_VIEW);

        break;

        case TypeSequence.DIALOG:
        // it remembers screen pre inventory
        ChangeState(screenPreInventory, inventoryButtonInOnItemView);
        //DisableUIWhileAnimation(ANIMATION_PAUSE_TO_VIEW);

        break;

        default:
        break;
        }
    }

    void InventoryButton () {
        inventoryLayer = 0;
        switch (currentState) {
        case TypeSequence.ITEM_SEARCH:
        ChangeState(TypeSequence.INVENTORY, inventoryButtonInOnItemView);
        break;

        case TypeSequence.ON_ITEM:
        switch (focusedItem) {
        case "retrato":
        speechControl.Start(Events.frameCutsceneInv);
        break;

        case "oso":
        speechControl.Start(Events.bearCutsceneInv);
        break;

        case "caja_musica":
        speechControl.Start(Events.dollCutsceneInv);
        break;
        }
        screenPreInventory = TypeSequence.ON_ITEM;
        screenPreItemFocus = TypeSequence.ON_ITEM;

        ChangeState(TypeSequence.DIALOG, true);

        break;
        }
    }

    IEnumerator disableUIStateMachine;
    void ChangeState (TypeSequence state, bool inventoryButtonInOnItemView) {
       
        this.inventoryButtonInOnItemView = inventoryButtonInOnItemView;

        switch (state) {
        case TypeSequence.ITEM_SEARCH:
        objs.ItemSearch();
        break;

        case TypeSequence.ON_ITEM:
        screenPreItemFocus = currentState;
        objs.OnItem(inventoryButtonInOnItemView);
        break;

        case TypeSequence.INVENTORY:
        screenPreInventory = currentState;
        objs.OnInventory();
        break;

        case TypeSequence.DIALOG:
        objs.OnDialog(speechControl, progress);
        break;

        default:
        break;
        }
        currentState = state;
    }

    void DisableUIOnAnim (float time) {
        disableUIStateMachine = DisableUIWhileAnimation(time);
        StartCoroutine(disableUIStateMachine);
    }

    IEnumerator DisableUIWhileAnimation (float waitTime) {
        disableUI = true;
        objs.DisableUI();
        yield return new WaitForSeconds(waitTime);
        disableUI = false;
        objs.EnableUI();
    }
}

public enum TypeSequence {
    ITEM_SEARCH,
    ON_ITEM,
    EXPLANATION, // BLACK
    DIALOG,
    INVENTORY ///??
}
