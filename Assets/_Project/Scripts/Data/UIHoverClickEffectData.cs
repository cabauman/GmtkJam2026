using PrimeTween;
using UnityEngine;

namespace GmtkJam2026
{
    [CreateAssetMenu(menuName = "GmtkJam2026/UI/HoverClickEffectData")]
    public sealed class UIHoverClickEffectData : ScriptableObject
    {
        [Header("Hover")]
        public float HoverScale = 1.1f;
        public float HoverDuration = 0.2f;
        public Ease HoverEase = Ease.OutCubic;
        public AudioClip HoverSound;

        [Header("Click")]
        public float ClickScale = 0.9f;
        public float ClickDuration = 0.1f;
        public AudioClip ClickSound;
    }
}
