using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float fSpeedMovement, fTime;
    
    private Vector3 vTarget, vVelocity = Vector3.zero;
    private Rigidbody2D rPlayer;
	// Use this for initialization
	void Start () {
        rPlayer = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        //Obtain target
        if (Input.GetMouseButton(0))
        {
            vTarget = transform.position;
        }else if (Input.GetMouseButtonDown(1))
        {
            vTarget = getMousePositionInVector3();
        }

        //Move to the target
        if (transform.position != vTarget)
            rPlayer.MovePosition(Vector3.SmoothDamp(transform.position, vTarget, ref vVelocity, fTime, fSpeedMovement));
        
        //Vector3.MoveTowards(transform.position, vTarget, fSpeedMovement * Time.deltaTime)
        //transform.position = ;
    }

    Vector3 getMousePositionInVector3()
    {
        Vector3 vPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vPos.z = 10.0f;
        return vPos; 
    }

    public void setTarget(Vector3 vNewTarget)
    {
        vTarget = vNewTarget;
    }

}
