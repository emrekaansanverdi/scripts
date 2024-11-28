using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject[] objects;  // Obje dizisi
    private int currentIndex = 0;  // Mevcut aktif objenin indeksi

    void Start()
    {
        // Baþlangýçta sadece ilk obje aktif, diðerleri gizli
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == currentIndex);
        }
    }

    // Bu fonksiyon UI Button tarafýndan çaðrýlacak
    public void SwitchObject()
    {
        // Eðer hiç obje yoksa geri dön
        if (objects.Length == 0)
            return;

        // Mevcut objeyi gizle
        objects[currentIndex].SetActive(false);

        // Bir sonraki objeye geç
        currentIndex = (currentIndex + 1) % objects.Length;

        // Yeni objeyi göster
        objects[currentIndex].SetActive(true);
    }
}
