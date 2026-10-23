using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private SpriteRenderer sprite;
    private Vector3 _velocity;
    private float _elapsedTime;
    
    public void Init(Vector3 firePoint)
    {
        sprite.flipY = firePoint.x > 0;
        this._velocity = firePoint * speed;
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
}
