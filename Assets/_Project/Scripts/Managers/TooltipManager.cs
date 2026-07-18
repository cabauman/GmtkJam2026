using UnityEngine;

namespace GmtkJam2026
{
    [DefaultExecutionOrder(-2000)]
    public sealed class TooltipManager : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private TooltipUI _tooltip;

        public void Show(string body, string header = null)
        {
            _tooltip.SetText(body, header);
            _tooltip.transform.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _tooltip.transform.gameObject.SetActive(false);
        }
    }
}
