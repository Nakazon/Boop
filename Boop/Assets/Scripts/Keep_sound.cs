using UnityEngine;
using System.Collections;

public class Keep_sound : MonoBehaviour {

    static Keep_sound _instance;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
