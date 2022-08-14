using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private PlayerAction PlayerAction;
    [SerializeField] private PlayerAnimator PlayerAnimator;

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
        if(WeaponRigid.GetComponent<Transform>().position != Body.position)
        {
            WeaponRigid.GetComponent<Transform>().position = Body.position;
        }
    }

    private void FixedUpdate()
    {
        if (moveable)
            PlayerAction.Move(PlayerRigid, WeaponRigid, PlayerInput.MovementInput, moveSpeed);
        if (turnable)
            PlayerAction.Face(WeaponRigid, PlayerInput.MousePosition);
        if (PlayerInput.attack && Physics2D.OverlapCircle(AttackZone.position, attackArea, EnemyLayer))
        {
            Physics2D.OverlapCircle(AttackZone.position, attackArea, EnemyLayer).GetComponent<EnemyActions>().Burning();
            Physics2D.OverlapCircle(AttackZone.position, attackArea, EnemyLayer).GetComponent<EnemyActions>().Attacked();
        }
            
        //PlayerAnimator.CheckFlip(PlayerRigid, PlayerInput.MousePosition, SpriteRenderer);
        PlayerAnimator.Render(PlayerInput.CheckMoving(), new Vector2(PlayerInput.MousePosition.x - Body.position.x, PlayerInput.MousePosition.y - Body.position.y), PlayerInput.attack);
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

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackZone.position, attackArea);

    }
}
