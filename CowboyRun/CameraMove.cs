using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform cowboy;
    public Vector3 offset;
    Vector3 minus = new Vector3(12f, 7f, -10f);
    bool change;
    private void Start()
    {
        change = cowboy.rotation.eulerAngles.y == 180;
    }
    void Update()
    {
        if (change != (cowboy.rotation.eulerAngles.y == 180) & transform.position.x !=cowboy.position.x + minus.x)
        {
            if (cowboy.rotation.eulerAngles.y == 180)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(cowboy.position.x + minus.x, 7f, -10f), 0.2f);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(cowboy.position.x + offset.x, 7f, -10f), 0.2f);
            }
            change = cowboy.rotation.eulerAngles.y == 180;
        }
        else
        {
            if (cowboy.rotation.eulerAngles.y == 180)
            {
                transform.position = new Vector3(cowboy.position.x + minus.x, 7f, -10f);
            }
            else
            {
                transform.position = new Vector3(cowboy.position.x + offset.x, 7f, -10f);
            }
        }
    }
}
