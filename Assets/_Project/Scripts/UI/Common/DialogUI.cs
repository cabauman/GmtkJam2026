using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GmtkJam2026
{
    public sealed class DialogUI : MonoBehaviour
    {
        [Header("Header")]
        [SerializeField] private GameObject _headerArea;
        [SerializeField] private TextMeshProUGUI _headerText;

        [Header("Body")]
        [SerializeField] private GameObject _bodyArea;
        [SerializeField] private TextMeshProUGUI _bodyText;
        [SerializeField] private Image _bodyImage;

        [Header("Footer")]
        [SerializeField] private GameObject _footerArea;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private Button _alternateButton;

        private Action _onConfirm;
        private Action _onCancel;
        private Action _onAlternate;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public DialogUI WithTitle(string title)
        {
            _headerArea.SetActive(true);
            _headerText.text = title;
            return this;
        }

        public DialogUI WithBody(string body)
        {
            _bodyArea.SetActive(true);
            _bodyText.text = body;
            return this;
        }

        public DialogUI WithImage(Sprite image)
        {
            _bodyArea.SetActive(true);
            _bodyImage.sprite = image;
            return this;
        }

        public DialogUI WithConfirmButton(string text, Action onConfirm)
        {
            _footerArea.SetActive(true);
            _confirmButton.gameObject.SetActive(true);
            _confirmButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
            _onConfirm = onConfirm;
            return this;
        }

        public DialogUI WithCancelButton(string text, Action onCancel)
        {
            _footerArea.SetActive(true);
            _cancelButton.gameObject.SetActive(true);
            _cancelButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
            _onCancel = onCancel;
            return this;
        }

        public DialogUI WithAlternateButton(string text, Action onAlternate)
        {
            _footerArea.SetActive(true);
            _alternateButton.gameObject.SetActive(true);
            _alternateButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
            _onAlternate = onAlternate;
            return this;
        }

        public void Confirm()
        {
            _onConfirm?.Invoke();
            Close();
        }

        public void Cancel()
        {
            _onCancel?.Invoke();
            Close();
        }

        public void Alternate()
        {
            _onAlternate?.Invoke();
            Close();
        }

        private void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
