using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
    private List<GameObject> cloneInstancie = new List<GameObject>();
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
            GameObject clone = Instantiate(_ennemisData[index].Prefab, PointEcart(_apparition1),Quaternion.identity);
            index = Random.Range(0, _ennemisData.Count);
            cloneInstancie.Add(clone);
            _nbrApparition1--;
        }
        while(_nbrApparition2 > 0)
        {
            GameObject clone = Instantiate(_ennemisData[index].Prefab,PointEcart(_apparition2),Quaternion.identity);
            cloneInstancie.Add(clone);
            index = Random.Range(0, _ennemisData.Count);
            _nbrApparition2--;
        }
        while(_nbrApparition3 > 0)
        {
            GameObject clone = Instantiate(_ennemisData[index].Prefab, PointEcart(_apparition3), Quaternion.identity);
            cloneInstancie.Add(clone);
            index = Random.Range(0, _ennemisData.Count);
            _nbrApparition3--;
        }
    }
    public void DestroyAllEnnemis()
    {
        foreach(GameObject Clone in cloneInstancie)
        {
            if (Clone != null) Destroy(Clone);       
        }
        cloneInstancie.Clear();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActiveEmbuscade();
        }
    }
}
