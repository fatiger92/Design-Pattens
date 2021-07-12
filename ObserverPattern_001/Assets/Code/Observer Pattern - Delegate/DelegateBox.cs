using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateBox : MonoBehaviour
{
    public GameObject box_object;   // 대상 객체와 연결필요

    public DelegateSubject subject;         // 관찰자 주체 연결

    private void Start()
    {
        if (subject != null)
        {
            subject.eventhandler += OnNotify;
        }
    }

    public void OnNotify()
    {
        if (box_object != null)
        {
            RandomMove();
            Debug.Log("Event Received!");
        }

        void RandomMove()
        {
            box_object.transform.position = new Vector3(Random.Range(0, 10f), Random.Range(0, 10f), Random.Range(0, 10f));
        }
    }
}
