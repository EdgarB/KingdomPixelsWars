using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class player_RespawnManager : NetworkBehaviour
{
    [SerializeField] string nameObjectSpawn1 = "Spawn1";
    [SerializeField] string nameObjectSpawn2 = "Spawn2";

    private player_healthManager healthScript;
    //private Image crossHairImage;


    void Update()
    {
        checkForRespawn();
    }

    public override void PreStartClient()
    {
        healthScript = GetComponent<player_healthManager>();
        healthScript.EventRespawn += EnablePlayer;
    }

    public override void OnStartLocalPlayer()
    {
        //crossHairImage = GameObject.Find("Crosshair Image").GetComponent<Image>();
        //SetRespawnButton();
    }
    /*
    void SetRespawnButton()
    {
        if (isLocalPlayer)
        {
            respawnButton = GameObject.Find("GameManager").GetComponent<GameManager_References>().respawnButton;
            respawnButton.GetComponent<Button>().onClick.AddListener(CommenceRespawn);
            respawnButton.SetActive(false);
        }
    }
    */
    public override void OnNetworkDestroy()
    {
        healthScript.EventRespawn -= EnablePlayer;
    }

    void EnablePlayer()
    {
        GetComponent<SpriteRenderer>().enabled = true;
       
        
        GetComponent<BoxCollider2D>().enabled = true;
        /*
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in renderers)
        {
            ren.enabled = true;
        }
        */
        if (isLocalPlayer)
        {
            GetComponent<Shoot>().enabled = true;
            GetComponent<playerMovement>().enabled = true;
            //crossHairImage.enabled = true;
            //respawnButton.SetActive(false);
        }
    }

    void checkForRespawn()
    {
        if (isLocalPlayer && healthScript.isDead)
        {
            CommenceRespawn();
        }
    }

    void CommenceRespawn()
    {
        CmdRespawnOnServer();
    }

    [Command]
    void CmdRespawnOnServer()
    {
        /*
        Vector3 vSpawn;
        if (gameObject.name == "Player 1")
        {
            vSpawn = GameObject.Find(nameObjectSpawn1).transform.position;
            vSpawn.z = 10.0f;
            gameObject.transform.position = vSpawn;

        }
        else if (gameObject.name == "Player 2")
        {
            vSpawn = GameObject.Find(nameObjectSpawn2).transform.position;
            vSpawn.z = 10.0f;
            gameObject.transform.position = vSpawn;
        }
        else
        */
        //vSpawn = Vector3.zero;
        //Debug.Log("Spawn: " + vSpawn);
        //GetComponent<playerMovement>().setTarget(vSpawn);
            

        healthScript.ResetHealth();
    }
}
