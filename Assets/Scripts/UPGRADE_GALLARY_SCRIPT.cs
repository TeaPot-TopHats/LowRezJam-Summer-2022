using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPGRADE_GALLARY_SCRIPT : MonoBehaviour
{
    public Sprite[] UpgradesImage; // store all your image in here 
    public Image displayImage; // The current image that is visiable
    public Button nextImg; // A button to view the next image
    public Button prevImg; // A button to view the previous image
    public int i; // A controler of where are you in the array of iamges

    public void NextBtn()
    {
        if(i < UpgradesImage.Length)
        {
            Debug.Log("Image Number is: " + i);
            i++;
            prevImg.interactable = true;
            if (i < UpgradesImage.Length)
            {
                
                nextImg.interactable = true;
            }
            else
            {
                i--;
                nextImg.interactable = false;
            }
        }// end of if statement
    }// end of next Btn

    public void PrevBtn()
    {
        if(i > 0)
        {
            Debug.Log("Image Number is: " + i);
            i--;
            nextImg.interactable = true;
            if (i > 0)
            {
                prevImg.interactable = true;
            }
            else
            {
                prevImg.interactable = false;
            }
            
        }// end of ifstatement 

    }// end of PrevBtn
    public void Update()
    {
        displayImage.sprite = UpgradesImage[i];
        

    }
    public void Start()
    {
        //Debug.Log("Image Number is: " + i);
        i = 0;
    }
}// END OF CLASS
