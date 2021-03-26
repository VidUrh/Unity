using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class leveler : MonoBehaviour
{
    public Text text1;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = (SceneManager.GetActiveScene().buildIndex).ToString();
        text1.text = (SceneManager.GetActiveScene().buildIndex).ToString();
    }

    // Update is called once per frame
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Next()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
