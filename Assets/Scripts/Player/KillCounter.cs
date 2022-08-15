using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text killText;

    private JSONSavingScript data;
    private PlayerController playerController;

    private void Start()
    {
      // data = GameObject.FindGameObjectWithTag("Player").GetComponent<JSONSavingScript>();

    }
    private void Update()
    {
        
      
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<JSONSavingScript>() != null)
            {
                data = GameObject.FindGameObjectWithTag("Player").GetComponent<JSONSavingScript>();
            }
        
        
        KeepKillCount();
    }
    public void KeepKillCount()
    {
        killText.text = data.myplayer.killCount.ToString();
    }

    public void ResetKillCount()
    {
        playerController.StartUp();
        data.myplayer.killCount = 0;
    }

}
