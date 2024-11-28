using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject[] objects;  // Obje dizisi
    private int currentIndex = 0;  // Mevcut aktif objenin indeksi

    void Start()
    {
        // Ba�lang��ta sadece ilk obje aktif, di�erleri gizli
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == currentIndex);
        }
    }

    // Bu fonksiyon UI Button taraf�ndan �a�r�lacak
    public void SwitchObject()
    {
        // E�er hi� obje yoksa geri d�n
        if (objects.Length == 0)
            return;

        // Mevcut objeyi gizle
        objects[currentIndex].SetActive(false);

        // Bir sonraki objeye ge�
        currentIndex = (currentIndex + 1) % objects.Length;

        // Yeni objeyi g�ster
        objects[currentIndex].SetActive(true);
    }
}
