using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

namespace GmtkJam2026
{
    public enum ToastType
    {
        Info,
        Success,
        Warning,
        Error
    }

    [DefaultExecutionOrder(-2000)]
    public sealed class ToastManager : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private ToastUI _toastView;

        [Header("Timing")]
        [SerializeField] private float _defaultDuration = 2.5f;
        [SerializeField] private float _fadeDuration = 0.35f;
        [SerializeField] private float _moveDistance = 30f;

        [Header("Easing")]
        [SerializeField] private Ease _easeIn = Ease.OutCubic;
        [SerializeField] private Ease _easeOut = Ease.InCubic;

        private readonly Queue<ToastRequest> _queue = new();
        private bool _isProcessing;
        private Vector2 _restingPosition;

        private struct ToastRequest
        {
            public string Message;
            public float Duration;
            public ToastType Type;
        }

        private void Awake()
        {
            RectTransform rt = _toastView.GetComponent<RectTransform>();
            _restingPosition = rt.anchoredPosition;
        }

        public void Show(string message, float duration = -1f, ToastType type = ToastType.Info)
        {
            _queue.Enqueue(new ToastRequest
            {
                Message = message,
                Duration = duration > 0f ? duration : _defaultDuration,
                Type = type
            });

            if (!_isProcessing)
            {
                StartCoroutine(ProcessQueue());
            }
        }

        private IEnumerator ProcessQueue()
        {
            _isProcessing = true;

            while (_queue.Count > 0)
            {
                ToastRequest request = _queue.Dequeue();
                yield return StartCoroutine(ShowToast(request));
            }

            _isProcessing = false;
        }

        private IEnumerator ShowToast(ToastRequest request)
        {
            _toastView.Setup(request.Message, request.Type);

            RectTransform rt = _toastView.RectTransform;
            CanvasGroup cg = _toastView.CanvasGroup;

            Vector2 startPos = _restingPosition + new Vector2(0f, -_moveDistance);
            Vector2 endPos = _restingPosition + new Vector2(0f, _moveDistance);

            cg.alpha = 0f;
            rt.anchoredPosition = startPos;

            yield return Sequence.Create()
                .Group(Tween.Alpha(cg, 0f, 1f, _fadeDuration, _easeIn))
                .Group(Tween.UIAnchoredPosition(rt, startPos, _restingPosition, _fadeDuration, _easeIn))
                .ChainDelay(request.Duration)
                .Chain(Tween.Alpha(cg, 1f, 0f, _fadeDuration, _easeOut))
                .Group(Tween.UIAnchoredPosition(rt, _restingPosition, endPos, _fadeDuration, _easeOut))
                .ToYieldInstruction();
        }
    }
}
