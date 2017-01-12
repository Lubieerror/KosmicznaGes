using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public int playerHP = 100;
	public int playerPoints = 0;

	void Update()
	{
		//Debug.Log(playerHP);
		//death
		if (playerHP <= 0)
			death();
	}

	void death()
	{
		//explosion animation

		//inicjalize GameOver :(

		Destroy(gameObject);
	}

	public void getDamage(int dmg)
	{
		playerHP -= dmg;
	}
}
