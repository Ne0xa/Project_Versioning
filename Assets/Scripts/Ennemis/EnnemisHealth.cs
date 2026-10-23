using UnityEngine;
using NaughtyAttributes;
public class EnnemisHealth : MonoBehaviour
{
    [SerializeField] private EnnemisData _ennemisData;
    [SerializeField] private Animator _anim;
    [ShowNonSerializedField] private int _currentLife;
    bool isDead = false;
    public bool IsDead => isDead;
    void Awake()
    {
        _currentLife = _ennemisData.Life;
        if (_anim == null) _anim = GetComponent<Animator>();
    }

    public void TakeDamageEnemy(int damage)
    {
        _currentLife -= damage;
        _anim.SetTrigger("Damage");
        if (_currentLife <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        isDead = true;
        _anim.SetTrigger("Death");
        GetComponent<Collider2D>().enabled = false;
    }
}

