using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSounds : MonoBehaviour
{
    public void SEBurn1()
    {
        AudioManager.instance.Play("flameOn");
    }

    public void SEBurn2()
    {
        AudioManager.instance.Play("flameIdle");
    }

    public void SEBurn2Off()
    {
        AudioManager.instance.Stop("flameIdle");
    }


    public void SEBurn3()
    {
        AudioManager.instance.Play("flameOff");
    }
}
