using UnityEngine;
using System.Collections;

public class Destroy_After_Sound_Complete : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    float timer = 0;
    public float max_dur = 3;
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
	    if(!GetComponent<AudioSource>().isPlaying || timer >= max_dur)
        {
            Destroy(this.gameObject);
        }
	}
}
