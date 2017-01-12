using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugInfoText : MonoBehaviour
{
	string thatInfo;
	public GameObject pc;

	// Update is called once per frame
	void Update()
	{
		if (pc != null)
			gameObject.GetComponent<Text>().text = "HP: " + pc.GetComponent<Player>().playerHP;
		else
			gameObject.GetComponent<Text>().text = "Game Over :(";
	}
}
