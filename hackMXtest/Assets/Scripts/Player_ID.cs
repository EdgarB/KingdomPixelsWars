using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_ID : NetworkBehaviour {

	[SyncVar] public string playerUniqueIdentity;
    public Sprite sP1, sP2;
    private NetworkManager nManager;
	private NetworkInstanceId playerNetID;
	private Transform myTransform;

    

	public override void OnStartLocalPlayer ()
	{
		GetNetIdentity();
		SetIdentity();
	}

	// Use this for initialization
	void Awake () 
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(myTransform.name == "" || myTransform.name == "gPlayer(Clone)")
		{
			SetIdentity();
		}
	}

	[Client]
	void GetNetIdentity()
	{
		playerNetID = GetComponent<NetworkIdentity>().netId;
		CmdTellServerMyIdentity(MakeUniqueIdentity());
        
	}
	
	void SetIdentity()
	{
		if(!isLocalPlayer)
		{
			myTransform.name = playerUniqueIdentity;
		}
		else
		{
			myTransform.name = MakeUniqueIdentity();
		}
            

        if (myTransform.name == "Player 1")
        {
            GetComponent<SpriteRenderer>().sprite = sP1;
            this.transform.position = nManager.startPositions[1].position;
        } 
        else
        {
            GetComponent<SpriteRenderer>().sprite = sP2;
            this.transform.position = nManager.startPositions[0].position;
        }

    }

	string MakeUniqueIdentity()
	{
		string uniqueName = "Player " + playerNetID.ToString();
		return uniqueName;
	}

	[Command]
	void CmdTellServerMyIdentity(string name)
	{
		playerUniqueIdentity = name;
	}


}
