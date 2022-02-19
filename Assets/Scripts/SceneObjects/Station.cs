using AnatomyJam.Player;
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

        [SerializeField]
        private Transform _output;

        public void Deposit(PlayerController pc, SceneObject obj)
        {
            StartCoroutine(Build(pc, obj));
        }

        public IEnumerator Build(PlayerController pc, SceneObject obj)
        {
            yield return new WaitForSeconds(3f);

            var result = _recipes.FirstOrDefault(x => x.Input.ResourceType == obj.Resource);
            if (result != null) // Craft failed
            {
                obj.Resource = result.Output.ResourceType;
                obj.GameObject = Instantiate(result.Output.GameObject, _output.position, Random.rotation);
                var opDir = (_output.position - transform.position).normalized;
                obj.GameObject.GetComponent<Rigidbody>().AddForce((opDir + Vector3.up).normalized, ForceMode.Impulse);
                obj.GameObject.GetComponent<Interactible>().AddListener(() => { pc.AddObjectInHands(obj); });
            }
        }
    }
}

