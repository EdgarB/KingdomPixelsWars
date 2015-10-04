using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class player_SyncPosition : NetworkBehaviour {
    [SyncVar]
    private Vector3 syncPosition;

    [SerializeField] Transform myTransform;
    [SerializeField] float lerpSpeed = 15;

    void Update()
    {
        LerpPosition();
    }
		
	void FixedUpdate ()
    {
        transmitPosition();          
	}

    void LerpPosition()
    {
        if(!isLocalPlayer)
        {
            myTransform.position = Vector3.Lerp(myTransform.position, syncPosition, Time.deltaTime * lerpSpeed);
        }

    }

    [Command]
    void CmdProvidePositionToServer(Vector3 vPosition)
    {
        syncPosition = vPosition;
    }

    [ClientCallback]
    void transmitPosition()
    {
        if(isLocalPlayer)
        {
            CmdProvidePositionToServer(myTransform.position);
        }
    }
    

}
