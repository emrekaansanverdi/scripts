using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suuu : MonoBehaviour
{
    public GameObject object1; // Birinci organ
    public GameObject object2; // Ýkinci organ
    public GameObject object3; // Üçüncü organ

    private int activeObjectIndex = 1; // Hangi objenin aktif olduðunu takip eden deðiþken (1, 2 veya 3)

    void Start()
    {
        // Baþlangýçta sadece birinci obje görünsün
        if (object1 != null) object1.SetActive(true);
        if (object2 != null) object2.SetActive(false);
        if (object3 != null) object3.SetActive(false);
    }

    // Bu fonksiyon butona týklanýnca çaðrýlacak
    public void degistir()
    {
        if (object1 != null && object2 != null && object3 != null)
        {
            // Aktif objeyi deðiþtir
            activeObjectIndex = (activeObjectIndex % 3) + 1;

            // Organlarý güncelle
            object1.SetActive(activeObjectIndex == 1);
            object2.SetActive(activeObjectIndex == 2);
            object3.SetActive(activeObjectIndex == 3);
        }
    }
}
