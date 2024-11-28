using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Yeni Input System i�in gerekli
using UnityEngine.XR.Interaction.Toolkit;


public class ResetPosition : MonoBehaviour
{
    public GameObject objectToReset;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody rb;

    // Sol el Y butonu i�in Input Action
    public InputActionProperty leftHandYButtonAction;

    private void Start()
    {
        // Objeyi ilk konumuna ve rotasyonuna kaydet
        if (objectToReset != null)
        {
            initialPosition = objectToReset.transform.position;
            initialRotation = objectToReset.transform.rotation;

            // Rigidbody bile�enini al
            rb = objectToReset.GetComponent<Rigidbody>();
        }

        // Sol el Y butonunu dinlemeye ba�la
        leftHandYButtonAction.action.performed += OnYButtonPressed;
    }

    private void OnDestroy()
    {
        // Tu� dinlemeyi b�rak
        leftHandYButtonAction.action.performed -= OnYButtonPressed;
    }

    private void OnYButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Y butonuna bas�ld�"); // Bu sat�r�n Console�da g�r�nd���nden emin olun
        ResetObjectPosition();
    }

    public void ResetObjectPosition()
    {
        // Objeyi ba�lang�� konumuna ve rotasyonuna d�nd�r
        if (objectToReset != null)
        {
            objectToReset.transform.position = initialPosition;
            objectToReset.transform.rotation = initialRotation;

            // E�er Rigidbody varsa, h�z�n� ve a��sal h�z�n� s�f�rla
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Objeyi fiziksel kuvvetlerden etkilenmeyecek �ekilde durdur
                rb.isKinematic = true;
                rb.isKinematic = false; // Hareketi s�f�rlamak i�in k�sa bir s�reli�ine kinematik yap ve sonra eski haline d�nd�r
            }
        }
    }
}
