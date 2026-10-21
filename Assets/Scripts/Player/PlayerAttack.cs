using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float cooldown;
    [SerializeField] private float damage;
    
    [Header("Inputs")]
    [SerializeField] InputActionReference attackInput;
    [SerializeField] InputActionReference shootInput;
    
    [Header("Visual")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firePoint;
    
    private float _elapsedTime;

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

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (shootInput.action.IsPressed())
        {
            if (_elapsedTime >= cooldown)
            {
                _elapsedTime = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        bullet.Init(firePoint.position);
    }
}
