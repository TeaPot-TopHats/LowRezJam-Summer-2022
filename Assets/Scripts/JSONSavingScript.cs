using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    //    PlayerDataTest = new PlayerDataTest(PlayerDataTest.name, PlayerDataTest.health, PlayerDataTest.ammo, PlayerDataTest.AttackPower );
    }// END OF CREATEPLAYERDATA

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SavaData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavaData.json";

    }// END OF SETPATHS

    public void SavaData()
    {
        string savaPath = persistentPath; // set saving path to path

        Debug.Log("Saving Data at "+ savaPath);

        string json = JsonUtility.ToJson(PlayerDataTest); // wrting the data to json file
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savaPath); // steaming the save data to a file
        writer.Write(json);

        Debug.Log("Saving has been successful");
    }// END OF SAVADATA

    public void LoadData()
    {
        Debug.Log("Loading Data From: " + persistentPath);

        using StreamReader reader = new StreamReader(persistentPath); // load data from saved path
        string json = reader.ReadToEnd(); // tell json to read
        PlayerDataTest data = JsonUtility.FromJson<PlayerDataTest>(json); 
        Debug.Log(data.ToString());

        Debug.Log("Loadng has been successful");
    }
}// END OF CLASS
