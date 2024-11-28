    using UnityEngine;

    public class ResetAndGrabManager : MonoBehaviour
    {
        public GameObject[] objectsToReset;  // Resetlenecek par�alar
        private Vector3[] initialPositions;  // Ba�lang�� konumlar�
        private Quaternion[] initialRotations;  // Ba�lang�� rotasyonlar�
        private Animator animator;  // Animator bile�eni

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
            // Animator'u devre d��� b�rak
            if (animator != null)
            {
                animator.enabled = false;
            }

            // T�m par�alar� ba�lang�� konumlar�na s�f�rla
            for (int i = 0; i < objectsToReset.Length; i++)
            {
                objectsToReset[i].transform.position = initialPositions[i];
                objectsToReset[i].transform.rotation = initialRotations[i];
            }

            // Animator'u yeniden etkinle�tir ve animasyonu s�f�rdan ba�lat
            if (animator != null)
            {
                animator.Play(0, -1, 0);  // Animasyonu ba�tan ba�lat
                animator.enabled = true;
            }
        }
    }
