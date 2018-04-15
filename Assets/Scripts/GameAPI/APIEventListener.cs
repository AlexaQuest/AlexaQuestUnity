using GameAPI;
using UnityEngine;

public abstract class APIEventListener : MonoBehaviour
{
    public abstract void HandleEvent(APIEventType apievent);
}