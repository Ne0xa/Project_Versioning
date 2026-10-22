using UnityEngine;
using NaughtyAttributes;
public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth;
    [ShowNonSerializedField] private int currentHealth;
    
    private bool _isDead;
    
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return;
        
        currentHealth -= damage;
        _anim.SetTrigger("Damage");
        
        if (currentHealth <= 0)
        {
            Dead();
        }
    }
    
    void Dead()
    {
        _isDead = true;
        _anim.SetTrigger("Death");
        GetComponent<Collider2D>().enabled = false;
        Application.Quit();
    }
}
