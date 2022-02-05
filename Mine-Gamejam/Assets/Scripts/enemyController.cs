using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public Rigidbody2D rb;
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
		
	}

	// Update is called once per frame
	void Update()
    {
		if (!GameManager.instance.isDead)
		{
			rb.velocity = new Vector2(3f, 0f);
		}
        
    }
}
