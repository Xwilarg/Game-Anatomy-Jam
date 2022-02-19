using UnityEngine;
using UnityEngine.InputSystem;

namespace AnatomyJam.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rb;
        private Vector2 _mov;

        private Vector3 _initPos;

        private AnatomyJam.SO.ResourceType? _chestType;
        private AnatomyJam.SO.ResourceType _heldType;

        private GameObject _triggeredGO = null;
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _initPos = transform.position;
        }

        private void FixedUpdate()
        {
            _rb.velocity = new(_mov.x, _rb.velocity.y, _mov.y);
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Player falled in lava, we reset his position
            if (collision.collider.CompareTag("Lava"))
            {
                transform.position = _initPos;
            }
        }

        public void OnMovement(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>().normalized;
        }

        public void OnInterract(InputAction.CallbackContext value)
        {
            if (value.phase == InputActionPhase.Started)
            {
                if (_chestType.HasValue)
                {
                    _heldType = _chestType.Value;
                }  
            }
            if (_triggeredGO != null)
            {

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Chest"))
            {
                _chestType = other.gameObject.GetComponent<AnatomyJam.Chest.Chest>()?.Type;

            }
            _triggeredGO = other.gameObject;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Chest"))
            {
                _chestType = null;
            }
            _triggeredGO = null;
        }
    }
}
