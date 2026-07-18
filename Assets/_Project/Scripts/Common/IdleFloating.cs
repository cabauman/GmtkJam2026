using UnityEngine;

namespace GmtkJam2026
{
    public sealed class UIIdleFloating : MonoBehaviour
    {
        [Header("Floating Settings")]
        public float _floatSpeed = 2.0f;
        public float _floatAmount = 15.0f;

        [Header("Breathing Settings")]
        public bool _enableBreathing = true;
        public float _pulseSpeed = 1.5f;
        public float _pulseAmount = 0.05f;

        private Vector3 startPosition;
        private Vector3 startScale;

        private void Start()
        {
            startPosition = transform.localPosition;
            startScale = transform.localScale;
        }

        private void Update()
        {
            // Smooth sine wave for floating up and down
            float newY = startPosition.y + Mathf.Sin(Time.time * _floatSpeed) * _floatAmount;
            transform.localPosition = new Vector3(startPosition.x, newY, startPosition.z);

            // Smooth sine wave for breathing/pulsing scale
            if (_enableBreathing)
            {
                float scaleFactor = 1.0f + Mathf.Sin(Time.time * _pulseSpeed) * _pulseAmount;
                transform.localScale = startScale * scaleFactor;
            }
        }
    }
}
