using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public SausageController p1;
    public SausageController p2;

    public int sausagesToWin;

    public GameObject winPanel;
    public Text winText;

    public static bool hasGame = true;

    private void Start () {
        hasGame = true;
    }

	private void Update () {
	    if (p1.GetSausages().Count >= sausagesToWin) {
            Win(p1);
        } else if(p2.GetSausages().Count >= sausagesToWin) {
            Win(p2);
        }
	}

    private void Win (SausageController controller) {
        winText.text = "PLAYER " + controller.playerId + " WON!!!";
        winPanel.SetActive(true);
        //Time.timeScale = 0;
        hasGame = false;
    }

    //Buttons
    public void Retry () {
        hasGame = true;
        SceneManager.LoadScene("Main");
    }
}
 