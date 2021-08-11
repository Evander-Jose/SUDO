using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D rb2D;
    public float lowJumpMultiplier = 2f; //For short taps, multiply gravity by this much.

    private float _x_input = 0f;

    public float runSpeed = 400f;
    [Space]
    public SpriteRenderer sprite;
    public BoolVariable canMove;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        if (canMove.CurrentValue == false)
        {
            _x_input = 0f;
            rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
            return;         
        }
        
        
        _x_input = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(_x_input <= -0.01f)
        {
            transform.right = Vector3.left;
            sprite.flipX = true;
        } else if(_x_input >= 0.01f)
        {
            transform.right = Vector3.right;
            sprite.flipX = false;
        }

        if(Input.GetButtonDown("Jump"))
        {
            controller.Jump();
        }
    }

    private void FixedUpdate()
    {
        controller.Move(_x_input * Time.fixedDeltaTime, false, false);      
    }
}
