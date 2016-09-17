using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    [Header("Keys")]
    public KeyCode key1;
    public KeyCode key2;
    public KeyCode key3;

    [Header("UI")]
    public Image img0;
    public Image img1;
    public Image img2;
    public Sprite bg;

    public static GameObject globalItemHolder;

    [SerializeField]private Item[] items = new Item[3];

    private void Start () {
        UpdateUI();
    }

    private void Update () {
        if (globalItemHolder == null) {
            globalItemHolder = GameObject.FindGameObjectWithTag("GlobalItemHolder");
        }

        if (Input.GetKeyDown(key1)) {
            Use(0);
        }

        if(Input.GetKeyDown(key2)) {
            Use(1);
        }

        if(Input.GetKeyDown(key3)) {
            Use(2);
        }

        UpdateUI();
    }

    public void Use (int id) {
        if (id >= 0 && id <= 2) {
            items[id].Use(gameObject);
            RemoveItem(id);
        }
    }

    public void AddItem (GameObject item) {
        GameObject newItem = Instantiate(item) as GameObject;
        newItem.transform.parent = globalItemHolder.transform;

        for(int i = 0; i < 3; i++) {
            if (items[i] == null) {
                items[i] = newItem.GetComponent<Item>();
                break;
            }
        }

        UpdateUI();
    }

    public void RemoveItem (int id) {
        if (id >= 0 && id <= 2) {
            items[id] = null;

            //switch(id) {
            //    case 0:
            //        img0 = null;
            //        break;

            //    case 1:
            //        img1 = null;
            //        break;

            //    case 2:
            //        img2 = null;
            //        break;
            //}
        }

        UpdateUI();
    }

    public void UpdateUI () {
        if(items[0] != null) {
            img0.sprite = items[0].icon;
        } else {
            img0.sprite = bg;
        }

        if(items[1] != null) {
            img1.sprite = items[1].icon;
        } else {
            img1.sprite = bg;
        }

        if(items[2] != null) {
            img2.sprite = items[2].icon;
        } else {
            img2.sprite = bg;
        }
    }
}
