using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

namespace GmtkJam2026
{
    [DefaultExecutionOrder(-2000)]
    public sealed class DialogManager : MonoBehaviour
    {
        [SerializeField] private float _fadeDuration = 0.25f;
        [SerializeField] private float _scaleFrom = 0.85f;
        [SerializeField] private Ease _easeIn = Ease.OutCubic;
        [SerializeField] private Ease _easeOut = Ease.InCubic;

        private readonly Stack<ScreenUI> _dialogStack = new();

        public void Push(ScreenUI dialog)
        {
            _dialogStack.Push(dialog);
            Open(dialog);
        }

        public void Pop()
        {
            if (_dialogStack.Count == 0)
            {
                return;
            }

            ScreenUI current = _dialogStack.Pop();
            Close(current);
        }

        private void Open(ScreenUI dialog)
        {
            RectTransform rt = dialog.Rt;
            CanvasGroup cg = dialog.CanvasGroup;

            Tween.StopAll(rt);
            Tween.StopAll(cg);

            cg.blocksRaycasts = true;
            cg.alpha = 0f;
            rt.localScale = dialog.RestingScale * _scaleFrom;

            Tween.Scale(rt, dialog.RestingScale, _fadeDuration, _easeIn);
            Tween.Alpha(cg, 1f, _fadeDuration, _easeIn);
        }

        private void Close(ScreenUI dialog)
        {
            RectTransform rt = dialog.Rt;
            CanvasGroup cg = dialog.CanvasGroup;

            Tween.StopAll(rt);
            Tween.StopAll(cg);

            cg.blocksRaycasts = false;

            Tween.Scale(rt, dialog.RestingScale * _scaleFrom, _fadeDuration, _easeOut);
            Tween.Alpha(cg, 0f, _fadeDuration, _easeOut);
        }
    }
}
