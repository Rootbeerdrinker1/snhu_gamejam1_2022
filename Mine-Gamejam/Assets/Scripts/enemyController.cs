using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public Rigidbody2D rb;

	public float initialPlayerDistance;
	public float playerDistance;
	// Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			if (!GameManager.instance.isHiding)
			{
				GameManager.instance.isDead = true;
			}
		}
		else if (collision.tag == "EnemyRemover")
		{
			GameManager.instance.volumeFadeoutFunc();
			Destroy(this.gameObject);
		}

	}

	private void Start()
	{
		initialPlayerDistance = Vector2.Distance(this.gameObject.transform.position, GameManager.instance.player.transform.position);
		rb.velocity = new Vector2(3.5f, 0f);
	}
	// Update is called once per frame
	void Update()
    {
		if (GameManager.instance.isDead)
		{
			rb.velocity = Vector2.zero;
			return;
		}
		

		playerDistance = initialPlayerDistance - Vector2.Distance(this.gameObject.transform.position, GameManager.instance.player.transform.position);
		GameManager.instance.chaseMusic.volume = (((playerDistance) * GameManager.instance.setVolume * 2.5f) / initialPlayerDistance) + GameManager.instance.setVolume / 2;


	}
	
}
