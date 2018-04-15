using GameAPI;
using UnityEngine;

public class SwordListener : APIEventListener
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void HandleEvent(APIEventType apievent)
    {
        if (apievent == APIEventType.ATTACK)
        {
            Debug.Log("sword swing!");
            anim.SetTrigger("swing");
        }
    }
}