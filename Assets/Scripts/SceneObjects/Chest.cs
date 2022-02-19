using UnityEngine;

namespace AnatomyJam.Chest
{
    public class Chest : MonoBehaviour
    {
        [SerializeField]
        public SO.ResourceType Type { get; private set; }
    }
}

