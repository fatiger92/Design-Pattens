using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Observer
{
    public GameObject box_object;
    public Subject subject;

    private void Start()
    {
        if (subject != null) subject.AddObserver(this);
    }

    public override void OnNorify()
    {
        if (box_object != null)
        {
            RadomMove();
            Debug.Log("이벤트 수신!");    
        }

        void RadomMove()
        {
            box_object.transform.position = new Vector3(Random.Range(0, 10f), Random.Range(0, 10f), Random.Range(0, 10f));
        }
    }
}
