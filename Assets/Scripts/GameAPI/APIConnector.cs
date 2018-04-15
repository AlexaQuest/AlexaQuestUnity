using System;
using System.Collections;
using System.Collections.Generic;
using GameAPI;
using UnityEngine;

public class APIConnector : MonoBehaviour
{
    public List<APIEventListener> Handlers = new List<APIEventListener>();

    IEnumerator DownloadWebService()
    {
        while (true)
        {
            WWW w = new WWW("https://serene-sea-16241.herokuapp.com/game");
            yield return w;
            ExtractCommand(w.text);
            yield return new WaitForSeconds(0.25f);
        }
    }

    void ExtractCommand(string result)
    {
        if (result.Equals("")) return;
        APIEventType eventType = (APIEventType) Enum.Parse(typeof(APIEventType), result, true);
        foreach (APIEventListener apiEventListener in Handlers)
        {
            if (apiEventListener == null) return;
            apiEventListener.HandleEvent(eventType);
        }
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DownloadWebService());
    }
}