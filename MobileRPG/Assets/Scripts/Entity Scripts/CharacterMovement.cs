using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    // Rigid body for player
    private Rigidbody2D playerRigidbody2D;

    // Determine the player facing
    private bool facingRight;

    // Modifier for player speed
    public float speed = 4.0f;

    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // TODO: add touch controls

        // Store horizonal input
        float movementPlayerVector = Input.GetAxis("Horizontal");

        // Apply velocity to x axis
        playerRigidbody2D.velocity = new Vector2(movementPlayerVector * speed, playerRigidbody2D.velocity.y);

        // Update speed float on animator
        anim.SetFloat("Speed", Mathf.Abs(movementPlayerVector));

        if (movementPlayerVector > 0 && !facingRight)
            Flip();
        else if (movementPlayerVector < 0 && facingRight)
            Flip();
	}

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
