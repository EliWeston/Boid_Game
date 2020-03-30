using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoidCollider : MonoBehaviour
{

    public GameObject AIBoidObject;

    private void Awake()
    {
        Debug.Log(AIBoidObject);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Boid":
                break;
            default:
                CheckunTaggedCollision(other);
                break;
        }
    }
   
    private void CheckunTaggedCollision(Collider other)
    {
        EnemyCollision();
    }

    //Destroy the player and set the the curren state to the dead state.
    private void EnemyCollision()
    {//GameUIManager.Instance.GameOver(gameObject);
        BoidsManager.Instance.RemoveBoid(AIBoidObject);
        Destroy(AIBoidObject);
    }
}
