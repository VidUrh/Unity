using UnityEngine;

public class trigger1 : MonoBehaviour
{
    public kljuc1 kljuc1;
    public Material frej;
    odstevalnik odstevalnik;
    public obrati obrati;
    Animator anim;
    public int level;

    public int zvezde = 0;
    public int zaviti = 0;
    GameObject starter;


    public bool skos = true;

    void Start()
    {
        odstevalnik = GameObject.FindGameObjectWithTag("Timer").GetComponent<odstevalnik>();
        anim = GameObject.FindGameObjectWithTag("KonecLevela").GetComponent<Animator>();

        starter = GameObject.Find("starter"); 
        starter.transform.position = new Vector3(starter.transform.position.x, -0.38f, starter.transform.position.z);
        starter.GetComponent<MeshRenderer>().material = frej;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (skos)
        {
            Vector3 vijak = other.gameObject.transform.position;
            Vector3 sredina = Sredisce(kljuc1.pivotpoint, vijak);
            Quaternion rotacija = Rotacija(kljuc1.pivotpoint, vijak);

            if (kljuc1.pivotpoint != vijak && rotacija.eulerAngles.z == 0 && Razdalja(kljuc1.pivotpoint, vijak))
            {
                obrati.poteze -= 1;
                transform.position = sredina;
                transform.rotation = rotacija;
                kljuc1.pivotpoint = vijak;
                if (vijak.y != -0.38f)
                {
                    other.gameObject.transform.position = new Vector3(vijak.x, -0.38f, vijak.z);
                    other.gameObject.GetComponent<MeshRenderer>().material = frej;
                    zaviti += 1;
                    if (zaviti == level)
                    {
                        kljuc1.enabled = false;
                        if (odstevalnik.konc)
                        {
                            odstevalnik.konc = false;
                            if (odstevalnik.time > 0)
                            {
                                zvezde += 1;
                            }
                            if (obrati.poteze > 0)
                            {
                                zvezde += 1;
                            }
                            anim.enabled = true;
                        }
                    }
                }
            }
        }

    }

    public void Skos()
    {
        if (skos)
        {
            skos = false;
        }
        else
        {
            skos = true;
        }
    }

    bool Razdalja(Vector3 prvi, Vector3 drugi)
    {
        float x = prvi.x - drugi.x;
        float y = prvi.z - drugi.z;
        return Mathf.Sqrt(x * x + y * y) <= 1.59f && Mathf.Sqrt(x * x + y * y) >= 1.57f;
    }
    Vector3 Sredisce(Vector3 prvi, Vector3 drugi)
    { 
        Vector3 point = new Vector3((prvi.x + drugi.x) / 2, 0, (prvi.z + drugi.z) / 2);
        return point;
    }
    Quaternion Rotacija(Vector3 prvi, Vector3 drugi)
    {
        if (Mathf.Abs(prvi.z - drugi.z) == 0)
        {
            return Quaternion.Euler(0, 90, 0);
        }
        float rotacija = 180 - Mathf.Atan((drugi.x - prvi.x) / (prvi.z - drugi.z)) * 57f;

        if (float.IsNaN(rotacija))
        {
            return Quaternion.Euler(0, 0, 3);
        }
        return Quaternion.Euler(0, rotacija, 0);
    }
    
}

