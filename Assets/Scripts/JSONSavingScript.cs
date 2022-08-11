using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class JSONSavingScript : MonoBehaviour
{
    private PlayerDataTest PlayerDataTest;
 

    private string path = "";
    private string persistentPath = "";
    // Start is called before the first frame update

    void Start()
    {
        CreatePlayerData();
        SetPaths();
    }// END OF START

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavaData();
            
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadData();
            
        }
    }// END OF UPDATE
    /**
     * creater a player data in this method.
     * this is making a new instant of player data and currently has 4 arguments player {name, health, ammo, attack power} more can be adding 
     * this is only a test data change it to the actuall player data later on. 
     */
    private void CreatePlayerData()
    {
         PlayerDataTest = new PlayerDataTest("Sussy", 666, 666, 666);
        // PlayerDataTest = new PlayerDataTest(player.Name, player.health, player.ammo, player.attactPower);
      
        // PlayerDataTest.Name = "wow";

    }// END OF CREATEPLAYERDATA

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SavaData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavaData.json";

    }// END OF SETPATHS

    public void SavaData()
    {
        string savaPath = path; // set saving path to path

        Debug.Log("---------------------" 
            + "Saving Data at "+ savaPath 
            + "---------------------");

        string json = JsonUtility.ToJson(PlayerDataTest); // wrting the data to json file
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savaPath); // steaming the save data to a file
        writer.Write(json);

        Debug.Log("---------------------\n" + 
            "Saving has been successful\n"
            + "---------------------");
    }// END OF SAVADATA

    public void LoadData()
    {
        
        Debug.Log("---------------------\n" 
                  + "Loading Data From: \n" + path
                  + "---------------------");

        using StreamReader reader = new StreamReader(path); // load data from saved path
        string json = reader.ReadToEnd(); // tell json to read
        PlayerDataTest data = JsonUtility.FromJson<PlayerDataTest>(json); 
        Debug.Log(data.ToString());
        Debug.Log(data.ammo);
        
        
        Debug.Log("---------------------\n" +
            "Loadng has been successful\n"
            +"---------------------------\n");
    }
}// END OF CLASS
