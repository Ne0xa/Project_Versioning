using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float shootCooldown;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float damage;
    [SerializeField] Movement movement;
    
    [Header("Inputs")]
    [SerializeField] InputActionReference attackInput;
    [SerializeField] InputActionReference shootInput;
    
    [Header("Visual")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firePoint;
    
    private float _elapsedTime;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    private EnnemisHealth _ennemisHealth;

    private void OnEnable()
    {
        attackInput.action.Enable();
        shootInput.action.Enable();
    }

    private void OnDisable()
    {
        attackInput.action.Disable();
        shootInput.action.Disable();
    }

    void Start()
    {
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (shootInput.action.IsPressed())
        {
            if (_elapsedTime >= shootCooldown)
            {
                _elapsedTime = 0;
                Shoot();
            }
        }

        if (attackInput.action.IsPressed())
        {
            if (_elapsedTime >= attackCooldown)
            {
                _elapsedTime = 0;
                Attack();
            }
        }
    }

    void Shoot(int damage = 1 )
    {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.Init(new Vector3(movement.facing, 0, 0), damage);
        // _anim.SetTrigger("Shoot");
        Debug.Log("the player is shooting");
    }

    void Attack(int damage = 1 )
    {
        // _anim.SetTrigger("Attack");
        Debug.Log("the player is attacking");
        _ennemisHealth.TakeDamageEnemy(damage);
    }
}
