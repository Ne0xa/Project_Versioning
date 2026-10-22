using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float shootCooldown;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float damage;
    
    [Header("Inputs")]
    [SerializeField] InputActionReference attackInput;
    [SerializeField] InputActionReference shootInput;
    
    [Header("Visual")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firePoint;
    
    private float _elapsedTime;
    private Animator anim;

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
        anim = GetComponent<Animator>();
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

    void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        bullet.Init(firePoint.position);
        anim.SetTrigger("Shoot");
    }

    void Attack(int damage = 1 )
    {
        
        anim.SetTrigger("Attack");
    }
}
