using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb2D;
    BoxCollider2D boxCollider;
    public LayerMask jumpLayer;

    public Animator animator;

    public float speed = 25f;

    bool facingRight;

    float hMove;

    bool isRunning;

    [SerializeField] private AudioSource runAudio;
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource activateAudio;

    // Start is called before the first frame update
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;
        boxCollider = GetComponent<BoxCollider2D>();

        facingRight = true;

        isRunning = false;

        InvokeRepeating("RunSound", 0, .2f);

        hMove = 0;
    }

    void RunSound()
    {
        NewGameController gc = FindObjectOfType<NewGameController>();

        if (isRunning && isJump() && !gc.end)
        {
            runAudio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        NewGameController gc = FindObjectOfType<NewGameController>();

        if (!gc.end)
        {
            float move = Input.GetAxis("Horizontal");
            rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

            hMove = move * speed;

            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }

            animator.SetFloat("Speed", Mathf.Abs(hMove));

            if(move < 0 && facingRight)
            {
                Flip();
            }
            else if(move > 0 && !facingRight)
            {
                Flip();
            }
            
            Jump();

            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                activateAudio.Play();
            }
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
            jumpAudio.Play();
        }
    }

    private bool isJump()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, jumpLayer);
        return raycastHit2D.collider != null;
    }
}
