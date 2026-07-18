using UnityEngine;

namespace GmtkJam2026
{
    public class UIParallaxMouse : MonoBehaviour
    {
        [Header("Movement Sensitivity")]
        [Tooltip("Negative values invert the movement direction.")]
        public float _moveModifier = 0.05f;
        public float _smoothSpeed = 5.0f;

        private Vector3 startPosition;

        private void Start()
        {
            startPosition = transform.localPosition;
        }

        private void Update()
        {
            // Get mouse position relative to the center of the screen
            Vector3 mousePos = Input.mousePosition;
            float centerX = mousePos.x - (Screen.width / 2f);
            float centerY = mousePos.y - (Screen.height / 2f);

            // Calculate target positions based on modifier strength
            float targetX = startPosition.x + (centerX * _moveModifier);
            float targetY = startPosition.y + (centerY * _moveModifier);

            Vector3 targetPosition = new Vector3(targetX, targetY, startPosition.z);

            // Smoothly interpolate to the target position
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * _smoothSpeed);
        }
    }
}
