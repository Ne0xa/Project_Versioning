using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private SpriteRenderer sprite;
    private Vector3 _velocity;
    private int _damage = 1;
    private float _elapsedTime;
    private EnnemisHealth _ennemisHealth;
    
    public void Init(Vector3 firePoint, int damage)
    {
        sprite.flipY = firePoint.x > 0;
        this._velocity = firePoint * speed;
        _damage = damage;
    }
    
    private void Update()
    {
        transform.position += _velocity * Time.deltaTime;
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnnemisHealth>().TakeDamageEnemy(_damage);
        }
    }
}
