using AnatomyJam.Player;
using AnatomyJam.SO;
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
    }
}

