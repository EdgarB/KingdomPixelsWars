using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class player_NetworkSetup : NetworkBehaviour {

	// Use this for initialization
	void Start ()
    {
	    if(isLocalPlayer)
        {
            //GameObject.Find("Scene Camera").SetActive(true);
            GetComponent<Rigidbody2D>().
            GetComponent<playerMovement>().enabled = true;
            GetComponent<Shoot>().enabled = true;
            //GetComponent<playerRotation>().enabled = true;

        }
	}
	
	
}
