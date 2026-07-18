using UnityEngine;
using UnityEngine.UI;

namespace GmtkJam2026.DevToolbox
{
    public class MaxLayoutElement : MonoBehaviour, ILayoutElement
    {
        [SerializeField] private float _maxWidth = -1f;

        private ILayoutElement _layoutElement;

        private ILayoutElement layoutElement
        {
            get
            {
                if (_layoutElement == null)
                {
                    _layoutElement = GetComponent<LayoutGroup>();
                }
                if (_layoutElement == null)
                {
                    _layoutElement = GetComponent<ILayoutElement>();
                }

                return _layoutElement;
            }
        }


        public float minWidth => layoutElement.minWidth;

        public float preferredWidth => _maxWidth > 0
            ? Mathf.Min(layoutElement.preferredWidth, _maxWidth)
            : layoutElement.preferredWidth;

        public float flexibleWidth => layoutElement.flexibleWidth;
        public float minHeight => layoutElement.minHeight;
        public float preferredHeight => layoutElement.preferredHeight;

        public float flexibleHeight => layoutElement.flexibleHeight;

        public int layoutPriority => 10;

        public void CalculateLayoutInputHorizontal()
        {
            layoutElement.CalculateLayoutInputHorizontal();
        }

        public void CalculateLayoutInputVertical()
        {
            layoutElement.CalculateLayoutInputVertical();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
        }
#endif
    }
}
