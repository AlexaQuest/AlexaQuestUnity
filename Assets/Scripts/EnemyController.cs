using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private Animator anim;

	public int Health = 10;
	public static int Damage = 1;

	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	public void TakeTurn()
	{
		Debug.Log("my turn");
		AttackPlayer();
	}

	public void AttackPlayer()
	{
		anim.SetTrigger("swing");
		GameController.MainGameController.Player.TakeDamage(Damage);
	}

	public void TakeDamage(int howMuch)
	{
		Health -= howMuch;
		if (Health <= 0)
		{
			GameController.MainGameController.Enemies.Remove(this);
			Destroy(gameObject);
		}
	}
}
