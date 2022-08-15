using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNewMusic2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("song1");
        AudioManager.instance.Stop("Theme");
    }

  
}
