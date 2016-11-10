using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class SetNameText : NetworkBehaviour {

    [SyncVar] public string playerName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playerName = GameObject.Find("PlayerStats").GetComponent<PlayerInfo>().playerName;
        CmdSetNameText(playerName, GetComponent<NetworkIdentity>().netId);
	}

    [Command]
    void CmdSetNameText(string name, NetworkInstanceId playerID)
    {
        RpcSetNameText(name, playerID);
    }

    [ClientRpc]
    void RpcSetNameText(string name, NetworkInstanceId playerID)
    {
        GameObject player = ClientScene.FindLocalObject(playerID);
        player.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = name;
    }
}
