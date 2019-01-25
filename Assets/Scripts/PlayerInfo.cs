using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
//using UnityEngine.Networking;
namespace Prototype.NetworkLobby{
    public class PlayerInfo : NetworkBehaviour {
	//[Header("Network")]
	//[Space]
	[SyncVar]
	public Color m_color;
	// Use this for initialization
	void Start () {
            Debug.Log("Length: " + GameObject.FindGameObjectsWithTag("lobbyPlayer").Length);
            foreach(var lobbyPlayer in GameObject.FindGameObjectsWithTag("lobbyPlayer")) {
                Debug.Log("$$$$$$$$");
                Debug.Log("netId:" + lobbyPlayer.GetComponent<NetworkIdentity>().netId);
                Debug.Log(lobbyPlayer.GetComponent<LobbyPlayer>().playerColor);
            }
            //m_color = MyGameManager.Instance.GetLobbyPlayer(gameObject).playerColor;
            //GetComponentInChildren<Renderer>().material.color = m_color;
            //GetComponentInChildren<Renderer>().material.color = MyGameManager.Instance.GetLobbyPlayer(gameObject).playerColor;
            Debug.Log("#####");
            Debug.Log(GetComponent<NetworkIdentity>().netId);
            Debug.Log(GameObject.FindGameObjectsWithTag("lobbyPlayer").Length);
            Debug.Log("-----");

            // GetComponent<Renderer>().material.color = m_color;
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
}

