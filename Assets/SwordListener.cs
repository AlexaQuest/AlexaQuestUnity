using System.Collections;
using System.Collections.Generic;
using GameAPI;
using UnityEngine;

public class SwordListener : APIEventListener {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void HandleEvent(APIEventType apievent)
	{
		if (apievent == APIEventType.ATTACK)
		{
			transform.Translate(10, 0, 0);
		}
	}
}
