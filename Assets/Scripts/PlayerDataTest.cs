using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataTest
{
  
    public string Name;
    public float health;
    public float ammo;
    public float AttackPower;

    public PlayerDataTest(string name, float health, float ammo, float attackPower)
    {
        this.Name = name;
        this.health = health;
        this.ammo = ammo;
        this.AttackPower = attackPower;

        //name = "Lao";
        //health = 500;
        //ammo = 100;
        //attackPower = 150;
    }// CONSTRUCTOR
   
    public override string ToString()
    {
        return $"{Name} is at {health} HP with {ammo} ammo with Attack Power {AttackPower}";
    }
}// END OF CLASS
