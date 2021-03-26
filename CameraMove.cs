using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        Vector3 off = new Vector3(player.position.x / -20, 5.4f, -15);
        transform.position = player.position + off;
    }
    
}
