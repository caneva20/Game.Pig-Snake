using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShieldItem : Item {
    public override void Use (GameObject go) {
        GameObject[] sausages = go.GetComponent<SausageController>().GetSausages().ToArray();

        List<Sausage> sausageList = new List<Sausage>();

        for(int i = 0; i < sausages.Length; i++) {
            sausageList.Add(sausages[i].GetComponent<Sausage>());
        }

        StartCoroutine(UseShield(sausageList));
    }

    private IEnumerator UseShield (List<Sausage> sausages) {
        for(int i = 0; i < sausages.Count; i++) {
            sausages[i].GetComponent<Sausage>().AddShield();
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }
}
