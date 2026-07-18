using UnityEngine;
using UnityEngine.EventSystems;

namespace GmtkJam2026
{
    public sealed class TooltipTriggerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private string _header;
        [SerializeField, TextArea] private string _body;
        [SerializeField, Min(0f)] private float _delay = 0.5f;

        public void OnPointerEnter(PointerEventData eventData)
        {
           Invoke(nameof(Show), _delay);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CancelInvoke(nameof(Show));
            Manager.TooltipManager.Hide();
        }

        private void Show()
        {
            Manager.TooltipManager.Show(_body, _header);
        }
    }
}
