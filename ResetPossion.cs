using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetPossion : MonoBehaviour
{
    public GameObject objectToReset;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // Objeyi ilk konumuna ve rotasyonuna kaydet
        if (objectToReset != null)
        {
            initialPosition = objectToReset.transform.position;
            initialRotation = objectToReset.transform.rotation;

            // Rigidbody bileþenini al
            rb = objectToReset.GetComponent<Rigidbody>();
        }
    }
    public void ResetObjectPosition()
    {
        // Objeyi baþlangýç konumuna ve rotasyonuna döndür
        if (objectToReset != null)
        {
            objectToReset.transform.position = initialPosition;
            objectToReset.transform.rotation = initialRotation;

            // Eðer Rigidbody varsa, hýzýný ve açýsal hýzýný sýfýrla
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Objeyi fiziksel kuvvetlerden etkilenmeyecek þekilde durdur
                rb.isKinematic = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}