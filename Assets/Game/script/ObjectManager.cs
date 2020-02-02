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
    public GameObject merry;

    public bool wholeScreenWasEnabled = false;
    public bool cameraIsOnTheItem = false;

    private void Start () {
        //SetupStage
        ItemSearch();
        depthOff();
    }


    public void ItemSearch () {
        cameraIsOnTheItem = false;
        DisableScreens();
        inventoryButton.SetActive(true);
        backButton.SetActive(false);
    }

    public void OnItem () {
        cameraIsOnTheItem = true;
        DisableScreens();
        inventoryButton2.SetActive(true);
    }

    public void OnDialog (SpeechControl speechController) {
        DisableScreens();
        wholeScreen.SetActive(true);
        speech.SetActive(true);
        HandleSpeechEvent(speechController.Current().speech);
    }

    public void HandleSpeechEvent (Speech speech) {
        dialogText.text = speech.dialog;
        switch (speech.type) {
        case EventType.DIALOG:
        case EventType.DIMMED_DIALOG:
        merry.SetActive(true);
        break;
        default:
        merry.SetActive(false);
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
        merry.SetActive(false);
        speech.SetActive(false);
        inventoryButton2.SetActive(false);
        inventoryButton.SetActive(false);
        inventoryScreen.SetActive(false);
        backButton.SetActive(false);
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
