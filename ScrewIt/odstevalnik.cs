using UnityEngine;
using UnityEngine.UI;

public class odstevalnik : MonoBehaviour
{
    public Animator anim;
    public bool konc;
    public Text text;
    public float time;

    private void FixedUpdate()
    {
        if(time > 0 & konc)
        {
            time -= Time.deltaTime;
            UpdateLevelTimer(time);
        }
        else if(time <= 0)
        {
            anim.enabled = true;
        }
        
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);
        
        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }
        if (minutes >= 0)
        {
            text.text = minutes.ToString("0") + ":" + seconds.ToString("00");
        }

        
    }
}
