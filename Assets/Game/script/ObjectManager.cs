using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ObjectManager : MonoBehaviour
{
    public GameObject uiScreenClick;
    public GameObject wholeScreen; //ui clicker

    public GameObject inventoryScreen;


    public PostProcessingBehaviour post;

    public GameObject backButton;
    public GameObject inventoryButton;
    public GameObject inventoryButton2;

    public GameObject speech;
    public TextMeshProUGUI dialogText;
    public Merry merry;

    public bool wholeScreenWasEnabled = false;
    public bool cameraIsOnTheItem = false;

    TypeSequence prevType;

    private void Start () {
        //SetupStage
        ItemSearch();
        depthOff();
    }


    public void ItemSearch () {
        prevType = TypeSequence.ITEM_SEARCH;
        cameraIsOnTheItem = false;
        DisableScreens();
        inventoryButton.SetActive(true);
        backButton.SetActive(false);
    }

    public void OnItem () {
        prevType = TypeSequence.ON_ITEM;
        cameraIsOnTheItem = true;
        DisableScreens();
        inventoryButton2.SetActive(true);
    }

    public void OnDialog (SpeechControl speechController, Progress progress) {
        DisableScreens();
        uiScreenClick.SetActive(true);
        wholeScreen.SetActive(true);
        speech.SetActive(true);
        HandleSpeechEvent(speechController.Current().speech, progress);
    }

    public TypeSequence NextSpeechAndNewTypeSequence (SpeechControl speechController, Progress progress) {
        DisableScreens();
        SpeechPackage speechPack = speechController.Continue();
        Speech speechHeld = speechPack.speech;
        if (!speechPack.isValidSPeech) {
            if(prevType == TypeSequence.ON_ITEM) {
                OnItem();
                return TypeSequence.ON_ITEM;
            } else {
                //TypeSequence.ITEM_SEARCH
                ItemSearch();
                return TypeSequence.ITEM_SEARCH;
            }
        }
        uiScreenClick.SetActive(true);
        wholeScreen.SetActive(true);
        speech.SetActive(true);
        HandleSpeechEvent(speechHeld, progress);
        return TypeSequence.DIALOG;
    }

    public void HandleSpeechEvent (Speech speech, Progress progress) {
        dialogText.text = speech.dialog;
        switch (speech.type) {
        case EventType.DIALOG:
        case EventType.DIMMED_DIALOG:
        merry.gameObject.SetActive(true);
        merry.SetMerry(speech.emotion, progress.GetHeartStatus());
        break;
        default:
        merry.gameObject.SetActive(false);
        break;
        }
    }

    public void OnInventory () {
        DisableScreens();
        backButton.SetActive(true);
        inventoryScreen.SetActive(true);
        depthOn();
    }

    void DisableScreens () {
        depthOff();
        merry.gameObject.SetActive(false);
        speech.SetActive(false);
        inventoryButton2.SetActive(false);
        inventoryButton.SetActive(false);
        inventoryScreen.SetActive(false);
        backButton.SetActive(false);
        uiScreenClick.SetActive(false);
    }

    public void DisableUI () {
        uiScreenClick.SetActive(false);
        wholeScreen.SetActive(false);
    }

    public void EnableUI () {
        wholeScreen.SetActive(true);
        if (wholeScreenWasEnabled) {
            uiScreenClick.SetActive(true);
        }
    }


    void depthOn () {
        post.profile.depthOfField.enabled = true;
    }
    void depthOff () {
        post.profile.depthOfField.enabled = false;
    }

    
}
