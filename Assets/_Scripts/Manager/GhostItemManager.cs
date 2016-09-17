using UnityEngine;
using System.Collections.Generic;

public class GhostItemManager {
    public static void Update(SausageController controller, bool hasGhost) {
        GameObject go = controller.gameObject;

        List<Collider[]> playersCols = new List<Collider[]>();
        List<Collider[]> allCols = new List<Collider[]>();
        Collider[] myCols = go.transform.parent.GetComponentsInChildren<Collider>();

        int playerId = go.GetComponent<SausageController>().playerId;

        for (int i = 0; i < Manager.GetPlayersCount(); i++) {
            if (i + 1 != playerId) {
                playersCols.Add(Manager.GetPlayer(i + 1).GetComponentsInChildren<Collider>());
            }
        }

        for (int i = 0; i < playersCols.Count; i++) {
            allCols.Add(playersCols[i]);
        }

        allCols.Add(myCols);

        int iterations = 0;
        float initTime = Time.realtimeSinceStartup;

        for (int i = 0; i < myCols.Length; i++) {
            for (int j = 0; j < allCols.Count; j++) {
                for (int k = 0; k < allCols[j].Length; k++, iterations++) {
                    Physics.IgnoreCollision(myCols[i], allCols[j][k], hasGhost);
                }
            }
        }

        //Head
        Collider head = go.transform.parent.FindChild("Head").GetComponent<Collider>();
        Collider firstChain = go.transform.parent.FindChild("FirstChain").GetComponentInChildren<Collider>();
        Physics.IgnoreCollision(head, firstChain, false);

        //Knifes
        List<Collider[]> playersKnifeCols = new List<Collider[]>();
        List<Collider[]> allKnifeCols = new List<Collider[]>();
        Collider[] myKnifeCols = go.transform.parent.FindChild("Head/KnifePivot").GetComponentsInChildren<Collider>();

        for (int i = 0; i < Manager.GetPlayersCount(); i++) {
            if (i + 1 != playerId) {
                playersKnifeCols.Add(Manager.GetPlayer(i + 1).transform.FindChild("Head/KnifePivot").GetComponentsInChildren<Collider>());
            }
        }

        for (int i = 0; i < playersKnifeCols.Count; i++) {
            allKnifeCols.Add(playersKnifeCols[i]);
        }

        allKnifeCols.Add(myKnifeCols);

        for (int i = 0; i < myKnifeCols.Length; i++) {
            for (int j = 0; j < myCols.Length; j++) {
                Physics.IgnoreCollision(myKnifeCols[i], myCols[j], hasGhost);
            }

            for (int j = 0; j < playersCols.Count; j++) {
                for (int k = 0; k < playersCols[j].Length; k++) {
                    Physics.IgnoreCollision(myKnifeCols[i], playersCols[j][k], false);
                }
            }
        }

        Debug.Log("Iteration time: " + (Time.realtimeSinceStartup - initTime).ToString("n9") + "s | "
            + ((Time.realtimeSinceStartup - initTime) * 1000f).ToString("n9") + "ms");
        Debug.Log("Iterations: " + iterations);
    }
}
