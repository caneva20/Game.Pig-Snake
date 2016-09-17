using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour {
    [Header("UI")]
    public Sprite icon;

    public virtual void Use (GameObject go) {
        Destroy(gameObject);
    }
}
