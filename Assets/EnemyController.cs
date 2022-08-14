using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemySensors EnemySensors;
    [SerializeField] private EnemyActions EnemyActions;
    [SerializeField] private EnemyAnimator EnemyAnimator;
    [SerializeField] private Rigidbody2D Rigid;
    [SerializeField] private Collider2D Target;
    [SerializeField] private Transform Transform;
    [SerializeField] private Vector2 MoveDirection;
    [SerializeField] private bool alive;
    [SerializeField] private bool attacked;
    [SerializeField] private bool moving;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float startAttackTimer;
    [SerializeField] private float startWanderTimer;
    [SerializeField] private float timer;
    [SerializeField] private int attackWaitTime;
    [SerializeField] private int wanderWaitTime; 


    private void Start()
    {
        Debug.Log(1);
        StartCoroutine(Patroling());
    }

    /*private IEnumerator Patroling()
    {
        while (alive)
        {
            Debug.Log("sad");
            yield return null;
        }
        yield return null;
    }*/

    private void Update()
    {

        if (Rigid.velocity != new Vector2(0, 0))
            moving = true;
        else
            moving = false;
    }

    private void FixedUpdate()
    {
        EnemyAnimator.CheckFlip(Rigid, Transform);
        EnemyAnimator.MovementRender(moving);
    }

    private IEnumerator Patroling()
    {
        while (alive)
        {
            Debug.Log(2);
            if (!EnemySensors.seePlayer)
            {
                Debug.Log(4);
                yield return Wander();
            }
            else
            {
                Debug.Log(5);
                yield return Chasing();

            }
            yield return null;
        }
            
        yield return Dead();

    }

    private IEnumerator Wander()
    {
        timer = startWanderTimer;
        MoveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        while(timer > 0)
        {
            Debug.Log(3);
            if (!alive)
                yield return Dead();
            EnemyActions.Move(Rigid, MoveDirection, moveSpeed);
            if (EnemySensors.seePlayer)
                yield break;
            timer -= Time.deltaTime;
            yield return null;
        }
        Debug.Log(7);
        yield return Idle();
    }

    private IEnumerator Idle()
    {
        EnemyActions.Move(Rigid, MoveDirection, 0);
        if (!alive)
            yield return Dead();
        if (EnemySensors.seePlayer)
            yield break;

        yield return new WaitForSeconds(wanderWaitTime);
    }

    private IEnumerator Chasing()
    {
        while (EnemySensors.seePlayer)
        {
            if (!alive)
                yield return Dead();
            if (EnemySensors.canAttack)
            {
                if(Target == null)
                    Target = EnemySensors.recordTarget();
                else 
                    yield return Attacking();
            }
            else
                EnemyActions.Move(Rigid, EnemySensors.TargetPosition -transform.position, moveSpeed);
            yield return null;
        }
        yield return null;
    }

    private IEnumerator Attacking()
    {
        timer = startAttackTimer;
        while(timer > 0)
        {
            if (!alive)
                yield return Dead();
            //trigger anim
            if(timer < .5 * startAttackTimer && !attacked)
            {
                EnemyAnimator.AttackAnim();
                EnemyActions.Attack(Target);
                //do damage to area
                attacked = true;
            }
            timer -= Time.deltaTime;
            yield return null;
        }
        attacked = false;
        yield return new WaitForSeconds(attackWaitTime);
    }

    private IEnumerator Dead()
    {
        Debug.Log("deaded");
        yield break;

    }

    public void Attacked()
    {

    }

    public void Burning()
    {

    }
}
    