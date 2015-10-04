using UnityEngine;
using System.Collections;

public class bullet_Collisions : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D cOther)
    {
        if(cOther.tag == "Bullet")
        {
            Destroy(gameObject);
        }else if(cOther.tag == "Player")
        {
            Debug.Log("OP!!!!!!!");
        }
    }
}
