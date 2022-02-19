using AnatomyJam.SceneObjects;
using AnatomyJam.SceneObjects.Station;
using AnatomyJam.SO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AnatomyJam.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Transform _handsContainer;

        [SerializeField]
        private GameObject _pressE;

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
            if (_mov != Vector2.zero)
            {
                transform.rotation = Quaternion.LookRotation(new(_mov.x, 0f, _mov.y));
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Player falled in lava, we reset his position
            if (collision.collider.CompareTag("Lava"))
            {
                transform.position = _initPos;
            }
        }

        // TODO: Somehow merge the 2 methods together

        public void AddObjectInHands(SceneObject obj)
        {
            Destroy(obj.GameObject);
            var go = Instantiate(obj.GameObject, _handsContainer);
            go.transform.localPosition = Vector3.zero;

            _inHands = obj;

            foreach (var coll in go.GetComponents<Collider>())
            {
                coll.enabled = false;
            }
            var rb = go.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }

        public void AddObjectInHands(ObjectInfo obj)
        {
            var go = Instantiate(obj.GameObject, _handsContainer);
            go.transform.localPosition = Vector3.zero;

            _inHands = go.GetComponent<SceneObject>();
            _inHands.Init(obj, go);

            foreach (var coll in go.GetComponents<Collider>())
            {
                coll.enabled = false;
            }
            var rb = go.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }

        public void AddObjectToStation(AStation station)
        {
            if (_inHands != null)
            {
                _inHands.DestroyObject();
                station.Deposit(this, _inHands);
                _inHands = null;
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
                _pressE.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var otherC = other.GetComponent<Interactible>();
            if (_currentInteraction == otherC)
            {
                _currentInteraction = null;
                _pressE.SetActive(false);
            }
        }
    }
}
