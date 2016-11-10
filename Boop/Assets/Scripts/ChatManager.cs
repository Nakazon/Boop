using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Collections;

public class ChatManager : NetworkBehaviour {

    GameObject chat;

    Text messageToSentText;

    public GameObject chatGO;

	// Use this for initialization
	void Start () {
        chat = GameObject.Find("ChatContent");
        messageToSentText = GameObject.Find("ChatMessageText").GetComponent<Text>();
        Debug.Log(gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Return))
        {
            if (messageToSentText.text == "" || messageToSentText.text == " ")
                return;

            CmdCreateChatMessage(messageToSentText.text.ToString(), GameObject.Find("PlayerStats").GetComponent<PlayerInfo>().playerName, chatGO);
            GameObject.Find("Chat").transform.GetChild(1).GetChild(1).GetComponent<Text>().text = " ";
        }
	}

    [Command]
    void CmdCreateChatMessage(string message, string sender, GameObject prefab)
    {
        RpcCreateChatMessage(message, sender);
        

    }

    [ClientRpc]
    void RpcCreateChatMessage(string message, string sender)
    {
        Transform chatContent = GameObject.Find("PlayerUI").transform.GetChild(0).GetChild(0).GetChild(0);
        GameObject chatEntry = (GameObject)Instantiate(chatGO, chatContent, false);
        string time = ("[" + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + "] ");
        chatEntry.GetComponentInChildren<Text>().text = (time + sender + ": " + message);
        if(NetworkServer.active)
            NetworkServer.Spawn(chatEntry);
    }
}
