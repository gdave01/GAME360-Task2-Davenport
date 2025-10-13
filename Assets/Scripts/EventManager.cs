using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    private static Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();

    private static Dictionary<string, Action<object>> eventDictionaryData = new Dictionary<string, Action<object>>();

    public static void TriggerEvent(string eventName)
    {
        if (eventDictionary.ContainsKey(eventName) && eventDictionary[eventName] != null)
        {
            eventDictionary[eventName].Invoke();
        }
    }

    public static void TriggerEvent(string eventName, object data)
    {
        if (eventDictionaryData.ContainsKey(eventName) && eventDictionaryData[eventName] != null)
        {
            eventDictionaryData[eventName].Invoke(data);
        }
    }

    public static void Subscribe(string eventName, Action listener)
    {
        if (!eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] = null;
        }
        eventDictionary[eventName] += listener;
    }

    public static void Subscribe(string eventName, Action<object> listener)
    {
        if (!eventDictionaryData.ContainsKey(eventName))
        {
            eventDictionaryData[eventName] = null;
        }
        eventDictionaryData[eventName] += listener;
    }

    public static void Unsubscribe(string eventName, Action listener)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] -= listener;
        }
    }
    public static void Unsubscribe(string eventName, Action<object> listener)
    {
        if (eventDictionaryData.ContainsKey(eventName))
        {
            eventDictionaryData[eventName] -= listener;
        }
    }

    public static void ClearAllEvents()
    {
        eventDictionary.Clear();
        eventDictionaryData.Clear();
    }
}
