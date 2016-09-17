using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
    public Transform target;
    public float y = 40;
	
	void Update () {
        transform.position = new Vector3(target.position.x, y, target.position.z);
	}
}
