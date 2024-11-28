using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Yeni Input System için gerekli
using UnityEngine.XR.Interaction.Toolkit;


public class ResetPosition : MonoBehaviour
{
    public GameObject objectToReset;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody rb;

    // Sol el Y butonu için Input Action
    public InputActionProperty leftHandYButtonAction;

    private void Start()
    {
        // Objeyi ilk konumuna ve rotasyonuna kaydet
        if (objectToReset != null)
        {
            initialPosition = objectToReset.transform.position;
            initialRotation = objectToReset.transform.rotation;

            // Rigidbody bileþenini al
            rb = objectToReset.GetComponent<Rigidbody>();
        }

        // Sol el Y butonunu dinlemeye baþla
        leftHandYButtonAction.action.performed += OnYButtonPressed;
    }

    private void OnDestroy()
    {
        // Tuþ dinlemeyi býrak
        leftHandYButtonAction.action.performed -= OnYButtonPressed;
    }

    private void OnYButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Y butonuna basýldý"); // Bu satýrýn Console’da göründüðünden emin olun
        ResetObjectPosition();
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
                rb.isKinematic = false; // Hareketi sýfýrlamak için kýsa bir süreliðine kinematik yap ve sonra eski haline döndür
            }
        }
    }
}
