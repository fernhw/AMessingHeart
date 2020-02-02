

using UnityEngine;

public class ClickedHack : MonoBehaviour
{
    public string idString;
    public string objectIdentifier;
    public TypeOfTarget type;

    Main mainBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        mainBehaviour = ( Main )FindObjectOfType(typeof(Main));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown () {
        mainBehaviour.ClickedData(idString, type, this);
    }
}

public enum TypeOfTarget {
    UI,
    UI_INVENTORY,
    ITEM,
    FIXER
}
