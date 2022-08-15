using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_PopUp_OnTriggerEnter : MonoBehaviour
{
    public Dialogue dialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueManager.instance.StartDialogue(dialogue);
        //FindObjectOfType<AudioManager>().Play("dead3");
        AudioManager.instance.Play("dead3");
    }
}
