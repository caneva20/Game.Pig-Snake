using UnityEngine;
using System.Collections;

public class GhostItem : Item {
    public float duration = 60;
    private Clock clock;

    private SausageController controller;

    public override void Use (GameObject go) {
        controller = go.GetComponent<SausageController>();
        controller.HasGost = true;

        GhostItemManager.Update(controller, true);
        Manager.GetTimer().New(End, duration, true);
    }

    //private IEnumerator ReturnLayer () {
    //    yield return new WaitForSeconds(duration);

    //    Destroy(gameObject);
    //}

    public void End() {
        GhostItemManager.Update(controller, false);
        controller.HasGost = false;
    }
}