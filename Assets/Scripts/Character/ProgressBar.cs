using UnityEngine;

namespace AnatomyJam.Character
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _bar;

        private float _maxSize;

        private void Start()
        {
            _maxSize = _bar.sizeDelta.x;
        }

        /// <summary>
        /// Set the value of the progress bar
        /// </summary>
        /// <param name="value">Value to set, between 0 and 1</param>
        public void SetValue(float value)
        {
            _bar.sizeDelta = new Vector2(value * _maxSize, _bar.sizeDelta.y);
        }
    }
}
