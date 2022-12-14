using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    public static DialogueManager instance { get; private set; }

    private void Awake()
    {
        instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        
        dialogueText.text = string.Empty;
        sentences = new Queue<string>(); 
    }// end of start

    public void StartDialogue(Dialogue dialogue)
    {
        FindObjectOfType<PauseMenu>().UnlockMouseCursor();

        animator.SetBool("IsOpen", true);
        Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;
        Debug.Log(sentences);
        Debug.Log("OH SHIT");
         sentences.Clear();
        Debug.Log("OH FUCK");

        foreach (string sentence in dialogue.sentences)
        {
            Debug.Log(sentences);
            sentences.Enqueue(sentence);
            Debug.Log(sentences);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
         string sentence = sentences.Dequeue();
         StopAllCoroutines();
         StartCoroutine(TypeSentence(sentence));
         

         Debug.Log(sentence);
    }// end of Display next Sentence

    IEnumerator TypeSentence (string sentence)
    {
        float i = 0.01f;
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(i);
        }
    }

   void EndDialogue()
    {
        FindObjectOfType<PauseMenu>().LockMouseCursor();
        animator.SetBool("IsOpen", false);
         
       // Debug.Log("End Of Conversation");
    }
}
