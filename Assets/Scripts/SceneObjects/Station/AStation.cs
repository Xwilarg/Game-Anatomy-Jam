using AnatomyJam.Material;
using AnatomyJam.Player;
using AnatomyJam.SO;
using System.Linq;
using UnityEngine;


namespace AnatomyJam.SceneObjects.Station
{
    public abstract class AStation : MonoBehaviour
    {
        [SerializeField]
        protected RecipeInfo[] _recipes;

        [SerializeField]
        protected Transform _output;

        public abstract void Deposit(PlayerController pc, SceneObject obj);

        protected void ThrowOnFloor(PlayerController pc, SceneObject obj, RecipeInfo result)
        {
            if (result.Output.ResourceType == ResourceType.None) // This formula craft nothing
            {
                return;
            }

            obj.Resource = result.Output.ResourceType;
            obj.GameObject = Instantiate(result.Output.GameObject, _output.position, Random.rotation);
            var opDir = (_output.position - transform.position).normalized;
            obj.GameObject.GetComponent<Rigidbody>().AddForce((opDir + Vector3.up).normalized * 10f, ForceMode.Impulse);
            obj.GameObject.GetComponent<Interactible>().AddListener(() =>
            {
                Destroy(obj.GameObject);
                pc.ResetInteraction();
                var instance = ScriptableObject.CreateInstance<SO.ObjectInfo>();
                instance.GameObject = result.Output.GameObject;
                instance.Gem = obj.Gem;
                instance.Metal = obj.Metal;
                instance.ResourceType = obj.Resource;
                instance.Name = result.Output.Name;
                pc.AddObjectInHands(instance);
            });
        }

        public RecipeInfo GetRecipe(SceneObject obj)
        {
            return _recipes.FirstOrDefault(x => x.Input.ResourceType == obj.Resource && x.Input.Metal == obj.Metal && x.Input.Gem == obj.Gem);
        }
    }
}

