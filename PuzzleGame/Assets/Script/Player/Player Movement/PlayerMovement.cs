using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Horizontal")]

    public float Speed;
    public float FaceRight;

    private float Move;

    [Header("Vertical")]

    [SerializeField] private float JumpPower;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float JumpTimer;
    [SerializeField] private float JumpMultiplier;

    private bool isJumping;
    private float jumpCounter;

    [Header("Component")]

    public Rigidbody2D rb;
    public LayerMask GroundLayer;
    public Transform GroundChecker;
    public ParticleSystem dustMovement;

    //ForJump
    public Vector2 verGravity;

    void Start()
    {
        verGravity = new(0, -Physics2D.gravity.y);
    }
    void Update()
    {
        move();
        flip();
        jump();
    }

    private void move()
    {
        Move = Input.GetAxis("Horizontal");
        if (Move != 1)
        {
            rb.velocity = new Vector2(Speed * Move, rb.velocity.y);
        }
    }
    void flip()
    {
        if (Move > 0.01f)
        {
            transform.localScale = new Vector3(3, 3, 1);
            dustplay();
            FaceRight = 1;
        }
        else if (Move < -0.01f)
        {
            transform.localScale = new Vector3(-3, 3, 1);
            dustplay();
            FaceRight = -1;
        }
    }

    private void jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            isJumping = true;
            jumpCounter = 0;
            dustplay();
        }

        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;

            if (jumpCounter > JumpTimer)
            {
                isJumping = false;
            }

            float t = jumpCounter / JumpTimer;
            float currentjump = JumpMultiplier;

            if (t > 0.5f)
            {
                currentjump = JumpMultiplier * (1 - t);
            }

            rb.velocity += verGravity * currentjump * Time.deltaTime;

        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpCounter = 0;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= fallMultiplier * Time.deltaTime * verGravity;
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(GroundChecker.position, 0.2f, GroundLayer);
    }

    private void dustplay() => dustMovement.Play();
}
