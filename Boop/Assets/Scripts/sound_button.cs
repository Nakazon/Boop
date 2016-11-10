using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class sound_button : NetworkBehaviour
{
    [SyncVar]
    public int index;
}
