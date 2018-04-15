using System.Linq;
using GameAPI;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerController : APIEventListener
{
	public static int CHARGE_AMOUNT = 1;
	private Animator anim;
	public int Damage = 3;
	public int Health = 30;

	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	public override void HandleEvent(APIEventType apievent)
	{
		if (apievent == APIEventType.ATTACK)
		{
			GameController.MainGameController.Enemies.First().TakeDamage(Damage);
			if (GameController.MainGameController.Enemies.Count == 0)
			{
				GameController.MainGameController.GameOver();
			}
		}
		else if (apievent == APIEventType.SPIN)
		{
			GameController.MainGameController.Enemies.ForEach(enemy => enemy.TakeDamage(Damage));
		}
		else if (apievent == APIEventType.CHARGE)
		{
			Damage += CHARGE_AMOUNT;
		}
		anim.SetTrigger(apievent.ToString().ToLower());
	}
	
	public void TakeDamage(int howMuch)
	{
		Health -= howMuch;
		if (Health <= 0)
		{
			GameController.MainGameController.GameOver();
		}
	}
}
