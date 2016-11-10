using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkScriptManager : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	    if(isLocalPlayer)
        {
            GetComponent<PlayerMove>().enabled = true;
            GetComponent<ChatManager>().enabled = true;
            GetComponent<SetNameText>().enabled = true;
            GetComponent<UseButton>().enabled = true;
        }
	}
	
	
}
