using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb2D;
    BoxCollider2D boxCollider;
    public LayerMask jumpLayer;

    public float speed = 25f;

    // Start is called before the first frame update
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        NewGameController gc = FindObjectOfType<NewGameController>();

        if (!gc.end)
        {
            rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2D.velocity.y);

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {

            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {

            }

            Jump();
        }
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isJump())
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
