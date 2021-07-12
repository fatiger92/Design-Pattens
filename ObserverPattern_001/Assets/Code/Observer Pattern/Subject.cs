using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour, IObserver
{
    List<Observer> observer_list = new List<Observer>(); // 관찰자를 담는 리스트

    private float time;

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 3.0f)
        {
            Notify();
            time = 0;

            Debug.Log("이벤트 발신!");
        }
    }

    // 전체에 이벤트 전송
    public void Notify()
    {
        foreach (var observer in observer_list)
        {
            observer.OnNorify();
        }
    }

    // 관찰자 추가
    public void AddObserver(Observer observer)
    {
        observer_list.Add(observer);
    }

    // 관찰자 제거
    public void RemoveObserver(Observer observer)
    {
        observer_list.Add(observer);
    }
}
