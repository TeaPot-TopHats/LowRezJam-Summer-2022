using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemySensors EnemySensors;
    [SerializeField] private EnemyActions EnemyActions;
    [SerializeField] private EnemyAnimator EnemyAnimator;
    [SerializeField] private EnemyStats EnemyStats;

    [SerializeField] private SpriteRenderer Renderer;
    [SerializeField] private Rigidbody2D Rigid;
    [SerializeField] private Collider2D Target;
    [SerializeField] private GameObject GO;
    [SerializeField] private Transform Transform;
    [SerializeField] private Vector2 MoveDirection;
    [SerializeField] private bool alive;
    [SerializeField] private bool burning;
    [SerializeField] private bool attacked;
    [SerializeField] private bool moving;
    [SerializeField] private bool deathSound;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float startAttackTimer;
    [SerializeField] private float startWanderTimer;
    [SerializeField] private float startBurnTimer;
    [SerializeField] private float startImmunityTimer;
    [SerializeField] private float immunityTimer;
    [SerializeField] private float burnTimer;
    [SerializeField] private float timer;
    [SerializeField] private int attackWaitTime;
    [SerializeField] private int wanderWaitTime; 


    private void Start()
    {
        Debug.Log(1);
        EnemyStats.health = EnemyStats.maxHealth;
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
        EnemySensors.SetLayer(Transform, Renderer);
        if (burning)
            Burning();
        if (Rigid.velocity != new Vector2(0, 0))
            moving = true;
        else
            moving = false;
        if (immunityTimer > 0)
            immunityTimer -= Time.deltaTime;
        if(EnemyStats.health <= 0)
        {
            alive = false;
        }
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

            if (!EnemySensors.seePlayer)
            {

                yield return Wander();
            }
            else
            {

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
                yield return Chasing();
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
                /*if(Target == null || GO == null)
                {
                    Target = EnemySensors.recordTarget();//something wrong here
                    GO = EnemySensors.recordGO();
                }
                    
                else */
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

                Debug.Log("Attacking " + EnemySensors.Player);
                EnemySensors.Player.GetComponent<PlayerController>().Attacked();
                //do damage to area
                attacked = true;
            }
            timer -= Time.deltaTime;
            yield return null;
        }
        attacked = false;
        yield return Chasing();
    }

    private IEnumerator Dead()
    {
        if (!deathSound)
        {
            deathSound = true;
            AudioManager.instance.Play("dead3");
        }
        Renderer.sortingOrder = 0;
        GetComponent<BoxCollider2D>().isTrigger = true;
        MoveDirection = new Vector2(0, 0);
        EnemyActions.Move(Rigid, MoveDirection, 0);
        Rigid.velocity = MoveDirection;
        attacked = true;
        EnemyAnimator.SetBurnAnim(false);
        Debug.Log("deaded");
        EnemyAnimator.SetDeath(true);
        enabled = false;
        StopAllCoroutines();
        yield return null;

    }

    public void Attacked()
    {
        EnemyAnimator.SetBurnAnim(true);
        if (immunityTimer <= 0) 
        {
            immunityTimer = startImmunityTimer;
            EnemyStats.health -= 1;
        }
            

    }

    public void Burning()
    {
        if (!burning)
        {
            burning = true; AudioManager.instance.Play("onFire");
            EnemySensors.Player.GetComponent<JSONSavingScript>().myplayer.killCount++;
        }
        if (burnTimer <= 0)
        {
            burnTimer = startBurnTimer;
            EnemyStats.health -= 1;
        }
        else
            burnTimer -= Time.deltaTime;
    
    }
}
    