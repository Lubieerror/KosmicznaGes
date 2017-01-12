using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private float actualSpeed;
	public static float shipSpeed = 0.1f;
	public static float boost = 0.4f;
	public int playerSPS = 2; //strzały na sekundę

	float offsety, offsetr;

	bool isProtected = false;

	void Start()
	{
	}

	void Update()
	{
		// Sterowanie:
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			actualSpeed += shipSpeed;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
				actualSpeed += boost;
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			actualSpeed -= shipSpeed;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
				actualSpeed -= boost;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//Shoot
		}

		//Kontrola szybkości
		if (actualSpeed > 0.05f)
			actualSpeed -= 0.05f;
		else if (actualSpeed < -0.05f)
			actualSpeed += 0.05f;
		else
			actualSpeed = 0.0f;

		//Właściwe poruszanie
		if (actualSpeed != 0.0f)
		{
			//Debug.Log("Speed: " + actualSpeed);
			offsety += Time.deltaTime * actualSpeed;
			offsetr += Time.deltaTime * actualSpeed;
			transform.position = new Vector3(transform.position.x, offsety, transform.position.z);
		}

		//Border collisions
		if (transform.position.y > 7.0f)
		{
			actualSpeed = -5.0f;
			if (!isProtected)
				gameObject.GetComponent<Player>().getDamage(5);
			isProtected = true;
		}
		else if (transform.position.y < -7.0f)
		{
			actualSpeed = 5.0f;
			if (!isProtected)
				gameObject.GetComponent<Player>().getDamage(5);
			isProtected = true;
		}
		else
			isProtected = false;

		//float testFloat = Camera.main.orthographicSize;
		//Debug.Log(testFloat);

		//Rotation
		if (actualSpeed < 2.0f && actualSpeed > -2.0f)
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
		else if (actualSpeed > 6.0f)
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, -77.0f);
		else if (actualSpeed < -6.0f)
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, -113.0f);
		else if (actualSpeed > 2.0f)
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, -86.0f);
		else if (actualSpeed < -2.0f)
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, -104.0f);
	}
}
