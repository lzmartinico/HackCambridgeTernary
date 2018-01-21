using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityStandardAssets.CrossPlatformInput;


public class NetworkServerUI : MonoBehaviour {

    public short port;

    CrossPlatformInputManager.VirtualAxis m_LHVAxis;
    CrossPlatformInputManager.VirtualAxis m_LVVAxis;
    string LhorizontalAxisName = "LHorizontal";
    string LverticalAxisName = "LVertical";

    CrossPlatformInputManager.VirtualAxis m_RHVAxis;
    CrossPlatformInputManager.VirtualAxis m_RVVAxis;
    string RhorizontalAxisName = "RHorizontal";
    string RverticalAxisName = "RVertical";

    void OnGUI()
    {
        string ipaddress = Network.player.ipAddress;
        GUI.Box(new Rect(10+100*(port-25000), Screen.height - 50, 100, 50), ipaddress);
        GUI.Label(new Rect(20 + 100 * (port - 25000), Screen.height - 35, 100, 20), "Status:" + NetworkServer.active);
        GUI.Label(new Rect(20 + 100 * (port - 25000), Screen.height - 20, 100, 20), "Connected:" + NetworkServer.connections.Count);
    }

	// Use this for initialization
	void Start () {
        m_LHVAxis = new CrossPlatformInputManager.VirtualAxis(LhorizontalAxisName);
        CrossPlatformInputManager.RegisterVirtualAxis(m_LHVAxis);
        m_LVVAxis = new CrossPlatformInputManager.VirtualAxis(LverticalAxisName);
        CrossPlatformInputManager.RegisterVirtualAxis(m_LVVAxis);

        m_RHVAxis = new CrossPlatformInputManager.VirtualAxis(RhorizontalAxisName);
        CrossPlatformInputManager.RegisterVirtualAxis(m_RHVAxis);
        m_RVVAxis = new CrossPlatformInputManager.VirtualAxis(RverticalAxisName);
        CrossPlatformInputManager.RegisterVirtualAxis(m_RVVAxis);

        NetworkServer.Listen(25000);

        NetworkServer.RegisterHandler(888, registerhandler1);
        NetworkServer.RegisterHandler(889, registerhandler2);
        NetworkServer.RegisterHandler(890, registerhandler3);
        NetworkServer.RegisterHandler(891, registerhandler4);

    }

    private void ServerReceiveMessage(NetworkMessage message, int port)
    {
        StringMessage msg = new StringMessage();
        msg.value = message.ReadMessage<StringMessage>().value;

        string[] deltas = msg.value.Split('|');
        if (deltas[0].Equals("Left"))
        {
            m_LHVAxis.Update(Convert.ToSingle(deltas[1]));
            m_LVVAxis.Update(Convert.ToSingle(deltas[2]));

            OurHack.setLH(Convert.ToSingle(deltas[1]), port);
            OurHack.setLV(Convert.ToSingle(deltas[2]), port);
        }
        else
        {
            m_RHVAxis.Update(Convert.ToSingle(deltas[1]));
            m_RVVAxis.Update(Convert.ToSingle(deltas[2]));

            OurHack.setRH(Convert.ToSingle(deltas[1]), port);
            OurHack.setRV(Convert.ToSingle(deltas[2]), port);
        }
    }

    private void registerhandler1(NetworkMessage message)
    {
        ServerReceiveMessage(message, 25000);
    }

    private void registerhandler2(NetworkMessage message)
    {
        ServerReceiveMessage(message, 25001);
    }

    private void registerhandler3(NetworkMessage message)
    {
        ServerReceiveMessage(message, 25002);
    }

    private void registerhandler4(NetworkMessage message)
    {
        ServerReceiveMessage(message, 25003);
    }


    // Update is called once per frame
    void Update () {
        
	}
}
