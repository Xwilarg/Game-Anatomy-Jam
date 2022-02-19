using UnityEngine;
using UnityEngine.InputSystem;

namespace AnatomyJam.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rb;
        private Vector2 _mov;

        private Vector3 _initPos;

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
    }
}
