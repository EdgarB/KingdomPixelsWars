using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class player_Collisions : NetworkBehaviour {

    

	void OnTriggerEnter2D(Collider2D cOther)
    {
        Debug.Log("Entro");
        if (cOther.tag == "Player")
        {
            Debug.Log("Kill him!!!!!!!!!");
            killPlayer(cOther.name);
            /*disableEverything();
            sendToSpawn();
            enableEverything();*/
            
        }

        destroyBullet();
    }
    /*
    void disableEverything()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<playerMovement>().enabled = false;
        GetComponent<Shoot>().enabled = false;
    }

    void enableEverything()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<playerMovement>().enabled = true;
        GetComponent<Shoot>().enabled = true;
    }

    void sendToSpawn()
    {
        if (gameObject.name == "Player 1")
            transform.position = tSpawn1.position;
        else if (gameObject.name == "Player 2")
            transform.position = tSpawn2.position;
        else
            Debug.Log("There is no spawn for that name");
    }
    */
    void killPlayer(string sName)
    {
        Debug.Log("Kill " +sName);
        CmdTellServerWhoWasShot(sName, 1);
    }

    void destroyBullet()
    {
        CmdDestroyGameObject(gameObject);
    }

    [Command]
    void CmdTellServerWhoWasShot(string uniqueID, int dmg)
    {
        GameObject go = GameObject.Find(uniqueID);
        go.GetComponent<player_healthManager>().DeductHealth(dmg);
    }

    [Command]
    void CmdDestroyGameObject(GameObject gB)
    {
        Network.Destroy(gB);
    }
}
