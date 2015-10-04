using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class bullet_SyncRotation : NetworkBehaviour {
    [SyncVar] private Quaternion syncRotation;

    private Transform thisTransform;
   
	// Use this for initialization
	void Start () {
        thisTransform = GetComponent<Transform>();
        
        //Debug.Break();
	}
	

    void FixedUpdate()
    {
        transmitRotation();
        setRotation();
    }

    void setRotation()
    {
        if(!isServer)
        {
            thisTransform.localRotation = syncRotation;
        }
    }

    [Command]
    void CmdProvideRotationOfSingleBulletToServer(Quaternion qRotation)
    {
        syncRotation = qRotation;
    }

    [ClientCallback]
    void transmitRotation()
    {
        if (isServer)
        {
            CmdProvideRotationOfSingleBulletToServer(thisTransform.rotation);
        }
    }
}
