using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suuu : MonoBehaviour
{
    public GameObject object1; // Birinci organ
    public GameObject object2; // �kinci organ
    public GameObject object3; // ���nc� organ

    private int activeObjectIndex = 1; // Hangi objenin aktif oldu�unu takip eden de�i�ken (1, 2 veya 3)

    void Start()
    {
        // Ba�lang��ta sadece birinci obje g�r�ns�n
        if (object1 != null) object1.SetActive(true);
        if (object2 != null) object2.SetActive(false);
        if (object3 != null) object3.SetActive(false);
    }

    // Bu fonksiyon butona t�klan�nca �a�r�lacak
    public void degistir()
    {
        if (object1 != null && object2 != null && object3 != null)
        {
            // Aktif objeyi de�i�tir
            activeObjectIndex = (activeObjectIndex % 3) + 1;

            // Organlar� g�ncelle
            object1.SetActive(activeObjectIndex == 1);
            object2.SetActive(activeObjectIndex == 2);
            object3.SetActive(activeObjectIndex == 3);
        }
    }
}
