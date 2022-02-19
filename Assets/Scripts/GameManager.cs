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

        private void Start()
        {
            StartCoroutine(BeginRun());
        }

        private IEnumerator BeginRun()
        {
            _scroller.IsScrolling = true;
            _displayEnemy.Toggle(false);

            yield return new WaitForSeconds(3f);

            _scroller.IsScrolling = false;
            _displayEnemy.Toggle(true);
            _currentEnemy = new(_displayEnemy, _enemies[Random.Range(0, _enemies.Length)]);
        }
    }
}