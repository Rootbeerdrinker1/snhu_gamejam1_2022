using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce;
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            //Debug.Log("space");
            rb.AddForce(transform.up * jumpForce);
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

    }

    bool IsGrounded()
    {
        bool b1 = Physics2D.Raycast(transform.position, -Vector2.up, 1f);
        bool b2 = Physics2D.Raycast(new Vector2((transform.position.x + (transform.localScale.x / 2)), transform.position.y), -Vector3.up, 1f);
        bool b3 = Physics2D.Raycast(new Vector2((transform.position.x - (transform.localScale.x / 2)), transform.position.y), -Vector3.up, 1f);
        return (b1 || b2 || b3);
    }

}
