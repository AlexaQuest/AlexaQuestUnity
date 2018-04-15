using System;
using System.Collections;
using System.Collections.Generic;
using GameAPI;
using UnityEngine;

public class APIConnector : MonoBehaviour
{
    public static APIConnector ApiConnector;
    public List<APIEventListener> Handlers = new List<APIEventListener>();
    public GameController GameController;

    APIConnector()
    {
        ApiConnector = this;
    }
    
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
        if (!GameController.PlayerTurn) return;
        APIEventType eventType = (APIEventType) Enum.Parse(typeof(APIEventType), result, true);
        Debug.Log("event triggered: " + eventType);
        foreach (APIEventListener apiEventListener in Handlers)
        {
            if (apiEventListener == null) return;
            apiEventListener.HandleEvent(eventType);
        }

        GameController.PlayerTurn = false;
        foreach (EnemyController Enemy in GameController.Enemies)
        {
            Enemy.TakeTurn();
        }
        GameController.PlayerTurn = true;
    }

    void Start()
    {
        StartCoroutine(DownloadWebService());
    }

    public void GameOver()
    {
        Handlers = new List<APIEventListener>();
    }
}