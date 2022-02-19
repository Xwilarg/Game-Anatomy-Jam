using UnityEngine;
using UnityEngine.InputSystem;

namespace Minigame
{
    public class InputCursor : MonoBehaviour
    {
        private RectTransform _rect;

        private float _offset;

        [SerializeField]
        private RectTransform _cursor;

        private void Start()
        {
            _rect = (RectTransform)transform;
        }

        private void FixedUpdate()
        {
        }
        public void OnInventory(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
            }
        }
    }
}
