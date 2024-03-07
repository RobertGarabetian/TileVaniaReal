using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    //EnemyMovement enemyMovementReference = GameObject.Find("Scorpo").GetComponent<EnemyMovement>();
    GameObject canvas = GameObject.Find("MenuCanas");
    //public float slowSpeed = 0.5f;
    //public float hardSpeed = 10f;

    public void Easy()
    {
        SceneManager.LoadScene(1);
        //enemyMovementReference.moveSpeed = slowSpeed;
        if(canvas != null)
        {
           Destroy(canvas); 
        }
    }

   public void Medium()
    {
        SceneManager.LoadScene(3);
        //enemyMovementReference.moveSpeed = 0.5f;
        if(canvas != null)
        {
           Destroy(canvas); 
        }
    }

   public void Hard()
   {
        SceneManager.LoadScene(6);
        //enemyMovementReference.moveSpeed = hardSpeed;
        if(canvas != null)
        {
           Destroy(canvas); 
        }
    }
}
