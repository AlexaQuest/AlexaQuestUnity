using GameAPI;
using UnityEngine;

public class PlayerController : APIEventListener
{
	private Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	public override void HandleEvent(APIEventType apievent)
	{
		anim.SetTrigger(apievent.ToString().ToLower());
	}
}
