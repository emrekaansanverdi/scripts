    using UnityEngine;

    public class ResetAndGrabManager : MonoBehaviour
    {
        public GameObject[] objectsToReset;  // Resetlenecek parçalar
        private Vector3[] initialPositions;  // Baþlangýç konumlarý
        private Quaternion[] initialRotations;  // Baþlangýç rotasyonlarý
        private Animator animator;  // Animator bileþeni

        void Start()
        {
            initialPositions = new Vector3[objectsToReset.Length];
            initialRotations = new Quaternion[objectsToReset.Length];

            for (int i = 0; i < objectsToReset.Length; i++)
            {
                initialPositions[i] = objectsToReset[i].transform.position;
                initialRotations[i] = objectsToReset[i].transform.rotation;
            }

            animator = GetComponent<Animator>();
        }

        public void ResetObjects()
        {
            // Animator'u devre dýþý býrak
            if (animator != null)
            {
                animator.enabled = false;
            }

            // Tüm parçalarý baþlangýç konumlarýna sýfýrla
            for (int i = 0; i < objectsToReset.Length; i++)
            {
                objectsToReset[i].transform.position = initialPositions[i];
                objectsToReset[i].transform.rotation = initialRotations[i];
            }

            // Animator'u yeniden etkinleþtir ve animasyonu sýfýrdan baþlat
            if (animator != null)
            {
                animator.Play(0, -1, 0);  // Animasyonu baþtan baþlat
                animator.enabled = true;
            }
        }
    }
