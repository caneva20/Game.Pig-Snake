using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SausageController : MonoBehaviour {
    public GameObject sausage;
    public GameObject mainSausage;
    public GameObject lastSausage;
    public Transform body;
    public int playerId;
    public Transform knifePivot;
    public GameObject knife;

    public KeyCode sliceKey = KeyCode.Q;

    public bool hasKnife;

    [Header("Inventory")]
    public InventoryManager inventory;

    [Header("Audio")]
    public AudioSource audioPlayer;
    public AudioClip slice;
    public AudioClip grow;

    [Header("Initial Sausages")]
    public int initialSausages;

    [Header("GodMod")]
    public bool godMod;
    
    //Private
    private int lastId;
    [SerializeField]private List<GameObject> sausages = new List<GameObject>();
    [SerializeField]private bool hasGhost;

    private void Start() {
        for (int i = 0; i < initialSausages; i++) {
            AddSausage();
        }

        if (!Application.isEditor && godMod) {
            godMod = false;
        }
    }

    private void Update () {
        if(!GameManager.hasGame) { return; }

        if (Input.GetKeyDown(sliceKey)) {
            if (sausages.Count > 0) {
                Cut(sausages[0].GetComponentInParent<Sausage>());
            }
        }

        UpdateList();
        //UpdateIndex();
    }

    private void AddSausage () {
        audioPlayer.PlayOneShot(grow);
        UpdateList();
        GameObject newSausage = Instantiate(sausage, lastSausage.transform.position - lastSausage.transform.up * 2.05f, lastSausage.transform.rotation) as GameObject;
        newSausage.GetComponent<HingeJoint>().connectedBody = lastSausage.GetComponent<Rigidbody>();
        lastSausage = newSausage;
        newSausage.transform.parent = body;
        newSausage.transform.name = "Sausage (" + lastId + ")";
        newSausage.GetComponent<Sausage>().sauController = this;
        sausages.Add(newSausage);

        if (godMod) {
            newSausage.GetComponent<Sausage>().undemagible = true;
        }

        if (hasGhost) {
            GhostItemManager.Update(this, true);
        }
    }

    private void OnCollisionEnter (Collision col) {
        if (col.collider.tag.Equals("Sausage")) {
            AddSausage();
            Destroy(col.gameObject);
        }
    }

    public List<GameObject> GetSausages () {
        return sausages;
    }

    public void UpdateList () {
        for(int i = sausages.Count - 1; i >= 0; i--) {
            if (sausages[i] == null) {
                sausages.RemoveAt(i);
            }
        }

        this.lastId = sausages.Count -1;

        if(lastId >= 0) {
            lastSausage = sausages[lastId];
        } else {
            lastSausage = mainSausage;
        }

        UpdateIndex();
    }

    public void RemoveFromId (int id) {
        for(int i = sausages.Count - 1; i >= id; i--) {
            sausages.RemoveAt(i);
        }
    }

    public IEnumerator Deatach (List<Sausage> sausages) {
        for(int i = 0; i < sausages.Count; i++) {
            sausages[i].Deatach();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Cut (Sausage sausage) {
        audioPlayer.PlayOneShot(slice);
        List<Sausage> saus = new List<Sausage>();

        for(int i = sausage.id; i < sausages.Count; i++) {
            saus.Add(sausages[i].GetComponent<Sausage>());

            if(!sausages[i].GetComponent<Sausage>().HasShield()) {
                sausages[i] = null;
            
            }
        }

        UpdateList();
        StartCoroutine(Deatach(saus));
    }

    private void UpdateIndex () {
        int id = 0;
        for(int i = 0; i < sausages.Count; i++) {
            if(sausages[i] != null) {
                sausages[i].GetComponent<Sausage>().id = id++;
            }
        }
    }

    public void AddKnife () {
        if (!hasKnife) {
            GameObject newGo = Instantiate(knife) as GameObject;

            newGo.transform.parent = knifePivot;
            newGo.transform.localPosition = new Vector3(0, 0, 0);
            newGo.transform.localRotation = Quaternion.identity;

            hasKnife = true;
        }
    }

    public bool HasGost {
        get {
            return hasGhost;
        }

        set {
            hasGhost = value;
        }
    }
}
