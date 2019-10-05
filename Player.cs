using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private GameMaster gameMaster;

    public class PlayerStats
    {
        public float Health = 100f;
    }

    public PlayerStats playerStats = new PlayerStats();

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if(playerStats.Health <= 0)
        {
            gameMaster.KillPlayer(this);
        }
    }
}
