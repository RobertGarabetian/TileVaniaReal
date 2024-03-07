using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioSource coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    float delay = 0.5f;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            coinPickupSFX.Play();
            Invoke("Destroy",delay);
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
