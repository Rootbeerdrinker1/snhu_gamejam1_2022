using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternPickup : MonoBehaviour
{
	
	public bool hasPlayer = false;
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			hasPlayer = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			hasPlayer = false;
		}
	}

	private void Update()
	{
		if (hasPlayer && Input.GetKeyDown("e"))
		{
			GameManager.instance.lanternEnabled = true;
			Destroy(this.gameObject);
		}
	}
}
