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
    public GameObject inventoryOptionOnItemView;

    public GameObject speech;
    public TextMeshProUGUI dialogText;

    public GameObject fullblackScreen;
    public GameObject actionBlackOverlay;
    public TextMeshProUGUI actionText;
    public Merry merry;

    public bool wholeScreenWasEnabled = false;
    public bool cameraIsOnTheItem = false;

    TypeSequence prevType;

    float currentCharacterInScrollf = 0;
    int currentCharacterInScroll = 0;
    int totalCharactersInText = 0;

    public GameObject buttonStage;
    public GameObject buttonInventory;
    public GameObject threadStage;
    public GameObject threadInventory;
    public GameObject photo1Stage;
    public GameObject photo1Inventory;
    public GameObject photo2Stage;
    public GameObject photo2Inventory;
    public GameObject winderStage;
    public GameObject winderInventory;
    public GameObject ballerinaStage;
    public GameObject ballerinaInventory;



    private void Start () {
        //SetupStage
        ItemSearch();
        depthOff();
    }



    private void Update () {
        currentCharacterInScrollf += 0.5f;
        currentCharacterInScroll = (int) currentCharacterInScrollf;

        actionText.maxVisibleCharacters = currentCharacterInScroll;
        dialogText.maxVisibleCharacters = currentCharacterInScroll;
    }

    public void ItemSearch () {
        prevType = TypeSequence.ITEM_SEARCH;
        cameraIsOnTheItem = false;
        DisableScreens();
        inventoryButton.SetActive(true);
        backButton.SetActive(false);
    }
    bool showInventoryButton;
    public void OnItem (bool showInventoryButton) {
        this.showInventoryButton = showInventoryButton;
        prevType = TypeSequence.ON_ITEM;
        cameraIsOnTheItem = true;
        DisableScreens();
        inventoryButton2.SetActive(true);
        if (showInventoryButton) {
            inventoryOptionOnItemView.SetActive(true);
        }
    }

    public void OnDialog (SpeechControl speechController, Progress progress) {
        DisableScreens();      
        HandleSpeechEvent(speechController.Current().speech, progress);
    }

    public TypeSequence NextSpeechAndNewTypeSequence (SpeechControl speechController, Progress progress) {
        if(currentCharacterInScroll < totalCharactersInText + 15) {
            if (currentCharacterInScroll < totalCharactersInText) {
                currentCharacterInScrollf = ( float )totalCharactersInText;
                currentCharacterInScroll = totalCharactersInText;
                actionText.maxVisibleCharacters = totalCharactersInText;
                dialogText.maxVisibleCharacters = totalCharactersInText;
                
            }
            return TypeSequence.DIALOG;
        }
        DisableScreens();
        SpeechPackage speechPack = speechController.Continue();
        Speech speechHeld = speechPack.speech;

        if (speechHeld.type == EventType.FIX) {
            //  ItemSearch();
            if (speechHeld.dialog == "bear" && progress.Bear == false) {
                progress.Bear = true;
                buttonInventory.SetActive(false);
                threadInventory.SetActive(false);
                progress.heartHeal++;

            } else if (speechHeld.dialog == "frame") {
                progress.Frame = true;
                photo1Inventory.SetActive(false);
                photo2Inventory.SetActive(false);
                progress.heartHeal++;
            } else if (speechHeld.dialog == "bear") {
                progress.Frame = true;
                ballerinaInventory.SetActive(false);
                winderInventory.SetActive(false);
                progress.heartHeal++;
            }

            merry.heart1.SetActive(false);
            merry.heart2.SetActive(false);
            merry.heart3.SetActive(false);
            merry.heart4.SetActive(false);
            switch (progress.GetHeartStatus()) {
            case HeartStatus.ONE:
            merry.heart1.SetActive(true);
            break;
            case HeartStatus.TWO:

            merry.heart2.SetActive(true);
            break;
            case HeartStatus.THREE:

            merry.heart3.SetActive(true);
            break;
            case HeartStatus.FOUR:

            merry.heart4.SetActive(true);
            break;
            }
            speechPack = speechController.Continue();
            speechHeld = speechPack.speech;
            //prevType = TypeSequence.ON_ITEM;
            //  return TypeSequence.ITEM_SEARCH;
        }



        if (!speechPack.isValidSPeech) {
            if(prevType == TypeSequence.ON_ITEM) {
                OnItem(showInventoryButton);
                return TypeSequence.ON_ITEM;
            } else {
                //TypeSequence.ITEM_SEARCH
                ItemSearch();
                return TypeSequence.ITEM_SEARCH;
            }
        }
        if(speechHeld.type == EventType.OPEN_INVENTORY) {
            OnInventory();
            prevType = TypeSequence.ON_ITEM;
            return TypeSequence.INVENTORY;
        }

        if (speechHeld.type == EventType.OPEN_INVENTORY_2ND_STAGE) {
            OnInventory();
            prevType = TypeSequence.ON_ITEM;
            return TypeSequence.INVENTORY;
        }

        if (speechHeld.type == EventType.AQUIRE_ITEM) {
            ItemSearch();
            progress.GetItem(speechHeld.dialog);
            prevType = TypeSequence.ON_ITEM;
            return TypeSequence.ITEM_SEARCH;
        }

       

        HandleSpeechEvent(speechHeld, progress);
        return TypeSequence.DIALOG;
    }

    public void HandleSpeechEvent (Speech speech, Progress progress) {
        DisableScreens();
        switch (speech.type) {
        case EventType.DIMMED_DIALOG:
        merry.gameObject.SetActive(true);
        merry.SetMerry(speech.emotion, progress.GetHeartStatus());
        actionBlackOverlay.SetActive(true);
        actionText.text = speech.dialog;
        totalCharactersInText = actionText.textInfo.characterCount;
        actionText.maxVisibleCharacters = 0;
        break;
        case EventType.DIALOG:
        merry.gameObject.SetActive(true);
        merry.SetMerry(speech.emotion, progress.GetHeartStatus());
        dialogText.text = speech.dialog;
        totalCharactersInText = dialogText.textInfo.characterCount;
        dialogText.maxVisibleCharacters = 0;
        this.speech.SetActive(true);
        break;
        case EventType.BLACK_SCREEN_DIALOG:
        fullblackScreen.SetActive(true);
        actionBlackOverlay.SetActive(true);
        actionText.text = speech.dialog;
        totalCharactersInText = actionText.textInfo.characterCount;
        actionText.maxVisibleCharacters = 0;
        break;
        default:
        merry.gameObject.SetActive(false);
        wholeScreen.SetActive(true);
        this.speech.SetActive(true);
        break;
        }
        currentCharacterInScroll = 0;
        currentCharacterInScrollf = 0;
        uiScreenClick.SetActive(true);
        wholeScreen.SetActive(true);
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
        actionBlackOverlay.SetActive(false);
        fullblackScreen.SetActive(false);
        inventoryOptionOnItemView.SetActive(false);
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
