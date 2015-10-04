using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class player_SyncRotation : NetworkBehaviour
{
    [SyncVar]
    private Quaternion syncRotation;

    [SerializeField] Transform myTransform;


    void Update()
    {
        setRotation();
    }

    void FixedUpdate()
    {
        transmitRotation();
    }

    void setRotation()
    {
        if (!isLocalPlayer)
        {
            myTransform.rotation = syncRotation;
        }

    }

    [Command]
    void CmdProvideRotationToServer(Quaternion qRotation)
    {
        syncRotation = qRotation;
    }

    [ClientCallback]
    void transmitRotation()
    {
        if (isLocalPlayer)
        {
            CmdProvideRotationToServer(myTransform.rotation);
        }
    }


}