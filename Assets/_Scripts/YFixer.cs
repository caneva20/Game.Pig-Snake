using UnityEngine;
using System.Collections;

public class YFixer : MonoBehaviour {
    public float targetY;
	
	void FixedUpdate () {
        Vector3 pos = transform.position;
        pos.y = targetY;
        transform.position = pos;
	}
}
