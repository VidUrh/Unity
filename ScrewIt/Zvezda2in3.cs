using UnityEngine;

public class Zvezda2in3 : MonoBehaviour
{
    public trigger1 koda;
    public GameObject zvezda2;
    public GameObject zvezda3;
    
    public void Zvezdana1()
    {
        if (koda.zvezde > 0)
        {
            zvezda2.SetActive(true);
        }
    }
    public void Zvezdana2()
    {
        if (koda.zvezde > 1)
        {
            zvezda3.SetActive(true);
        }
    }
}
