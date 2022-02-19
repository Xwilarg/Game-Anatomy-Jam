using AnatomyJam.SO;
using UnityEngine;

namespace AnatomyJam.SceneObjects
{
    public class SceneObject : MonoBehaviour
    {
        private ObjectInfo _info;

        public void Init(ObjectInfo info)
        {
            _info = info;
        }
    }
}
