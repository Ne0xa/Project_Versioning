using UnityEngine;

public class DeployEmbuscade : MonoBehaviour
{
    [SerializeField] private Embuscade _embuscade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _embuscade.ActiveEmbuscade();
        }
    }

    // Update is called once per frame
}
