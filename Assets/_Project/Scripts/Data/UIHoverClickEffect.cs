using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GmtkJam2026
{
    public sealed class UIHoverClickEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private UIHoverClickEffectData _effectData;

        private float _originalScale;
        private  AudioManager _audioManager;
        private Tween _tween;

        private void Awake()
        {
            _originalScale = transform.localScale.x;
            _audioManager = Manager.AudioManager;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PlaySound(_effectData.HoverSound);
            _tween.Stop();
            _tween = Tween.Scale(transform, _effectData.HoverScale, _effectData.HoverDuration, _effectData.HoverEase);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _tween.Stop();
            _tween = Tween.Scale(transform, _originalScale, _effectData.HoverDuration, _effectData.HoverEase);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _tween.Stop();
            _tween = Tween.Scale(transform, _effectData.ClickScale, _effectData.ClickDuration);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PlaySound(_effectData.ClickSound);
            _tween.Stop();
            _tween = Tween.Scale(transform, _originalScale, _effectData.ClickDuration);
        }

        private void PlaySound(AudioClip clip)
        {
            if (clip != null)
            {
                _audioManager.PlaySfx(clip);
            }
        }
    }
}
