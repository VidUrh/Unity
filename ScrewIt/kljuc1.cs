using UnityEngine;

public class kljuc1 : MonoBehaviour
{
    public bool levo;
    public bool desno;
    public BoxCollider box;
    public int speed;
    public Vector3 pivotpoint;
    
    void Start()
    {
        pivotpoint += transform.position;


    }
    void Update()
    {

        if (Input.GetKey("a") | levo)
        {
            transform.RotateAround(pivotpoint, transform.up, -speed * Time.deltaTime);
        }
        if (Input.GetKey("d") | desno)
        {
            transform.RotateAround(pivotpoint, transform.up, speed * Time.deltaTime);

        }


    }
    public void LevoDol() 
    {
        levo = true;
    }
    public void DesnoDol()
    {
        desno = true;
    }
    public void DesnoGor()
    {
        desno = false;
    }
    public void LevoGor()
    {
        levo = false;
    }
    

}
