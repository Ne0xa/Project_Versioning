using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    
    private bool isDead;
    
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Damage");
        if (currentHealth <= 0)
        {
            Dead();
        }
    }
    
    void  Dead()
    {
        isDead = true;
        anim.SetTrigger("Death");
        GetComponent<Collider2D>().enabled = false;
    }
}
