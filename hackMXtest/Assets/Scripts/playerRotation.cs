using UnityEngine;
using System.Collections;

public class playerRotation : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
