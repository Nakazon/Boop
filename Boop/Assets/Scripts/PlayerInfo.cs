using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    public string playerName = "";

    public static PlayerInfo Instance;

    void Awake()
    {
        if (Instance)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {
	}
}
