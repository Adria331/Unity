using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public GameObject playerObject;

    // Movement && detection ground
    public float velocity;
    public float jump;
    public float trampolinJump;
    private Rigidbody2D body;
    private Vector2 movement;
    public Transform groundPoint;
    public LayerMask isground;
    public LayerMask trap;
    
    // Falling dead && respawn 
    public Transform respawnPoint;
    public Transform deadUnderMap;

    // Animator
    private float isMoving;
    public Animator animator;

    // Direction of player
    private float look;
    private bool lookingRight;

    // Pj stats
    public int hp;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        movement = new Vector2();
        animator = GetComponent<Animator>();
        lookingRight = true;
    }


    void Update()
    {
        // DIRECTION OF THE PJ //
        look = Input.GetAxis("Horizontal");  // look =  1 if '->'   -1 if '<-'    0 if you don't press anything
        Vector3 left = new Vector3(0, 180, 0);
        Vector3 rigth = new Vector3(0, 180, 0); 
        if (look < 0 && lookingRight)
        {
            transform.Rotate(Vector3.up, 180);
            lookingRight = false;
        }else if (look > 0 && !lookingRight)
        {
            transform.Rotate(Vector3.up, 180);
            lookingRight = true;
        }

        // ANIMATIONS //
        if (Input.GetButton("Horizontal"))
            animator.SetFloat("walking", 1f);
        else
            animator.SetFloat("walking", 0f);
        animator.SetFloat("jumping", Mathf.Abs(body.velocity.y));


        // HORIZONTAL MOVES //
        if (Input.GetKey("right"))
            transform.position -= Vector3.left * velocity * Time.deltaTime;
        if (Input.GetKey("left"))
            transform.position -= Vector3.right * velocity * Time.deltaTime;

        // Trampolin //
        movement = body.velocity;
        if (Physics2D.OverlapCircle(groundPoint.position, 0.05f, trap))
            movement.y = trampolinJump;
        body.velocity = movement;

        // JUMPING/FALLING MOVEMENT //
        movement = body.velocity;
        if (Physics2D.OverlapCircle(groundPoint.position, 0.03f, isground) && Input.GetKey(KeyCode.UpArrow))
            movement.y = jump;
        body.velocity = movement;



        ////// DEAD CONDITIONS /////

        // FALLING DEAD //
        if (transform.position.y < deadUnderMap.position.y)
        {
            transform.position = respawnPoint.position;
            hp--;
        }

        if (hp <= 0)
            Destroy(this);

    }

}
