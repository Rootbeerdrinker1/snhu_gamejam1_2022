using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideTrigger : MonoBehaviour
{
	public bool hasPlayer = false;
	public GameObject locker;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			hasPlayer = true;
			GameManager.instance.useHint.SetActive(true);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			hasPlayer = false;
			GameManager.instance.useHint.SetActive(false);
		}
	}

	private void Update()
	{
		if (hasPlayer && Input.GetKeyDown("e"))
		{
			//Debug.Log("E");
			GameManager.instance.isHiding = !GameManager.instance.isHiding;
			GameManager.instance.hideSpot = locker;
		}
	}
}
