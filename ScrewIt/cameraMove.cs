using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform key;
    Vector3 offset = new Vector3(-4f,8f,-0f);
    void FixedUpdate()
    {
        Vector3 newpos = key.position + offset;
        transform.position = Vector3.Slerp(transform.position, newpos, 0.2f);
    }
}
   