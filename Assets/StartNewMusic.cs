using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNewMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("song2");
        AudioManager.instance.Stop("song1");
    }

}
