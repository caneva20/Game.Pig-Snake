using UnityEngine;
using System.Collections;

public class Sausage : MonoBehaviour {
    public int id;
    public GameObject sausage;
    public SausageController sauController;
    public float damageDelay = 1;

    [Header("Shield")]
    public Material normalMaterial;
    public Material shieldMaterial;

    [Header("Life")]
    public int maxLife;
    public bool undemagible;

    private Grill grill;
    [SerializeField]private bool isOnGrill;
    [SerializeField]private int life;
    [SerializeField]private float time;
    [SerializeField]private bool hasShield;

    private void Start () {
        if (!Application.isEditor && undemagible) {
            undemagible = false;
        }

        life = maxLife;
    }

    public void Update () {
        if (grill == null) {
            return;
        }

        if (isOnGrill) {
            time += Time.deltaTime;
        }

        if (time >= damageDelay) {
            time -= damageDelay;
            life -= grill.damage;
            CheckLife();
        }
    }

    public void UpdateMaterial () {
        if(hasShield) {
            transform.GetComponentInChildren<MeshRenderer>().material = shieldMaterial;
        } else {
            transform.GetComponentInChildren<MeshRenderer>().material = normalMaterial;
        }
    }

    private void CheckLife () {
        if (life <= 0 && !undemagible) {
            sauController.Cut(this);
        }
    }

    public bool Deatach () {
        if (hasShield) {
            hasShield = false;
            UpdateMaterial();
            life = maxLife;
            return false;
        }

        //print("Deatach");
        Instantiate(sausage, transform.position, transform.rotation);
        Destroy(gameObject);
        return true;
    }

    private void OnTriggerEnter (Collider col) {
        if (col.tag.Equals("Grill")) {
            isOnGrill = true;

            if (grill == null) {
                grill = col.GetComponent<Grill>();
            }
        }
    }

    public void AddShield () {
        hasShield = true;
        UpdateMaterial();
    }

    private void OnTriggerExit (Collider col) {
        if(col.tag.Equals("Grill")) {
            isOnGrill = false;
        }
    }

    public bool HasShield () {
        return hasShield;
    }
}
