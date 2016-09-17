using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text scoreP1;
    public Text scoreP2;

    public SausageController sauP1;
    public SausageController sauP2;

    private void Update () {
        UpdateUI();
    }

    public void UpdateUI () {
        scoreP1.text = sauP1.GetSausages().Count.ToString();
        scoreP2.text = sauP2.GetSausages().Count.ToString();
    }
}
