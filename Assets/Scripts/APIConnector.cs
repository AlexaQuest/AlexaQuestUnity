using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class APIConnector : MonoBehaviour
{
    IEnumerator DownloadWebService()
    {
        while (true)
        {
            WWW w = new WWW("https://alexa-quest.appspot.com/game");
            yield return w;
            print("Waiting for webservice\n");
            yield return new WaitForSeconds(1f);
            print("Received webservice\n");
            ExtractCommand(w.text);
            print("Extracted information");
            yield return new WaitForSeconds(5);
        }
    }

    void ExtractCommand(string json)
    {
        Debug.Log(json);
    }

    // Use this for initialization
    void Start()
    {
        print("Started webservice import...\n");

        String json = "{\"this is\": \"from the game\"}";
        
        Dictionary<string,string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");

        byte[] pData = Encoding.ASCII.GetBytes(json.ToCharArray());
        WWW n = new WWW("https://alexa-quest.appspot.com/game", pData, headers);

        StartCoroutine(DownloadWebService());
    }
}