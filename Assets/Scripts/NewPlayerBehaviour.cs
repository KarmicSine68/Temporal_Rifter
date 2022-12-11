using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb2D;
    BoxCollider2D boxCollider;
    public LayerMask jumpLayer;

    public float speed = 25f;

    bool facingRight;

    // Start is called before the first frame update
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;
        boxCollider = GetComponent<BoxCollider2D>();

        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        NewGameController gc = FindObjectOfType<NewGameController>();

        if (!gc.end)
        {
            float move = Input.GetAxis("Horizontal");
            rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

            if(move < 0 && facingRight)
            {
                Flip();
            }
            else if(move > 0 && !facingRight)
            {
                Flip();
            }
            
            Jump();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isJump())
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 20);
        }
    }

    private bool isJump()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, jumpLayer);
        return raycastHit2D.collider != null;
    }
}
