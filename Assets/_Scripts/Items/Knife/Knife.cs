using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Knife : MonoBehaviour {
    private void OnCollisionEnter (Collision col) {
        //print("Tag:" + col.collider.tag);
        if (col.collider.tag.Equals("SausageChain")) {
            col.collider.GetComponentInParent<Sausage>().sauController.Cut(col.collider.GetComponentInParent<Sausage>());
            transform.GetComponentInParent<SausageController>().hasKnife = false;
            Destroy(transform.parent.gameObject);
        }
    }
}
