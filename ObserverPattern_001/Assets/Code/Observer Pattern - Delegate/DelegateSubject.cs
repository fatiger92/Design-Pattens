using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateSubject : MonoBehaviour
{
    public delegate void EventHandler();
    public event EventHandler eventhandler;

    float time;

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 3.0f)
        {
            time = 0;
            eventhandler();
            Debug.Log("Event Send!");
        }
    }
}
