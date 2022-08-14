using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assgin : MonoBehaviour
{
    public GameObject player;
    public GameObject upgradeSystem;
    public Text upgradeText;

    private UPGRADE_OBJECTS UPGRADE_OBJECTS;
    private Sprite upgradeSprite;

    // Update is called once per frame
    void Update()
    {
        
    }// END OF UPDATE
    public void SetUpgrade(UPGRADE_OBJECTS upgradeToAssign)
    {
        UPGRADE_OBJECTS = upgradeToAssign;

        upgradeSprite = UPGRADE_OBJECTS.upgradeSprite;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = upgradeSprite;

        upgradeText.text = upgradeToAssign.name + "\n" + upgradeToAssign.description;
    }
}
