using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    static public EventManager Instance;

    public delegate void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null);

    private Dictionary<EVENT_TYPE, List<OnEvent>> m_listeners = new Dictionary<EVENT_TYPE, List<OnEvent>>();

    public void PostNotify(EVENT_TYPE Event_type, Component Sender, object Param, object Param2 = null)
    {
        List<OnEvent> listenList = null;

        if (!m_listeners.TryGetValue(Event_type, out listenList)) return;

        for (int i = 0; i < listenList.Count; i++)
        {
            if (!listenList[i].Equals(null)) listenList[i](Event_type, Sender, Param);
        }
    }

    public void AddListener(EVENT_TYPE Event_type, OnEvent Listener)
    {
        List<OnEvent> listenList = null;

        if (m_listeners.TryGetValue(Event_type, out listenList))
        {
            listenList.Add(Listener);
            return;
        }

        listenList = new List<OnEvent>();
        listenList.Add(Listener);
        m_listeners.Add(Event_type, listenList);
    }

    public void RemoveEvent(EVENT_TYPE Event_type) => m_listeners.Remove(Event_type);

    public void RemoveRedundancies()
    {
        var tmpListeners = new Dictionary<EVENT_TYPE, List<OnEvent>>();

        foreach (var item in m_listeners)
        {
            for (int i = 0; i < item.Value.Count; i++)
            {
                if (item.Value[i].Equals(null)) item.Value.RemoveAt(i);
            }

            if (item.Value.Count > 0) tmpListeners.Add(item.Key, item.Value);
        }
        m_listeners = tmpListeners;
    }

    private void Awake()
    {
        Instance = this;
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        RemoveRedundancies();
        m_listeners.Clear();
    }
}
