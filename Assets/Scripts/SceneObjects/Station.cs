using System.Collections.Generic;
using UnityEngine;


namespace AnatomyJam.SceneObject.Station
{
    public class Station : MonoBehaviour
    {
        [SerializeField]
        private SO.ResourceType[] _allowedRessources;
        [SerializeField]
        private int recipeLength = 1;

        //TODO change to Gameobject?
        private List<SO.ResourceType> _storedRessources;

        //TODO, probably subclass for the hero equipment chests

        public void Deposit(SO.ResourceType type)
        {
            _storedRessources.Add(type);

            if (_storedRessources.Count == recipeLength)
            {
                //check recipe and run minigame

                _storedRessources.Clear();
            }
        }
    }
}

