using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    protected virtual void OnPlayerHit(PlayerController player) { }

    void OnTriggerEnter2D(Collider2D collider)
    {
       
        
            PlayerController Player = collider.GetComponent<PlayerController>();
            if (Player  != null)
            {
                OnPlayerHit(Player);
            }
        
    }

    public void CollectedHide()
    {
        Destroy(gameObject);
    }
}
