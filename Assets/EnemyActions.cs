using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Rigidbody2D Rigid, Vector2 moveDirection, float speed)
    {
        Rigid.velocity = moveDirection * speed;
    }

    public void Attack(Collider2D target)
    {
        Debug.Log("Slime attacking player");
        //target.GetComponent<PlayerController>().Attacked();
    }

    public void Attacked()
    {

    }
}
