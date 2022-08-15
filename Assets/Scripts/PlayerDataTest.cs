using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerDataTest
{

    [SerializeField] public string Name;
    [SerializeField] public float health;
    [SerializeField] public float ammo;
    [SerializeField] public float AttackPower;

    public PlayerDataTest(string name, float health, float ammo, float attackPower)
    {
        this.Name = name;
        this.health = health;
        this.ammo = ammo;
        this.AttackPower = attackPower;

        //PlayerPrefs.SetString("name", name);
        //PlayerPrefs.SetFloat("health", health);
        //PlayerPrefs.SetFloat("ammo", ammo);
        //PlayerPrefs.SetFloat("attackpower", attackPower);

    }// CONSTRUCTOR



    public override string ToString()
    {
        return $"{Name} is at {health} HP with {ammo} ammo with Attack Power {AttackPower}";
    }
}// END OF CLASS
