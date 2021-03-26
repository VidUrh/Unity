using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public GameObject obj;
    public GameManager game;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag != "Ground")
        {
            if (collision.collider.tag != "Obala")
            {
                obj = collision.gameObject;
            }
            game.End();
        }
    }
}
