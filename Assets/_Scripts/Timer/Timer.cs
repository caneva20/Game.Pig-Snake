using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public GameObject clock;
    public Transform clockHolder;

    public delegate void NullDelegate();

    /// <summary>
    /// Creates a new clock GameObject that runs @method @seconds after the call
    /// </summary>
    /// <param name="method">The method that will be ran at the end</param>
    /// <param name="seconds">The delay needed to wait before executing @method</param>
    /// <param name="start">If true it will run the clock now, otherwise it will wait for the call of @Run int the clock</param>
    public Clock New(NullDelegate method, float seconds, bool start) {
        GameObject newClock = Instantiate(clock) as GameObject;
        Clock newClockClass = newClock.GetComponent<Clock>();

        newClockClass.New(method, seconds, start);
        newClock.transform.parent = clockHolder;

        return newClockClass;
    }
}
