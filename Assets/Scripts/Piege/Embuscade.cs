using UnityEngine;
using System.Collections.Generic;
public class Embuscade : MonoBehaviour
{
    [SerializeField] private List<EnnemisData> _ennemisData = new List<EnnemisData>();
    [SerializeField] private Transform _apparition1;
    [SerializeField] private Transform _apparition2;
    [SerializeField] private Transform _apparition3;
    [SerializeField] private float _ecart = 1f;
    [SerializeField] private int _nbrApparition1 = 2;
    [SerializeField] private int _nbrApparition2 = 1;
    [SerializeField] private int _nbrApparition3 = 3;
    private bool isActivated = false;
    private Vector3 PointEcart(Transform point)
    {
        Vector2 decalage = Random.insideUnitCircle * _ecart;
        return point.position + (Vector3)decalage;
    }
    public void ActiveEmbuscade()
    {
        if (isActivated || _ennemisData.Count ==0) return;
        isActivated = true;
        int index = Random.Range(0, _ennemisData.Count);
        while(_nbrApparition1 > 0)
        {
            Instantiate(_ennemisData[index].Prefab, PointEcart(_apparition1),Quaternion.identity);
            index = Random.Range(0, _ennemisData.Count);
            _nbrApparition1--;
        }
        while(_nbrApparition2 > 0)
        {
            Instantiate(_ennemisData[index].Prefab,PointEcart(_apparition2),Quaternion.identity);
            index = Random.Range(0, _ennemisData.Count);
            _nbrApparition2--;
        }
        while(_nbrApparition3 > 0)
        {
            Instantiate(_ennemisData[index].Prefab, PointEcart(_apparition3), Quaternion.identity);
            index = Random.Range(0, _ennemisData.Count);
            _nbrApparition3--;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActiveEmbuscade();
        }
    }
}
