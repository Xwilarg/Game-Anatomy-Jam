using UnityEngine;

namespace Minigame
{
    public class BarTranslation : MonoBehaviour
    {
        private RectTransform _rect;

        private float _offset;

        [SerializeField]
        private RectTransform _canvas;

        private void Start()
        {
            _rect = (RectTransform)transform;
            _offset = _canvas.sizeDelta.x / 20f;
        }

        private void FixedUpdate()
        {
            var lengthCanvas = _canvas.sizeDelta.x / 2f;

            if (_rect.localPosition.x - (_rect.sizeDelta.x / 2f) < -1f * lengthCanvas)
            {
                _offset = lengthCanvas / 50f;
            }
            else if (_rect.localPosition.x + (_rect.sizeDelta.x / 2f) > lengthCanvas)
            {
                _offset = (lengthCanvas / 50f) * -1f;
            }

            _rect.localPosition = new(
                _rect.localPosition.x + _offset,
                _rect.localPosition.y
            );
        }
    }
}
