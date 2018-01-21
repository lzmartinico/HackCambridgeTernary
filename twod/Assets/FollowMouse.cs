using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var sens = 100;
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(pos);
        var dir = (pos - transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(dir*sens);


        //GetComponent<Rigidbody>().velocity = ((transform.right * mouseMovement.x) + (transform.forward * mouseMovement.y)) / Time.deltaTime;
    }

    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Head")
        {
            Debug.Log("AAAAAGGGGGHHHHHHH");
            var damage =  GetComponent<Rigidbody2D>().velocity.magnitude * GetComponent<Rigidbody2D>().mass / Time.deltaTime;
            Debug.Log(damage);
        }
    }
    */
}
