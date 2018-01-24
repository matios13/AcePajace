using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMovement : MonoBehaviour {

	[SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private LayerMask whatIsGround;

    public Transform groundCheck;
    const float groundedRadius = .1f;
    public bool grounded;
    private Animator anim;
    private Rigidbody2D rigidbody2D;
    private bool facingRight = true;
    public int cooldown = 0;
    private int maxCooldown = 10;

    private void Awake()
    {
        groundCheck = transform.Find("CheckGround");
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }

        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
    }

    public void Move(float move, bool jump, int attack)
    {
        // The Speed animator parameter is set to the absolute value of the horizontal input.
        anim.SetFloat("Speed", Mathf.Abs(move));

        // Move the character
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        Attack(attack);


        if ((move > 0 && !facingRight) || (move < 0 && facingRight))
        {
            Flip();
        }

        // If the player should jump...
        if (grounded && jump)
        {
            // Add a vertical force to the player.
            grounded = false;
            anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void Attack(int attack)
    {
        if (cooldown == 0)
        {
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack3", false);
            switch (attack)
            {
                case 1:
                    anim.SetBool("Attack1", true);
                    cooldown = maxCooldown;
                    break;
                case 2:
                    anim.SetBool("Attack2", true);
                    cooldown = maxCooldown;
                    break;
                case 3:
                    anim.SetBool("Attack3", true);
                    cooldown = maxCooldown;
                    break;
            }
        }
        else
        {
            cooldown--;
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
