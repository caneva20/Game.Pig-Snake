using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    public string name;
    public Border border;
    public GameObject obj;
    public Vector3 rotation = new Vector3(0, 0, 90);
    public float y = 0;
    public float spawnDelay = 5;
    public int spawnLimit = int.MaxValue;

    [SerializeField]private float time;
    [SerializeField]private List<GameObject> spawned = new List<GameObject>();

    private void Update () {
        time += Time.deltaTime;

        if (time >= spawnDelay && spawned.Count < spawnLimit) {
            Spawn();
            time -= spawnDelay;
        }

        UpdateList();
    }

    private void Spawn () {
        float sizeX = (border.p1.x - border.p2.x);
        float sizeZ = (border.p1.z - border.p2.z);

        int x = (int)(Random.value * sizeX) + (int)border.p2.x;
        int z = (int)(Random.value * sizeZ) + (int)border.p2.z;

        spawned.Add(Instantiate(obj, new Vector3(x, y, z), Quaternion.Euler(rotation)) as GameObject);
    }

    public void UpdateList () {
        for(int i = spawned.Count-1; i >= 0; i--) {
            //print(spawned[i]);

            if (spawned[i] == null) {
                spawned.RemoveAt(i);
            }
        }
    }
}
