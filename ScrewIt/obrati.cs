using UnityEngine;
using UnityEngine.UI;

public class obrati : MonoBehaviour
{
    public int poteze;
    public Text text;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (poteze > 0)
        {
            text.text = poteze.ToString();
        }
        else if(poteze == 0)
        {
            text.text = "0";
            animator.enabled = true;
        }
    }
}
