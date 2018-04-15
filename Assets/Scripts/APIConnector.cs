using System.Collections;
using UnityEngine;

public class APIConnector : MonoBehaviour
{
    IEnumerator DownloadWebService()
    {
        while (true)
        {
            WWW w = new WWW("https://serene-sea-16241.herokuapp.com/game");
            yield return w;
            yield return new WaitForSeconds(0.25f);
            if (!w.text.Equals(""))
            {
                ExtractCommand(w.text);
            }

            yield return new WaitForSeconds(0.25f);
        }
    }

    void ExtractCommand(string result)
    {
        Debug.Log(result);
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DownloadWebService());
    }
}