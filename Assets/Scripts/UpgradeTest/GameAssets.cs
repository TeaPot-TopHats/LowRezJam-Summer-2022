using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
  private static GameAssets s_Instance;
    public static GameAssets Instance {
        get {
            if (s_Instance == null) s_Instance = (Instantiate(Resources.Load<GameAssets>("GameAssets")));
            return s_Instance; 
        }// END OF GET
    }// END OG GAMEASSEST ISNTANCE

    public Sprite Amogus;
}// END OF CLASS
