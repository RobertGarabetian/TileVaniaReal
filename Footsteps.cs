using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    CircleCollider2D myFeetCollider;
    public AudioSource runningSound;

    void Start()
    {
        myFeetCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;}
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0  )
        {
            if (!runningSound.isPlaying)
            {
                runningSound.Play();
            }
        }
        else
        {
            runningSound.Stop();
        }
    }
}
