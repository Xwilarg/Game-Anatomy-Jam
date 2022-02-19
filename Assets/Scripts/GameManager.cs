using AnatomyJam.Character;
using AnatomyJam.Map;
using System.Collections;
using UnityEngine;

namespace AnatomyJam
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private PartyManager _party;

        [SerializeField]
        private MapScroller _scroller;

        [SerializeField]
        private UIDisplay _displayEnemy;

        [SerializeField]
        private SO.CharacterInfo[] _enemies;

        private CharacterBehavior _currentEnemy;

        private bool _isFighting;

        private void Start()
        {
            StartCoroutine(BeginRun());
        }

        private IEnumerator BeginRun()
        {
            _isFighting = false;

            // Update display and enable scrolling to make so that characters are moving

            _scroller.IsScrolling = true;
            _displayEnemy.Toggle(false);
            yield return new WaitForSeconds(3f);
            _scroller.IsScrolling = false;
            _displayEnemy.Toggle(true);

            // Movement done, we set the current enemy
            _currentEnemy = new(_displayEnemy, _enemies[Random.Range(0, _enemies.Length)]);

            // Reset state for everyone
            _party.ReadyForFight();
            _currentEnemy.ReadyForFight();

            _isFighting = true;
        }

        private void Update()
        {
            if (_isFighting)
            {
                _party.UpdateTimers(_currentEnemy, Time.deltaTime);
                if (_currentEnemy.IsAlive)
                {
                    _currentEnemy.PassTime(Time.deltaTime);
                    if (_currentEnemy.CanAttack)
                    {
                        _currentEnemy.Attack(_party.GetRandomCharacter());

                        // Is hero party still alive?
                        if (!_party.IsPartyAlive)
                        {
                            // TODO: Go back to the base to take new weapons
                            _isFighting = false;
                        }
                    }
                }
                else
                {
                    // Enemy was killed, let's fight the next one
                    StartCoroutine(BeginRun());
                }
            }
        }
    }
}