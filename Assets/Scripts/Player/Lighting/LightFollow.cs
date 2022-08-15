using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        transform.LookAt(player.transform);
    }
}
