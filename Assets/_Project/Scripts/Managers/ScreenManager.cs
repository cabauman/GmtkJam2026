using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

namespace GmtkJam2026
{
    [DefaultExecutionOrder(-2000)]
    public sealed class ScreenManager : MonoBehaviour
    {
        [SerializeField] private float _fadeDuration = 0.25f;
        [SerializeField] private float _moveDistance = 40f;
        [SerializeField] private Ease _easeIn = Ease.OutCubic;
        [SerializeField] private Ease _easeOut = Ease.InCubic;

        private readonly Stack<ScreenUI> _screenStack = new();

        public void Push(ScreenUI screen)
        {
            if (_screenStack.Count > 0)
            {
                Close(_screenStack.Peek());
            }

            _screenStack.Push(screen);
            Open(screen);
        }

        public void Pop()
        {
            if (_screenStack.Count == 0)
            {
                return;
            }

            ScreenUI current = _screenStack.Pop();
            Close(current);

            if (_screenStack.Count > 0)
            {
                Open(_screenStack.Peek());
            }
        }

        private void Open(ScreenUI screen)
        {
            RectTransform rt = screen.Rt;
            CanvasGroup cg = screen.CanvasGroup;

            Tween.StopAll(rt);
            Tween.StopAll(cg);

            cg.blocksRaycasts = true;
            cg.alpha = 0f;
            rt.anchoredPosition = screen.RestingPosition - new Vector2(0f, _moveDistance);

            Tween.UIAnchoredPosition(rt, screen.RestingPosition, _fadeDuration, _easeIn);
            Tween.Alpha(cg, 1f, _fadeDuration, _easeIn);
        }

        private void Close(ScreenUI screen)
        {
            RectTransform rt = screen.Rt;
            CanvasGroup cg = screen.CanvasGroup;

            Tween.StopAll(rt);
            Tween.StopAll(cg);

            cg.blocksRaycasts = false;

            Vector2 endPos = screen.RestingPosition - new Vector2(0f, _moveDistance);
            Tween.UIAnchoredPosition(rt, endPos, _fadeDuration, _easeOut);
            Tween.Alpha(cg, 0f, _fadeDuration, _easeOut);
        }
    }
}
