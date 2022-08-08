using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOVER_TEXT_MANAGER : MonoBehaviour
{
    public Transform PopupText;
    public static bool TextStatus;

    
    /**
     * A method that check the text status and instantiate a pop up when highlighted
     * if false 
     * Show pop up
     * Instantiate pop up text position and rotation.
     */
    private void OnMouseEnter()
    {
        if (TextStatus == false)
        {

            PopupText.GetComponent<TextMesh>().text = "Tex\ntest\n500";
            TextStatus = true;
            Instantiate(PopupText, new Vector3(transform.position.x, transform.position.y+2,0), PopupText.rotation);
        }// end of if statement 
    }// end of OnMouseEnter

    /**
     * A Method to set the text status to false when mouse is exiting the object highlighted.
     */
    private void OnMouseExit()
    {
        if(TextStatus == true)
        {
            TextStatus = false;
        }
    }// end of OnMouseExit
}// end of class
