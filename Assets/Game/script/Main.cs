using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main:MonoBehaviour {
    public TypeSequence whatWeDo = TypeSequence.ITEM_SEARCH;

    ObjectManager objs;
    Vector3 start;
    Vector3 targetItem;

    bool interactionLock = false;
    bool disableUI = false;

    void Start () {
        start = transform.localPosition;
        targetItem = transform.localPosition;
        objs = ( ObjectManager )FindObjectOfType(typeof(ObjectManager));

    }

    // Update is called once per frame
    void Update () {
        float delta = Time.deltaTime;

        switch (whatWeDo) {
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

    const float LIMIT_CAM_TWEEN = 0.4f;
    const float CAM_CLOSENESS = -183;
    const float CAM_SPEED = 10;

    const float CAM_LIMIT_X = 230;

    const float ANIMATION_PAUSE_TO_ITEM = 1;
    const float ANIMATION_PAUSE_TO_VIEW = .7f;

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
        print(objectN);
        switch (type) {
        case TypeOfTarget.FIXER:
        targetItem = obj.transform.localPosition + Vector3.forward * CAM_CLOSENESS;
        ChangeState(TypeSequence.ON_ITEM);
        DisableUIWhileAnimation(ANIMATION_PAUSE_TO_ITEM);
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
        default:

        break;
        }
    }

    void BackButton () {
        switch (whatWeDo) {
        case TypeSequence.ON_ITEM:
        //
        ChangeState(TypeSequence.ITEM_SEARCH);
        DisableUIWhileAnimation(ANIMATION_PAUSE_TO_VIEW);
        
        break;

        default:
        break;
        }
    }

    void ChangeState (TypeSequence state) {
        whatWeDo = state;
        switch (state) {
        case TypeSequence.ITEM_SEARCH:

        objs.ItemSearch();
        break;
        case TypeSequence.ON_ITEM:
        objs.OnItem();
        break;

        default:
        break;
        }
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
    EXPLANATION,
    INVENTORY ///??
}
