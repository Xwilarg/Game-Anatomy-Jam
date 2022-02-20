using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace AnatomyJam.Character
{
    public class PartyManager : MonoBehaviour
    {
        [SerializeField]
        public UIDisplay[] _displays;

        private CharacterBehavior[] _team;

        private List<int> _characterStuff = new List<int>(4);

        private void Awake()
        {
            _team = _displays.Select(x => new CharacterBehavior(x, x.Info)).ToArray();
        }

        public bool IsPartyAlive => _team.Any(x => x.IsAlive);

        public CharacterBehavior GetRandomCharacter()
        {
            var stillAlive = _team.Where(x => x.IsAlive).ToArray();
            return stillAlive[Random.Range(0, stillAlive.Length)];
        }

        public void Revive()
        {
            foreach (var character in _team)
            {
                character.Revive();
            }
        }

        public void ReadyForFight()
        {
            foreach (var character in _team)
            {
                character.ReadyForFight();
            }
        }

        public void SetRunningState(bool value)
        {
            foreach (var character in _team)
            {
                character.ToggleWalkAnimation(value);
            }
        }

        public void UpdateTimers(CharacterBehavior target, float deltaTime)
        {
            foreach (var character in _team)
            {
                if (!character.IsAlive)
                {
                    // KOed characters can't fight
                    continue;
                }

                character.PassTime(deltaTime);
                if (character.CanAttack)
                {
                    character.Attack(character.TargetType == SO.TargetType.Enemy ? target : GetRandomCharacter());
                }
            }
        }

        public void Rearm()
        {
            for (int i = 0; i < _characterStuff.Count; i++)
            {
                _team.First(x => x._info.Class == (AnatomyJam.SO.CharacterClass)i).AddLevel(_characterStuff[i]);
                _characterStuff[i] = 0;
            }
        }

        public void GiveItem(int level, AnatomyJam.SO.CharacterClass hero_ID)
        {
            _characterStuff[(int)hero_ID] += level;
        }
    }
}
