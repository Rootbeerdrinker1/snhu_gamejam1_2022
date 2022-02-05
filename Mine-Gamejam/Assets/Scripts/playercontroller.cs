using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Light playerLight;
    public float jumpForce;
    public float moveSpeed;
    private bool nowDead = false;

    public GameObject blood;


    void Update()
    {
		if (GameManager.instance.isDead)
		{
			if (!nowDead)
			{
                blood.SetActive(true);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            nowDead = true;

            return;
		}


        if (!GameManager.instance.isHiding)
        {
			if (GameManager.instance.lanternEnabled)
			{
                if (playerLight.intensity < 2)
                {
                    playerLight.intensity += 1f * Time.deltaTime;
                }
            }
			else
            {
                playerLight.intensity = 0f;
            }
            
            rb.gravityScale = 4;
            sr.enabled = true;
            if (Input.GetKeyDown("space") && IsGrounded())
            {
                //Debug.Log("space");
                rb.AddForce(transform.up * jumpForce);
            }

            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        }
		else
		{
            if (GameManager.instance.lanternEnabled)
            {
                if (playerLight.intensity > .5)
                {
                    playerLight.intensity -= 1f * Time.deltaTime;
                }
            }
            else
            {
                playerLight.intensity = 0f;
            }
            rb.gravityScale = 0;
            this.transform.position = GameManager.instance.hideSpot.transform.position;
            sr.enabled = false;
		}
        

    }

    bool IsGrounded()
    {

        bool b1 = Physics2D.Raycast(this.transform.position, -Vector2.up, 1f, -6);
        bool b2 = Physics2D.Raycast(new Vector2((this.transform.position.x + (transform.localScale.x / 2)), transform.position.y), -Vector3.up, 1f, -6);
        bool b3 = Physics2D.Raycast(new Vector2((this.transform.position.x - (transform.localScale.x / 2)), transform.position.y), -Vector3.up, 1f, -6);
        return (b1 || b2 || b3);
    }

	

}
