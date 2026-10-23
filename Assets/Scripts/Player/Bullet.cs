using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private SpriteRenderer sprite;
    private Vector3 velocity;
    private float elapsedTime;
    
    public void Init(Vector3 firePoint)
    {
        this.velocity = firePoint * speed;
    }
    
    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
        elapsedTime += Time.deltaTime;
        if (elapsedTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
