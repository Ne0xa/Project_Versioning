using System;
using UnityEngine;

public class AttackIA : MonoBehaviour
{
    [SerializeField] private EnnemisData _ennemisData;
    [SerializeField] private Transform _posPlayer;
    [SerializeField] private Transform _posEnemy;
    [SerializeField] private float _cooldown = 1f;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _detectRange = 2f;
    [SerializeField] private float _attackRange = 1f;
    private float elapsedTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void Attack()
    {
        _posPlayer.GetComponent<PlayerHealth>()?.TakeDamage(_ennemisData.Attack);
        _anim.SetTrigger("Attack");
        Debug.Log("Le joueur à été touché");
    }
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= _cooldown)
        {

            Attack();
            elapsedTime = 0f; 
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
