using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {
    protected override void OnPlayerHit(PlayerController player) {
        // LevelController.current.onPlayerDeath(player);
        player.makeinvincible();
        CollectedHide();
    }
}
