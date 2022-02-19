using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AnatomyJam.SceneObject.Station
{
    public class Station : MonoBehaviour
    {
        [SerializeField]
        private AnatomyJam.SO.ResourceType[] _allowedRessources;
        [SerializeField]
        private int recipeLength = 1;


        private List<AnatomyJam.SO.ResourceType> _storedRessources;



        public void Deposit(AnatomyJam.SO.ResourceType type)
        {
            _storedRessources.Add(type);

            if (_storedRessources.Count == recipeLength)
            {
                //do the thing

                _storedRessources.Clear();
            }
        }
    }
}

