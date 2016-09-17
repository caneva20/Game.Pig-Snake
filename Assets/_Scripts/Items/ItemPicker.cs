using UnityEngine;
using System.Collections;

public class ItemPicker : MonoBehaviour {
    public GameObject item;
    public AudioSource audioPlayer;
    public AudioClip pickUp;

    public void Awake () {
        audioPlayer = GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter (Collision col) {
        if(col.collider.tag.Equals("Head")) {
            col.collider.GetComponent<SausageController>().inventory.AddItem(item);
            Destroy(gameObject);
            audioPlayer.PlayOneShot(pickUp);
            //Use(col.collider.gameObject);
        }
    }
}
