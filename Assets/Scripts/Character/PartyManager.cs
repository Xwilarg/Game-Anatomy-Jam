using System.Linq;
using UnityEngine;

namespace AnatomyJam.Character
{
    public class PartyManager : MonoBehaviour
    {
        [SerializeField]
        public UIDisplay[] _displays;

        private CharacterBehavior[] _team;

        private void Start()
        {
            _team = _displays.Select(x => new CharacterBehavior(x, x.Info)).ToArray();
        }
    }
}
