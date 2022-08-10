using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataTest
{
    public string name;
    public float health;
    public float ammo;
    public float AttackPower;
    
    public PlayerDataTest(string name, float health, float ammo, float attackPower)
    {
        this.name = name;
        this.health = health;
        this.ammo = ammo;
        this.AttackPower = attackPower;
    }// CONSTRUCTOR

    public override string ToString()
    {
        return $"{name} is at {health} HP with {ammo} ammo";
    }
}// END OF CLASS
