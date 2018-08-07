using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class Coin : Collectable
    {
        protected override void OnPlayerHit(PlayerController player )
        {
          // LevelController.current.addCoins(1);
            CollectedHide();
        }
    }
