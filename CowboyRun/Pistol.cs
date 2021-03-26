using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform roka;
    public LineRenderer muha;
    public LineRenderer crta;
    Touch touch;
    public Joystick joystick;

    public Camera cam;

    Vector2 startTouch;
    Vector2 endTouch;
    Vector2 nekVektor;
    Vector2 nekVektor2;
    Vector2 premik;

    void Update()
    {


        if (Input.touches.Length > 0)
        {


            for (int i = 0; Input.touches.Length != i; i++) {
                
                if (Input.touches[i].position.x > Screen.width/2) {

                    touch = Input.touches[i];
                    if (touch.phase == TouchPhase.Began)
                    {
                        nekVektor2 = new Vector2(transform.position.x,transform.position.y);
                        muha.enabled = true;
                        startTouch = cam.ScreenToWorldPoint(touch.position);
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        StartCoroutine(Shoot());
                        muha.enabled = false;
                    }
                    else
                    {
                        
                        premik = new Vector2(transform.position.x,transform.position.y) - nekVektor2;
                        Debug.Log(premik);
                        startTouch = startTouch + premik;
                        endTouch = cam.ScreenToWorldPoint(touch.position);
                        endTouch = new Vector2(endTouch.x, endTouch.y) + premik;
                        
                    }
                    nekVektor = endTouch - startTouch;
                    muha.SetPosition(0, startTouch);
                    muha.SetPosition(1, endTouch);
                    if (nekVektor.x > 0)
                    {

                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                }
                else
                {
                    muha.enabled = false;
                }


            }
        }


    }
    IEnumerator Shoot() {
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        RaycastHit2D hitInfo = Physics2D.Raycast(roka.position, -nekVektor, 35 , layerMask);
        if (hitInfo)
        {
            crta.SetPosition(0, roka.position);
            crta.SetPosition(1, hitInfo.transform.position);
        }
        else {

            crta.SetPosition(0, roka.position);
            crta.SetPosition(1, -nekVektor*100);
        }
        crta.enabled = true;
        yield return 0;
        crta.enabled = false;
    }
}
