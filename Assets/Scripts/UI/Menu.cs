using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
