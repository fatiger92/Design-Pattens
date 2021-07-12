using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour, IObserver
{
    List<Observer> observer_list = new List<Observer>(); // �����ڸ� ��� ����Ʈ

    private float time;

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 3.0f)
        {
            Notify();
            time = 0;

            Debug.Log("�̺�Ʈ �߽�!");
        }
    }

    // ��ü�� �̺�Ʈ ����
    public void Notify()
    {
        foreach (var observer in observer_list)
        {
            observer.OnNorify();
        }
    }

    // ������ �߰�
    public void AddObserver(Observer observer)
    {
        observer_list.Add(observer);
    }

    // ������ ����
    public void RemoveObserver(Observer observer)
    {
        observer_list.Add(observer);
    }
}
