using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class soundManager : NetworkBehaviour {

    public AudioClip[] sounds; //A list of our sounds
    public AudioSource main_audio; //The audio source that plays a clip.



	// Use this for initialization
	void Start ()
    {
        main_audio = GetComponent<AudioSource>(); //Grabbing a reference to the audiosource that is on our GameObject
    }

    [Command]
    void CmdWhatever(int i, NetworkInstanceId soundManagerID)
    {
        RpcWhatever(i, soundManagerID);
        Debug.LogWarning("CMD");
    }

    [ClientRpc]
    void RpcWhatever(int i, NetworkInstanceId soundManagerID)
    {
        GameObject soundManager = ClientScene.FindLocalObject(soundManagerID);

        soundManager.GetComponent<soundManager>().main_audio.clip = sounds[i];
        soundManager.GetComponent<soundManager>().play_sound();

        Debug.LogWarning("RPC");
    }

    public void SetSound(int i)
    {
        Debug.LogWarning("void");
        CmdWhatever(i, GetComponent<NetworkIdentity>().netId);
    }

    public void play_sound()
    {
        main_audio.Play();
    }

}
