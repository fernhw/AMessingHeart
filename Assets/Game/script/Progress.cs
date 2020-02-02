using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Progress {

    public int heartHeal = 0;

    public Item winder = new Item("winder");
    public Item photo1 = new Item("photo_1");
    public Item photo2 = new Item("photo_2");
    public Item thread = new Item("thread");
    public Item button = new Item("button");
    public Item ballerina = new Item("ballerina");

    public bool Bear = false;
    public bool Frame = false;
    public bool Box = false;

    List<Item> items;

    public Progress () {
        items = new List<Item>() {
        winder,photo1,photo2,thread,button, ballerina
    };
    }

    public void SetItem (string search,GameObject stage, GameObject inventory) {
        int size = items.Count;
        for (int i = 0; i < size; i++) {
            Item item = items[i];
            if (search == item.name) {
                item.stageObject = stage;
                item.inventoryObject = inventory;
               // inventory.SetActive(false);
                break;
            }
        }
    }

    public void GetItem (string search) {
        int size = items.Count;

        for (int i = 0; i<size; i++) {
            Item item = items[i];
            if(search == item.name) {
                item.stageObject.SetActive(false);
                item.inventoryObject.SetActive(true);
                item.obtained = true;
                break ;
            }
        }
    }

    

    public HeartStatus GetHeartStatus () {
        switch (heartHeal) {
        case 0:
    //
        return HeartStatus.WAITING;
        case 1:
        return HeartStatus.ONE;
        case 2:
        return HeartStatus.TWO;
        case 3:
        return HeartStatus.THREE;
        case 4:
        default:
        return HeartStatus.FOUR;
        }
    }

}

public class Item {
    public bool obtained = false;
    public bool used = false;
    public bool inHold = false;

    public string name = "";

    public GameObject stageObject;
    public GameObject inventoryObject;

    public Item(string name) {
        this.name = name;
    }
}

