using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnatomyJam.Chest
{
    public class Chest : MonoBehaviour
    {
        [SerializeField]
        public AnatomyJam.SO.ResourceType Type { get; private set; }
    }
}

