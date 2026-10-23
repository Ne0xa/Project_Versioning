using UnityEngine;

public class UpdateUIHealth : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private SpriteRenderer _Healthfull;
    [SerializeField] private SpriteRenderer _HealthEmpty;
    private float _ecart = 1.5f;

    void Start()
    {
        
        for(int i = 0; i < _health.CurrentHealth; i++)
        {
            Vector3 decalage = new Vector3(i * _ecart, 0, 0);
            Instantiate(_Healthfull, decalage, Quaternion.identity,transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
