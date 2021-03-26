using UnityEngine;
using UnityEngine.SceneManagement;

public class Uimanager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void Customize()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        SceneManager.LoadScene(2);
    }
}
