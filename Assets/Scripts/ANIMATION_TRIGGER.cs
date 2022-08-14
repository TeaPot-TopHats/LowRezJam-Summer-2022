using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANIMATION_TRIGGER : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayMainMenuAnimation()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GetComponent<Animator>().Play("PauseMenuAnimation");
        }
        
    }
}
