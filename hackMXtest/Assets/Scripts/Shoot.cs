using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class Shoot : NetworkBehaviour {

    

    public GameObject bullet;
    
    public Transform tSpawnBullets;

    void Start()
    {
        ClientScene.RegisterPrefab(bullet);
    }
    // Update is called once per frame
    void Update () {
        
        //Rotate game object
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
        //Fire!!
        if (Input.GetMouseButtonDown(0))
        {

            // Instantiate(bullet, tSpawnBullets.position, transform.rotation);
            callDispara();
        }

    }



    [Command]
    void CmdDispara(Vector3 vBulletSpawn, Quaternion qBulletRotSpawn)
    {
        GameObject gBullet = (GameObject)Instantiate(bullet, vBulletSpawn, qBulletRotSpawn);
      

        NetworkServer.Spawn(gBullet);
    }

    

    [ClientCallback]
    void callDispara()
    {
        if(isLocalPlayer)
        {
            CmdDispara(tSpawnBullets.position,transform.rotation);
        }
    }
}