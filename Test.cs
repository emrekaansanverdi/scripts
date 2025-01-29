using UnityEngine;
using Oculus.Interaction;

public class Test : MonoBehaviour
{
    public LayerMask grabbableLayer; // Tutulabilir nesneleri belirlemek i�in
    private GameObject lastGrabbedObject = null;
    private bool isGrabbing = false;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f, grabbableLayer))
        {
            if (hit.collider.gameObject != lastGrabbedObject)
            {
                lastGrabbedObject = hit.collider.gameObject;
                Debug.Log(lastGrabbedObject.name + " tutuldu.");
            }

            if (!isGrabbing)
            {
                isGrabbing = true;
                Debug.Log("I��n ile nesne tutuldu: " + lastGrabbedObject.name);
            }
        }
        else
        {
            if (isGrabbing)
            {
                isGrabbing = false;
                Debug.Log("Nesne b�rak�ld�.");
            }

            lastGrabbedObject = null;
        }
    }
}
