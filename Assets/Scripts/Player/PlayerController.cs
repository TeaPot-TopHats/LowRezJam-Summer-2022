using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private PlayerAction PlayerAction;
    [SerializeField] private PlayerAnimator PlayerAnimator;
    [SerializeField] private JSONSavingScript PlayerStats;

    [SerializeField] private Rigidbody2D PlayerRigid;
    [SerializeField] private Rigidbody2D WeaponRigid;
    [SerializeField] private LayerMask EnemyLayer;

    [SerializeField] public GameObject Projectile;
    [SerializeField] public Transform ProjectileSpawn;
    [SerializeField] public Transform Body;
    [SerializeField] public Transform AttackZone;
    [SerializeField] public SpriteRenderer SpriteRenderer;

    [SerializeField] private float attackArea;
    [SerializeField] private bool moveable;
    [SerializeField] private bool turnable;
    [SerializeField] private bool firing;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireForce;
    [SerializeField] private int state;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (PlayerStats.myplayer.health <= 0)
            Die();
        //firing = PlayerInput.attack;

        if(WeaponRigid.GetComponent<Transform>().position != Body.position)
        {
            WeaponRigid.GetComponent<Transform>().position = Body.position;
        }
        if (PlayerInput.attack && PlayerStats.myplayer.ammo > 0)
        {
            PlayerStats.myplayer.ammo--;
            firing = true;
        }
        else
            firing = false;
            
        if (PlayerInput.attack && Physics2D.OverlapCircle(AttackZone.position, attackArea, EnemyLayer) && PlayerStats.myplayer.ammo > 0)
        {
            Physics2D.OverlapCircle(AttackZone.position, attackArea, EnemyLayer).GetComponent<EnemyController>().Burning();
            Physics2D.OverlapCircle(AttackZone.position, attackArea, EnemyLayer).GetComponent<EnemyController>().Attacked();
            
        }
        if (!PlayerInput.attack && PlayerStats.myplayer.ammo < PlayerStats.myplayer.maxAmmo)
            PlayerStats.myplayer.ammo += 2;
    }

    private void FixedUpdate()
    {
        if (moveable)
            PlayerAction.Move(PlayerRigid, WeaponRigid, PlayerInput.MovementInput, moveSpeed);
        if (turnable)
            PlayerAction.Face(WeaponRigid, PlayerInput.MousePosition);
        
            
        //PlayerAnimator.CheckFlip(PlayerRigid, PlayerInput.MousePosition, SpriteRenderer);
        PlayerAnimator.Render(PlayerInput.CheckMoving(), new Vector2(PlayerInput.MousePosition.x - Body.position.x, PlayerInput.MousePosition.y - Body.position.y), firing);
        if(WeaponRigid.rotation > 45 || WeaponRigid.rotation <= -135)
            SpriteRenderer.sortingOrder = 0;
        else
            SpriteRenderer.sortingOrder = 3;
    }

    private int SetState(bool moving, bool attacking)
    {
        if (attacking)
            return 2;
        if (moving && moveable)
            return 1;
        return 0;
    }

    public void Attacked()
    {
        Debug.Log("I'm hit");
        AudioManager.instance.Play("dead3");
        PlayerStats.myplayer.health -= 1;
    }

    public void Die()
    {
        enabled = false;
        PlayerInput.enabled = false;
    }

    public void StartUp()
    {
        if (!enabled)
            enabled = true;
        if (!PlayerInput.enabled)
            PlayerInput.enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackZone.position, attackArea);

    }
}
