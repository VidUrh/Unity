using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMaker : MonoBehaviour
{
    public trigger1 trigger;
    public obrati obrati;
    public GameObject vijak;
    public Vector3 lastlocation;
    public GameObject[] vijaki;
    public Vector3 novaLokacija;

    void Awake()
    {
        lastlocation = new Vector3(0.8f, 0, 0);
        Instantiate(vijak, lastlocation, new Quaternion(0, 0, 0, 0)).name = "starter";


    }
    private void Start()
    {
        int a = SceneManager.GetActiveScene().buildIndex;
        if (a < 10)
        {
            a += Random.Range(6, 10);
        }

        int level1 = Random.Range(a, a + 30);
        trigger.level = level1;
        obrati.poteze = level1 + Random.Range(2, 5);
        GameObject[] vijaki = new GameObject[level1];

        for (int i = 0; i < level1; i++)
        {
            vijaki[i] = Instantiate(vijak, Razdalja(lastlocation), new Quaternion(0, 0, 0, 0));

        }


    }

    private Vector3 Razdalja(Vector3 lokacija)
    {
        float x = Random.Range(0f,1.58f);
        float z = 1.58f * 1.58f - x * x;
        int minus = Random.Range(0, 2);
        if (minus == 0)
        {
            minus = -1;
        }
        novaLokacija = new Vector3(x, 0, Mathf.Sqrt(z) * minus) + lokacija;
        novaLokacija.y = -0.3f;
        lastlocation = novaLokacija;
        return novaLokacija;
    }
}
