using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Control : MonoBehaviour {

    public Vector2 reltarget = new Vector2(0.0f,0.0f);

    [Range(0, 200)]

    private float sens = OurHack.sens;

    public int port;


    CrossPlatformInputManager.VirtualAxis m_LHVAxis;
    CrossPlatformInputManager.VirtualAxis m_LVVAxis;
    string LhorizontalAxisName = "LHorizontal";
    string LverticalAxisName = "LVertical";

    CrossPlatformInputManager.VirtualAxis m_RHVAxis;
    CrossPlatformInputManager.VirtualAxis m_RVVAxis;
    string RhorizontalAxisName = "RHorizontal";
    string RverticalAxisName = "RVertical";


    // Use this for initialization
    void Start () {
        /*m_LHVAxis = new CrossPlatformInputManager.VirtualAxis(LhorizontalAxisName);
        CrossPlatformInputManager.RegisterVirtualAxis(m_LHVAxis);
        m_LVVAxis = new CrossPlatformInputManager.VirtualAxis(LverticalAxisName);
        CrossPlatformInputManager.RegisterVirtualAxis(m_LVVAxis);

        m_RHVAxis = new CrossPlatformInputManager.VirtualAxis(RhorizontalAxisName);
        CrossPlatformInputManager.RegisterVirtualAxis(m_RHVAxis);
        m_RVVAxis = new CrossPlatformInputManager.VirtualAxis(RverticalAxisName);
        CrossPlatformInputManager.RegisterVirtualAxis(m_RVVAxis);*/
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name=="Left Fist" || gameObject.name == "Left Fist (1)")
        {
            //Debug.Log("Left");
            //Debug.Log(CrossPlatformInputManager.GetAxis("LHorizontal"));
            //GameObject nm = GameObject.Find("/NetworkManager");
            //var nsui = nm.GetComponent<NetworkServerUI>();
            //Debug.Log(reltarget);
            reltarget = new Vector2(OurHack.getLH(port), OurHack.getLV(port));
            //reltarget = new Vector2(CrossPlatformInputManager.GetAxis("LHorizontal"), CrossPlatformInputManager.GetAxis("LVertical")) * 10000;

        }
        else
        {
            //Debug.Log("Right");
            reltarget = new Vector2(OurHack.getRH(port), OurHack.getRV(port));
            //reltarget = new Vector2(CrossPlatformInputManager.GetAxis("RHorizontal"), CrossPlatformInputManager.GetAxis("RVertical"))*10000;
        }
        //Debug.Log(reltarget);
        //transform.Translate(reltarget);
        GetComponent<Rigidbody2D>().AddForce(reltarget.normalized * sens);
        //Debug.Log(reltarget);
    }
}
