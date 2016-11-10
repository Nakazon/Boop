using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class UseButton : NetworkBehaviour {
    public LayerMask lm;
    public GameObject soundmanager_go, soundObject;
    public soundManager sm;

    [Range(0f, 1f)]
    public float volume = 0f;

    // Files / Scripts > FileName or File_Name
    // Variables > variableName

	// Use this for initialization
	void Start ()
    {
        soundmanager_go = GameObject.Find("SoundManager");
        sm = soundmanager_go.GetComponent<soundManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            Vector2 mouse_pos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mouse_pos, Vector2.zero, Mathf.Infinity, lm);
            if (hit)
            {
                int index = hit.transform.gameObject.GetComponent<sound_button>().index;
                CmdPressButton(index, soundmanager_go.GetComponent<NetworkIdentity>().netId);
            }
        }
	}

    [Command]
    void CmdPressButton(int index, NetworkInstanceId soundmanager_id)
    {
        RpcPressButton(index, soundmanager_id);
    }

    [ClientRpc]
    void RpcPressButton(int index, NetworkInstanceId soundmanager_id)
    {
        GameObject sound_manager = ClientScene.FindLocalObject(soundmanager_id);
        GameObject temp_sound_go = Instantiate(soundObject,Vector3.zero,Quaternion.identity) as GameObject;
        temp_sound_go.GetComponent<AudioSource>().clip = sound_manager.GetComponent<soundManager>().sounds[index];
        temp_sound_go.GetComponent<AudioSource>().Play();
        temp_sound_go.GetComponent<AudioSource>().volume = volume;
    }
}


