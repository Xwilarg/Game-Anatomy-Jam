using AnatomyJam.SO;
using UnityEngine;

namespace AnatomyJam.SceneObjects
{
    public class SceneObject : MonoBehaviour
    {
        public ObjectInfo Info { private set; get; }
        public GameObject GameObject { set; get; }

        public void Init(ObjectInfo info, GameObject gameObject)
        {
            Info = info;
            GameObject = gameObject;
        }
    }
}
