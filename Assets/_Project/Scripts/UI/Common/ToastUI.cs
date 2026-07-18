using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GmtkJam2026
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class ToastUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private Image _background;

        [Header("Type Colors")]
        [SerializeField] private Color _infoColor = new(0.16f, 0.16f, 0.18f, 0.95f);
        [SerializeField] private Color _successColor = new(0.15f, 0.5f, 0.22f, 0.95f);
        [SerializeField] private Color _warningColor = new(0.75f, 0.55f, 0.08f, 0.95f);
        [SerializeField] private Color _errorColor = new(0.65f, 0.15f, 0.15f, 0.95f);

        public RectTransform RectTransform { get; private set; }
        public CanvasGroup CanvasGroup { get; private set; }

        private void Awake()
        {
            RectTransform = (RectTransform)transform;
            CanvasGroup = GetComponent<CanvasGroup>();
        }

        public void Setup(string message, ToastType type)
        {
            if (_messageText != null)
            {
                _messageText.text = message;
            }

            if (_background == null)
            {
                return;
            }

            _background.color = type switch
            {
                ToastType.Success => _successColor,
                ToastType.Warning => _warningColor,
                ToastType.Error => _errorColor,
                _ => _infoColor
            };
        }
    }
}