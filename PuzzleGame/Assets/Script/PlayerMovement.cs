using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Horizontal")]
    public float Speed;
    private float Move;
    [Header("Vertical")]
    [SerializeField] private float JumpPower;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float JumpTimer;
    [SerializeField] private float JumpMultiplier;
    private bool isJumping;
    private float jumpCounter;
    private float isGround;
    [Header("Component")]
    public Rigidbody2D rb;
    public LayerMask GroundLayer;
    public BoxCollider2D boxCollider;
    private Animator anim;
    public ParticleSystem dustMovement;
    //ForJump
    public Vector2 verGravity;
    [Header("Shoot")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed;
    public int maxShots;
    private int remainingShots;
    private float AttackTime = 0;


    void Start()
    {
        verGravity = new(0, -Physics2D.gravity.y);
        anim = GetComponent<Animator>();
        remainingShots = maxShots;

    }
    void Update()
    {
        move();
        Flip();
        Jump();
        // Shoot if the player presses the fire button
        if (Input.GetKeyDown(KeyCode.X) && remainingShots > 0)
        {
            Shoot();
            AttackTime = Time.time + 1f;
        }
    }
    void move()
    {
        Move = Input.GetAxis("Horizontal");
        if (Move != 1)
        {
            rb.velocity = new Vector2(Speed * Move, rb.velocity.y);
            anim.SetBool("run", true);
        }
        else
            anim.SetBool("run", false);
    }
    void Flip()
    {
        if (Move > 0.01f)
        {
            transform.localScale = new Vector3(3, 3, 1);
            Dustplay();
        }
        else if (Move < -0.01f)
        {
            transform.localScale = new Vector3(-3, 3, 1);
            Dustplay();
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            isJumping = true;
            jumpCounter = 0;
            anim.SetTrigger("jump");
            Dustplay();
        }
        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > JumpTimer)
                isJumping = false;
            float t = jumpCounter / JumpTimer;
            float currentjump = JumpMultiplier;
            if (t > 0.5f)
                currentjump = JumpMultiplier * (1 - t);
            rb.velocity += verGravity * currentjump * Time.deltaTime;

        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpCounter = 0;
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            anim.SetTrigger("jump");
        }
        if (rb.velocity.y < 0)
            rb.velocity -= verGravity * fallMultiplier * Time.deltaTime;


    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, GroundLayer);
        return raycastHit.collider != null;
    }
    void Shoot()
    {
        // Decrement remaining shots
        remainingShots--;
        // Spawn a new bullet prefab at the bullet spawn position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        // Determine the direction the player is facing
        Vector2 direction = Vector2.right;
        if (transform.localScale.x < 0)
        {
            direction = Vector2.left;
        }

        // Apply a velocity to the bullet to make it move in the correct direction
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
    void Dustplay()
    {
        dustMovement.Play();
    }
}
