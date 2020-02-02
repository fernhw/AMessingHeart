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

    void Start () {
        start = transform.localPosition;
        targetItem = transform.localPosition;
        objs = ( ObjectManager )FindObjectOfType(typeof(ObjectManager));
        speechControl = new SpeechControl();
        progress = new Progress();
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
        ChangeState(TypeSequence.ON_ITEM);
        DisableUIOnAnim(.8f);
        DisableUIWhileAnimation(ANIMATION_PAUSE_TO_ITEM);
        focusedItem = obj.objectIdentifier;
        break;

        case TypeOfTarget.UI:
        HandleButton(objectN);
        break;

        default:
        break;
        }
    }

    void HandleButton (string key) {
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
    }

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
        }
        ChangeState(TypeSequence.DIALOG);
    }

    void BackButton () {
        switch (currentState) {
        case TypeSequence.ON_ITEM:
        //
        ChangeState(TypeSequence.ITEM_SEARCH);
        DisableUIOnAnim(.8f);

        break;

        case TypeSequence.INVENTORY:
        // it remembers screen pre inventory
        ChangeState(screenPreInventory);
        //DisableUIWhileAnimation(ANIMATION_PAUSE_TO_VIEW);

        break;

        case TypeSequence.DIALOG:
        // it remembers screen pre inventory
        ChangeState(screenPreInventory);
        //DisableUIWhileAnimation(ANIMATION_PAUSE_TO_VIEW);

        break;

        default:
        break;
        }
    }

    void InventoryButton () {
        ChangeState(TypeSequence.INVENTORY);
    }

    IEnumerator disableUIStateMachine;
    void ChangeState (TypeSequence state) {
        switch (state) {
        case TypeSequence.ITEM_SEARCH:
        objs.ItemSearch();
        break;

        case TypeSequence.ON_ITEM:
        screenPreItemFocus = currentState;
        objs.OnItem();
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
