using UnityEngine;
using System.Collections.Generic;
public class Embuscade : MonoBehaviour
{
    [SerializeField] private List<EnnemisData> _ennemisData = new List<EnnemisData>();
    [SerializeField] private Transform _apparition1;
    [SerializeField] private Transform _apparition2;
    [SerializeField] private Transform _apparition3;
    [SerializeField] private int _nbrApparition1 = 2;
    [SerializeField] private int _nbrApparition2 = 1;
    [SerializeField] private int _nbrApparition3 = 3;
    private bool isActivated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ActiveEmbuscade()
    {
        if (isActivated || _ennemisData.Count ==0) return;
        isActivated = true;
        int index = Random.Range(0, _ennemisData.Count);
        while(_nbrApparition1 > 0)
        {
            Instantiate(_ennemisData[index].Prefab, _apparition1);
            index = Random.Range(0, _ennemisData.Count);
            _nbrApparition1--;
        }
        while(_nbrApparition2 > 0)
        {
            Instantiate(_ennemisData[index].Prefab,_apparition2);
            index = Random.Range(0, _ennemisData.Count);
            _nbrApparition2--;
        }
        while(_nbrApparition3 > 0)
        {
            Instantiate(_ennemisData[index].Prefab, _apparition3);
            index = Random.Range(0, _ennemisData.Count);
            _nbrApparition3--;
        }
    }
}
