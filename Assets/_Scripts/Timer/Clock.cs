using UnityEngine;
using System.Collections;

public class Clock: MonoBehaviour {
    private float seconds;
    private Timer.NullDelegate method;

    public void New(Timer.NullDelegate method, float seconds, bool start) {
        this.seconds = seconds;
        this.method = method;

        if (start) {
            //method();
            StartCoroutine(Begin(method, seconds));
        }
    }

    private IEnumerator Begin(Timer.NullDelegate method, float time) {
        yield return new WaitForSeconds(time);
        method();
        Destroy(gameObject);
    }

    public void Run() {
        StartCoroutine(Begin(method, seconds));
    }
}
