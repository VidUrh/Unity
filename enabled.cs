using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enabled : MonoBehaviour
{
    public Animator anim;
    public void End()
    {
        anim.SetBool("MenuBack", false);
    }
    public void MenuUp()
    {
        anim.SetBool("Menu",false);
    }
}
