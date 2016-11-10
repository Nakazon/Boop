using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetName : MonoBehaviour {

    float delay = 2.5f;

	// Use this for initialization
	void Start () {
        NameCheck();
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PlayerPrefs.SetString("Player_Name", transform.FindChild("NameText").GetComponent<Text>().text);
            GameObject.Find("PlayerStats").GetComponent<PlayerInfo>().playerName = PlayerPrefs.GetString("Player_Name");
            StartCoroutine(NameSetText(delay, true));
            NameCheck();
        }else if(Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.LeftControl))
        {
            PlayerPrefs.SetString("Player_Name", "");
            //GameObject.Find("PlayerStats").GetComponent<PlayerInfo>().playerName = PlayerPrefs.GetString("Player_Name");
            transform.FindChild("NameText").transform.parent.GetComponent<InputField>().text = null;
            StartCoroutine(NameSetText(delay, false));
            NameCheck();
        }
    }

    void NameCheck()
    {
        if (PlayerPrefs.GetString("Player_Name") != null && PlayerPrefs.GetString("Player_Name").ToString() != "")
        {
            Debug.Log(PlayerPrefs.GetString("Player_Name"));
            transform.FindChild("NameText").transform.parent.GetComponent<InputField>().text = PlayerPrefs.GetString("Player_Name");
            GameObject.Find("UserNameText").GetComponent<Text>().text = "Welcome Back";
            GameObject.Find("PlayerStats").GetComponent<PlayerInfo>().playerName = PlayerPrefs.GetString("Player_Name");
        }
        else
        {
            GameObject.Find("UserNameText").GetComponent<Text>().text = "Username:";
        }
    }

    IEnumerator NameSetText(float fadeDelay, bool nameChanged)
    {
        Text textToModify = GameObject.Find("NameSetText").GetComponent<Text>();

        if (nameChanged)
            textToModify.text = "Name has been changed to: " + GameObject.Find("PlayerStats").GetComponent<PlayerInfo>().playerName.ToString() + ".";
        else
            textToModify.text = "Your username has been cleared!";

        yield return new WaitForSeconds(fadeDelay);

        textToModify.text = "";
    }
}
