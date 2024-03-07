using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2 (10f, 10f);
    [SerializeField] float ReloadDelayWater = 1f;
    [SerializeField] float gravityMultiplier = 0f;
    [SerializeField] float levelLoadDelay = 0.5f;
    [SerializeField] float ReloadDelay = 2f;
    [SerializeField] AudioSource drowningSFX;
    [SerializeField] AudioSource enemySFX;

    
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    CircleCollider2D myFeetCollider;
    bool isAlive = true;
    

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<CircleCollider2D>();
    }

   
    void Update()
    {
        if (!isAlive){return;}

        Run();
        FlipSprite();
        Die();
        WaterTouch();
    }



    void OnMove(InputValue value)
    {
        if (!isAlive){return;}
        moveInput = value.Get<Vector2>();
        
    }

    void OnJump(InputValue value)
    {
        if (!isAlive){return;}
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;}

        if(value.isPressed)
        {
            myRigidbody.velocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        
        
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (-Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }


    void Die() 
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            enemySFX.Play();
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidbody.velocity = deathKick;
            Invoke("ReloadScene", ReloadDelay);
        }
    }

    void ReloadScene()
    {
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
       

    void WaterTouch()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            drowningSFX.Play();
            myRigidbody.gravityScale = gravityMultiplier;
            myAnimator.SetTrigger("Drowning");
            isAlive = false;
            Invoke("ReloadScene", ReloadDelayWater);
        }
    }
}
