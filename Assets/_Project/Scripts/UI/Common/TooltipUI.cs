using TMPro;
using UnityEngine;

namespace GmtkJam2026
{
    public sealed class TooltipUI : MonoBehaviour
    {
        [SerializeField] private RectTransform _rt;
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _bodyText;

        private void Update()
        {
            Vector2 mousePos = UnityEngine.InputSystem.Mouse.current.position.ReadValue();
            float pivotX = mousePos.x / Screen.width;
            float pivotY = mousePos.y / Screen.height;
            _rt.pivot = new Vector2(pivotX, pivotY);
            transform.position = mousePos;
        }

        public void SetText(string body, string header = null)
        {
            _bodyText.text = body;

            if (string.IsNullOrEmpty(header))
            {
                _headerText.gameObject.SetActive(false);
            }
            else
            {
                _headerText.text = header;
                _headerText.gameObject.SetActive(true);
            }

            Update();
        }
    }
}
