using AnatomyJam.Material;
using AnatomyJam.SO;
using UnityEngine;

namespace AnatomyJam.SceneObjects
{
    public class SceneObject : MonoBehaviour
    {
        public GameObject GameObject { set; get; }
        public ResourceType Resource { set; get; }
        private Gem _gem;
        private Metal _metal;

        public void Init(ObjectInfo info, GameObject gameObject)
        {
            Resource = info.ResourceType;
            _gem = info.Gem;
            _metal = info.Metal;
            GameObject = gameObject;
        }

        public void DestroyObject()
        {
            Destroy(GameObject);
            GameObject = null;
        }
    }
}
