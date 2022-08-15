using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public EnemySensors EnemySensors;
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

    public void Attack()
    {
        Debug.Log(EnemySensors.Player);
        Debug.Log(EnemySensors.Player.GetComponent<PlayerController>());
        EnemySensors.Player.GetComponent<PlayerController>().Attacked();
    }
    public void Attacked()
    {

    }

    public void Burning()
    {

    }
}
