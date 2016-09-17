using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    private static GameObject[] players;
    private static Timer timer;

    private void Awake() {
        Load();
    }

    private static void Load() {
        players = GameObject.FindGameObjectsWithTag("Player");
        timer = GameObject.FindGameObjectWithTag("Manager").GetComponent<Timer>();
    }

    public static GameObject GetPlayer(int id) {
        for (int i = 0; i < players.Length; i++) {
            if (players[i].GetComponentInChildren<SausageController>().playerId == id) {
                return players[i];
            }
        }

        Debug.LogError("NULL player( " + id + "). Players lenght: " + players.Length);
        return null;
    }

    public static int GetPlayersCount() {
        return players.Length;
    }

    public static Timer GetTimer() {
        return timer;
    }
}
