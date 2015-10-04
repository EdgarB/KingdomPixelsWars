using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.up * 0.2f);
	}
}
