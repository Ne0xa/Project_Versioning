using UnityEngine;
using NaughtyAttributes;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth;
    [ShowNonSerializedField] private int _currentHealth;
    
    private bool _isDead;
    private Animator _anim;
    private Vector3 _startPos;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _currentHealth = maxHealth;
        _startPos = transform.position;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return;
        
        _currentHealth -= damage;
        // _anim.SetTrigger("Damage");
        
        if (_currentHealth <= 0)
        {
            Dead();
        }
    }
    
    void Dead()
    {
        _isDead = true;
        // _anim.SetTrigger("Death");
        GetComponent<Collider2D>().enabled = false;
        Respawn();
    }

    private void Respawn()
    {
        _isDead = false;
        GetComponent<Collider2D>().enabled = true;
        transform.position = _startPos;
    }
}
