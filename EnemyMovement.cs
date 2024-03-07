using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    
    Rigidbody2D myRigidbody;
    

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        myRigidbody.velocity = new Vector2 (moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2 (-(-Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }

    public void EasyMoveSpeed()
    {
        moveSpeed = 0.5f;
    }
    //public void MediumMoveSpeed()
    //{
     //       moveSpeed = 3f;
    //}
    //public void HardMoveSpeed()
    //{
     //       moveSpeed = 5f;
    //}
}
