using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
	public Sprite[] fireStates;

	public float delay = 0.1f;
	private float timer;
	private int state = 0;

	void Start()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = fireStates[state];
		timer = delay;
	}

	void Update()
	{
		//timer -= Time.deltaTime;
		//if (timer <= 0)
		//{
		//	nextState();
		//	timer = delay;
		//}

		timer -= Time.deltaTime;
		if (timer > 0.0f)
			return;
		nextState();
		timer = delay;
	}

	public void nextState()
	{
		++state;
		if (state >= fireStates.Length)
			state = 0;
		gameObject.GetComponent<SpriteRenderer>().sprite = fireStates[state];
	}
}
