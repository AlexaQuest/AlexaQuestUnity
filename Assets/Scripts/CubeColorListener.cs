using GameAPI;
using UnityEngine;

public class CubeColorListener : APIEventListener
{
    // Use this for initialization
    void Start()
    {
        SetColor(Color.blue);
    }

    void SetColor(Color c)
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = c;
    }

    public override void HandleEvent(APIEventType apievent)
    {
        if (apievent == APIEventType.ATTACK) SetColor(Color.green);
    }
}