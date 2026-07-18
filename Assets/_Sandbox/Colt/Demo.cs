using TMPro;
using UnityEngine;

namespace GmtkJam2026
{
    public sealed class Demo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _bodyText;

        private void Start()
        {
            Manager.ToastManager.Show("This is a toast!");
            Manager.ToastManager.Show("This is another toast!");
        }
    }
}
