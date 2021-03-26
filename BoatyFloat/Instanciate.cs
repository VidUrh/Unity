using UnityEngine.UI;
using UnityEngine;

public class Instanciate : MonoBehaviour
{
    public Transform player;
    public GameObject rock;
    public GameObject octy;
    public Text text;
    private float x = 1.5f;
    private GameObject rocky;
    private int n = 100;
    public int score = -1;
    public float pos;
    public boatyfloat boaty;
    private void Start()
    {
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 2 * n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 3 * n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 4 * n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 5 * n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 6 * n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 7 * n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 8 * n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 9 * n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 10 * n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 11 * n), Random.rotation);
        Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 12 * n), Random.rotation);
        rocky = Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), 13 * n), Random.rotation);
    }
    void Update()
    {
        
        if (boaty.zares == true)
        {
            if (PlayerPrefs.GetInt("max", 0) < score)
            {
                PlayerPrefs.SetInt("max", score);
            }
            float obj = Random.value;
            if (player.position.z >= rocky.transform.position.z - 13 * n & obj <= 0.9f)
            {
                rocky = Instantiate(rock, new Vector3(Random.Range(-50, 50), Random.Range(1f + x, 1.5f + x), player.position.z + 14 * n), Random.rotation);
                score++;
                text.text = score.ToString();
                Destroy(rocky, n / 5);
            }
            if (player.position.z >= rocky.transform.position.z - 13 * n & obj > 0.9f & obj < 0.95f)
            {
                rocky = Instantiate(octy, new Vector3(Random.Range(-50, 50), Random.Range(1f, 1.5f), player.position.z + 14 * n), Quaternion.Euler(0, 180, 0));
                score++;
                Destroy(rocky, n / 5);
                text.text = score.ToString();
            }

        }
    }

}
