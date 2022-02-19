using AnatomyJam.SO;
using System.Collections;
using System.Linq;
using UnityEngine;


namespace AnatomyJam.SceneObjects
{
    public class Station : MonoBehaviour
    {
        [SerializeField]
        private RecipeInfo[] _recipes;


        public void Deposit(ObjectInfo obj)
        {
            StartCoroutine(Build(obj.ResourceType));
        }

        public IEnumerator Build(ResourceType res)
        {
            yield return new WaitForSeconds(3f);

            var result = _recipes.FirstOrDefault(x => x.Input == res);
            if (result != null) // Craft failed
            {
                // TODO: Recrache result.Output
            }
        }
    }
}

