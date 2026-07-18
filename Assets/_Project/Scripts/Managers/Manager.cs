using UnityEngine;

namespace GmtkJam2026
{
    [DefaultExecutionOrder(-2000)]
    public sealed class Manager : MonoBehaviour
    {
        public static DialogManager DialogManager { get; private set; }
        public static ScreenManager ScreenManager { get; private set; }
        public static ToastManager ToastManager { get; private set; }
        public static TooltipManager TooltipManager { get; private set; }
        public static AudioManager AudioManager { get; private set; }

        private void Awake()
        {
            DialogManager = GetComponentInChildren<DialogManager>();
            AudioManager = GetComponentInChildren<AudioManager>();
            ScreenManager = GetComponentInChildren<ScreenManager>();
            ToastManager = GetComponentInChildren<ToastManager>();
            TooltipManager = GetComponentInChildren<TooltipManager>();
        }
    }
}
