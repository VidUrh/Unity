using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    private string store_id = "3518445";
    private string videoAd = "video";
    private string rewardedAd = "rewardedVideo";
    public collision col;
    public AudioManager play;
    public Transform tla1;
    public Transform tla2;
    public Transform tf; //asdfboaty
    public GameObject revive;
    public Rigidbody rb;
    public boatyfloat movement;
    public Instanciate instanciate;
    public Animator menu;
    public Animator Startmenu;
    public Animator Score;
    public MeshCollider box;
    public bool Bool = false;
    public int minus;

    public bool restart;
    public Text best;


    private void Start()
    {
        movement.rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        Advertisement.Initialize(store_id, false);
        PlayerPrefs.SetInt("rewards",0);
        best.text = "Best: " + PlayerPrefs.GetInt("max",0);
        if (PlayerPrefs.GetInt("restart", 0) == 0)
        {
            Startmenu.SetBool("Start", true);
        }
        else {
            movement.enabled = true;
        }
        instanciate.enabled = true;
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("restart", 0);
    }
    public void Restart1()
    {
        menu.SetBool("Menu", false);
        menu.SetBool("MenuBack", true);
        PlayerPrefs.SetInt("num", PlayerPrefs.GetInt("num", 0) + 1);
        if (PlayerPrefs.GetInt("num", 0) == 2)
        {
            if (Advertisement.IsReady(videoAd))
            {
                Advertisement.Show(videoAd);
                PlayerPrefs.SetInt("num", 0);

            }
        }
        PlayerPrefs.SetInt("restart", 1);
        rb.angularDrag = 20;
        Bool = true;
        

    }
    public void ClickRest()
    {   
        Startmenu.SetBool("Start", false);
        Startmenu.SetBool("Play", true);
        Score.enabled = true;
        movement.rb.constraints = RigidbodyConstraints.FreezeRotationX;
        movement.enabled = true;

    }
    public void MainMenu()
    {
        menu.SetBool("Menu", false);
        menu.SetBool("MenuBack", true);
        PlayerPrefs.SetInt("num", PlayerPrefs.GetInt("num", 0) + 1);
        if (PlayerPrefs.GetInt("num", 0) == 6)
        {
            if (Advertisement.IsReady(videoAd))
            {
                Advertisement.Show(videoAd);
                PlayerPrefs.SetInt("num", 0);

            }
        }
        
        PlayerPrefs.SetInt("restart", 0);
        rb.angularDrag = 20;
        Bool = true;
        
    }
    public void Update()
    {       
        if (tf.position.z - 50 > tla2.position.z - tla2.localScale.z / 2)
        {
            tla1.position = new Vector3(0, 0, tla2.position.z + 10000);
        }
        if (tf.position.z -50 > tla1.position.z - tla1.localScale.z / 2)
        {
            tla2.position = new Vector3(0, 0, tla1.position.z + 10000);
        }
        if (Bool == true)
        {
            rb.useGravity = false;
            box.enabled = false;
            Vector3 smooth = Vector3.Lerp(tf.position, new Vector3(0, 2.8f, 0), 0.05f);
            Quaternion smooth1 = Quaternion.Lerp(tf.rotation,Quaternion.Euler(-90f,180f,-90f), 0.05f);
            tf.position = smooth;
            tf.rotation = smooth1;
            if (tf.position.z - 50 < tla2.position.z - tla2.localScale.z / 2)
            {
                tla1.position = new Vector3(0, 0, tla2.position.z - 10000);
            }
            if (tf.position.z - 50 < tla1.position.z - tla1.localScale.z / 2)
            {
                tla2.position = new Vector3(0, 0, tla1.position.z - 10000);
            }
            if (tf.position.z <= 1)
            {
                SceneManager.LoadScene(0);
            }

        }
    }
    
    public void Ads()
    {

        rb.useGravity = true;
        box.enabled = true;
        menu.SetBool("Menu", false);
        menu.SetBool("MenuBack", true);
        if (Advertisement.IsReady(rewardedAd))
        {
            Advertisement.Show(rewardedAd);
            if (col.obj != null)
            {
                Destroy(col.obj);
            }
            else
            {   
                if(tf.position.x < 0)
                {
                    minus = -10;
                }
                else
                {
                    minus = 10;
                }
                tf.position = new Vector3( 4.6f* minus, 2.8f, tf.position.z);
            }
            PlayerPrefs.SetInt("rewards", 1);
            rb.drag = 0;
            rb.angularDrag = 20;
            tf.rotation = Quaternion.Euler(270f, 270f, -180f);
            movement.enabled = true;
            instanciate.enabled = true;
        }
        else
        {
            SSTools.ShowMessage("No ads to show", SSTools.Position.bottom, SSTools.Time.oneSecond);
            Restart1();
        }
       
    }
    public void End()
    {
        
        if(PlayerPrefs.GetInt("rewards",0) == 1)
        {
            revive.SetActive(false);
        }
        menu.SetBool("Menu",true);
        rb.drag = 4;
        rb.angularDrag = 1;
        rb.AddForce(Vector3.up * -20);
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        movement.enabled = false;
        instanciate.enabled = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
