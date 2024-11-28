using UnityEngine;

public class ObjectResetManager : MonoBehaviour
{
    public GameObject[] objectsToReset;  // Resetlenecek objeler
    private Vector3[] initialPositions;  // Ba�lang�� konumlar�
    private Quaternion[] initialRotations;  // Ba�lang�� rotasyonlar�

    void Start()
    {
        // Ba�lang�� konumlar�n� ve rotasyonlar�n� kaydet
        initialPositions = new Vector3[objectsToReset.Length];
        initialRotations = new Quaternion[objectsToReset.Length];

        for (int i = 0; i < objectsToReset.Length; i++)
        {
            initialPositions[i] = objectsToReset[i].transform.position;
            initialRotations[i] = objectsToReset[i].transform.rotation;
        }
    }

    // Objeleri ba�lang�� konumlar�na geri getir
    public void ResetObjects()
    {
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].transform.position = initialPositions[i];
            objectsToReset[i].transform.rotation = initialRotations[i];
        }
    }
}
