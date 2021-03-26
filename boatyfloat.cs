using UnityEngine;

public class boatyfloat : MonoBehaviour
{
    public GameManager GameManager;
    public Rigidbody rb;
    public float forwardSpeed;
    public float SideSpeed;
    public float rotationspeedtap;
    public float rotationSpeed;
    private float offacc;
    public int minus = 0;
    public bool normalno;
    public bool zares;
    public int a = 0;


    private void Start()
    {
        zares = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.velocity = new Vector3(0, 0, 50);
        offacc = Input.acceleration.x;
    }

    void FixedUpdate()
    {
        transform.rotation.eulerAngles.Set(0, 0, transform.rotation.eulerAngles.z);
        rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);
        if (transform.rotation.eulerAngles.x >= 300 | transform.rotation.eulerAngles.x <= 255f)
        {
            GameManager.End();
        }
        if (normalno)
        { 
            if (Input.acceleration.x - offacc< -0.05)
            {
                minus = -1;
            }
            else if (Input.acceleration.x - offacc > 0.05)
            {
                minus = 1;
            }

            rb.AddForce(SideSpeed * Time.deltaTime * minus, 0, 0, ForceMode.VelocityChange);

            if (Input.touchCount != 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x > Screen.width / 2f)
                {
                    rb.AddTorque(-Vector3.forward * rotationspeedtap * Time.deltaTime, ForceMode.VelocityChange);           
                }
                if (touch.position.x <= Screen.width / 2f)
                {
                    rb.AddTorque(Vector3.forward * rotationspeedtap * Time.deltaTime, ForceMode.VelocityChange);                   
                }
            }
        }
        else
        {
            transform.Rotate(0, 0, (Input.acceleration.x - offacc) * 10);
            rb.AddTorque(Vector3.forward * rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
            if (Input.touchCount != 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x > Screen.width / 2f)
                {                
                    rb.AddForce(SideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                else if (touch.position.x <= Screen.width / 2f)
                {
                    rb.AddForce(-SideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
            }
        }
        if (Input.GetKey("a")) {

            rb.AddForce(-SideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (Input.GetKey("d"))
        {
            rb.AddForce(SideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("l"))
        {
            rb.AddTorque(-Vector3.forward * rotationspeedtap * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (Input.GetKey("j"))
        {
            rb.AddTorque(Vector3.forward * rotationspeedtap * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}