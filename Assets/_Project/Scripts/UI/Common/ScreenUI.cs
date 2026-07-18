using UnityEngine;

namespace GmtkJam2026
{
    public sealed class ScreenUI : MonoBehaviour
    {
        [SerializeField] private RectTransform _rt;
        [SerializeField] private CanvasGroup _canvasGroup;

        public RectTransform Rt => _rt;
        public CanvasGroup CanvasGroup => _canvasGroup;
        public Vector2 RestingPosition { get; private set; }
        public Vector3 RestingScale { get; private set; }

        private void Awake()
        {
            RestingPosition = _rt.anchoredPosition;
            RestingScale = _rt.localScale;

            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}
