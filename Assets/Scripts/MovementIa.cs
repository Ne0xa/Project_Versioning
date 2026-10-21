using UnityEngine;

public class MovementIa : MonoBehaviour
{
    [SerializeField] private EnnemisData _ennemisData;
    [SerializeField] private Transform _A;
    [SerializeField] private Transform _B;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _distanceToMove = 2f;
    [SerializeField] private float _stopDistance = 5f;
    [SerializeField] private Rigidbody2D _rb;
    Vector3 target;
    private void Reset()
    {

        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = _A.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 maPosition = transform.position;
        Vector3 playerpos = _player.transform.position;
        Vector3 directionTonPlayer = maPosition - playerpos;
        float distance = Vector3.Distance(maPosition, playerpos);
        if (distance < _distanceToMove)
        {
            if (directionTonPlayer.magnitude > _stopDistance)
            {
                _rb.AddForce(directionTonPlayer.normalized * _ennemisData.Speed);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, _ennemisData.Speed * Time.deltaTime);
            if (transform.position == target)
            {
                target = target == _A.position ? _B.position : _A.position;

            }
        }


    }
}