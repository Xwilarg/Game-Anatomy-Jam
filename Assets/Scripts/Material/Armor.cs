using UnityEngine;

namespace AnatomyJam.Material
{
    public class Armor : MonoBehaviour
    {
        [SerializeField]
        private int _value;

        public int Value => _value;
    }
}
