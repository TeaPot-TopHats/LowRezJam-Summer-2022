using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public static class test2
{
    public static void Init()
    {
        Debug.Log("test2.Init");
        CreateSprite(GameAssets.Instance.Amogus);
    }

    private static void CreateSprite(Sprite sprite)
    {
        UtilsClass.CreateWorldSprite("Sprite", sprite, Vector3.zero, new Vector3(20, 20), 0, Color.white);
    }
}
