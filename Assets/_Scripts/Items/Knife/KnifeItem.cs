using UnityEngine;
using System.Collections;

public class KnifeItem : Item {
    public override void Use (GameObject go) {
        go.GetComponent<SausageController>().AddKnife();
        base.Use(go);
    }
}
