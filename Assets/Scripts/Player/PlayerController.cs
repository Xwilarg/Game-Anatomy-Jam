using AnatomyJam.SceneObjects;
using AnatomyJam.SO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AnatomyJam.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Transform _handsContainer;

        private Rigidbody _rb;
        private Vector2 _mov;

        private Vector3 _initPos;

        private Interactible _currentInteraction;
        private SceneObject _inHands;

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

        public void AddObjectInHands(ObjectInfo obj)
        {
            var go = Instantiate(obj.GameObject, _handsContainer);
            go.transform.localPosition = Vector3.zero;
            _inHands = go.GetComponent<SceneObject>();
            var coll = go.GetComponent<Collider>();
            var rb = go.GetComponent<Rigidbody>();
            if (coll != null)
            {
                coll.enabled = false;
            }
            if (rb != null)
            {
                rb.isKinematic = false;
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
                if (_currentInteraction != null)
                {
                    _currentInteraction.Invoke();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var otherC = other.GetComponent<Interactible>();
            if (otherC != null)
            {
                _currentInteraction = otherC;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var otherC = other.GetComponent<Interactible>();
            if (_currentInteraction == otherC)
            {
                _currentInteraction = null;
            }
        }
    }
}
