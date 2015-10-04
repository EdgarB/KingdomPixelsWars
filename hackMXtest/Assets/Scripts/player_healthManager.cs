using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class player_healthManager : NetworkBehaviour
{

    [SyncVar(hook = "OnHealthChanged")]
    private int health = 1; //If equal to 1 is alive if not is death
    
    private bool shouldDie = false;
    public bool isDead = false;

    public delegate void DieDelegate();
    public event DieDelegate EventDie;

    public delegate void RespawnDelegate();
    public event RespawnDelegate EventRespawn;

    

    // Update is called once per frame
    void Update()
    {
        CheckCondition();
    }

    void CheckCondition()
    {
        if (health <= 0 && !shouldDie && !isDead)
        {
            shouldDie = true;
        }

        if (health <= 0 && shouldDie)
        {
            if (EventDie != null)
            {
                EventDie();
            }

            shouldDie = false;
        }

        if (health > 0 && isDead)
        {
            if (EventRespawn != null)
            {
                EventRespawn();
            }

            isDead = false;
        }
    }

   

    public void DeductHealth(int dmg)
    {
        health -= dmg;
    }

    void OnHealthChanged(int hlth)
    {
        health = hlth;
        
    }

    public void ResetHealth() //Called Player_Respawn
    {
        health = 1;
    }

}
