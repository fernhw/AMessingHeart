using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject uiContainer;
    public GameObject wholeScreen;

    public GameObject backButton;
    public GameObject speech;
    public GameObject merry;


    private void Start () {
        //SetupStage
        ItemSearch();
    }

    public void DisableUI () {
        uiContainer.SetActive(false);
       // wholeScreen.SetActive(false);
    }

    public void EnableUI () {
        uiContainer.SetActive(true);
    }

    public void ItemSearch () {
        backButton.SetActive(false);
    }

    public void OnItem () {
        backButton.SetActive(true);
    }

    public void OnInventory () {

    }

    public void OnDialog () {
        wholeScreen.SetActive(true);
    }
}
