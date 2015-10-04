using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class player_DeathManager : NetworkBehaviour
{

    private player_healthManager healthScript;
    //private Image crossHairImage;


    public override void PreStartClient()
    {
        healthScript = GetComponent<player_healthManager>();
        healthScript.EventDie += DisablePlayer;
    }

    public override void OnStartLocalPlayer()
    {
        //crossHairImage = GameObject.Find("Crosshair Image").GetComponent<Image>();
    }

    public override void OnNetworkDestroy()
    {
        healthScript.EventDie -= DisablePlayer;
    }

    void DisablePlayer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        
        /*
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in renderers)
        {
            ren.enabled = false;
        }
        */
        healthScript.isDead = true;

        if (isLocalPlayer)
        {
            GetComponent<Shoot>().enabled = false;
            GetComponent<playerMovement>().enabled = false;
            //crossHairImage.enabled = false;
            //GameObject.Find("GameManager").GetComponent<GameManager_References>().respawnButton.SetActive(true);
        }
    }
}
