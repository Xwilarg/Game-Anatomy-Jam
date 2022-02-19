using System;
using UnityEngine;
using UnityEngine.Events;

namespace AnatomyJam.SceneObjects
{
    public class Interactible : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onAction;

        public void Invoke()
        {
            _onAction?.Invoke();
        }

        private static int _id = 0;

        private int _myId = _id++;

        public static bool operator ==(Interactible a, Interactible b)
            => a.Equals(b);
        public static bool operator !=(Interactible a, Interactible b)
            => !a.Equals(b);

        public override bool Equals(object obj)
        {
            if (this is null)
            {
                return obj is null;
            }
            if (obj is null || obj is not Interactible inc)
            {
                return false;
            }
            return _myId == inc._myId;
        }

        public override int GetHashCode()
            => _myId.GetHashCode();
    }
}
