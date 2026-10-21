using UnityEngine;

public class Chronometre : MonoBehaviour
{
    private float elapsedTime = 0f;
    public float ElapsedTime => elapsedTime;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log(Mathf.Round(elapsedTime));
    }
}
