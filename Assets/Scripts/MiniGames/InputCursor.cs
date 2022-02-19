using UnityEngine;
using UnityEngine.InputSystem;

namespace Minigame
{
    public class InputCursor : MonoBehaviour
    {
        private RectTransform _rect;

        [SerializeField]
        private RectTransform _target;

        private void Start()
        {
            _rect = (RectTransform)transform;
        }

        public void Hit(InputAction.CallbackContext value)
        {
            var targetXtLeft = _target.localPosition.x - (_target.sizeDelta.x / 2f);
            var targetXtRight = _target.localPosition.x + (_target.sizeDelta.x / 2f);

            if (value.performed
            && _rect.localPosition.x >= targetXtLeft
            && _rect.localPosition.x <= targetXtRight)
            {
                Debug.Log("success");
            }
        }
    }
}
