using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    public float moveSpeed = 1;
    public float rotateSpeed = 1;

    public int playerId = 1;

    private Rigidbody body;

	private void Awake () {
        body = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        //print("HasGame: " + GameManager.hasGame);

        if(!GameManager.hasGame) { return; }

        Rotate();
        Move();
	}

    private void Move () {
        float vert = Input.GetAxisRaw("p" + playerId + "Forward");
        if(vert > 0) {
            //Vector3 posTo = body.transform.forward * vert;

            //body.MovePosition(body.position + posTo * Time.deltaTime * moveSpeed);
            //body.velocity = transform.forward * moveSpeed * Time.deltaTime;
            body.AddForce(transform.forward * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void Rotate () {
        float hor = Input.GetAxis("p" + playerId + "Rotation");

        //Quaternion rotation = Quaternion.Euler(0, hor * rotateSpeed * Time.deltaTime, 0);

        //body.transform.Rotate(0, hor * rotateSpeed * Time.deltaTime, 0);
       // Vector3 rotation = new Vector3(0, hor * rotateSpeed * Time.deltaTime, 0);
        //body.MoveRotation(body.rotation * rotation);

        body.AddTorque(Vector3.up * rotateSpeed * hor * Time.deltaTime, ForceMode.Impulse);
    }
}
