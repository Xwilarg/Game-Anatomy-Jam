using AnatomyJam.SO;
using UnityEngine;

namespace AnatomyJam.Manager
{
    public class ProgressManager : MonoBehaviour
    {
        [SerializeField]
        private MapZone[] _zones;

        private int _currentZone;
        private int _currentFight;

        private int _bossNode;

        private void Start()
        {
            InitCurrentZone();
        }

        private void InitCurrentZone()
        {
            var curr = _zones[_currentZone];
            _bossNode = Random.Range(curr.NbOfEnemiesBeforeBoss.Min, curr.NbOfEnemiesBeforeBoss.Max);
            _currentFight = 0;
        }

        public SO.CharacterInfo GetCurrentEnnemy()
        {
            var curr = _zones[_currentZone];
            return _currentFight == _bossNode ? curr.Boss : curr.Encounters[Random.Range(0, curr.Encounters.Length)];
        }

        public void WinFight()
        {
            if (_currentFight == _bossNode)
            {
                _currentZone++;
                InitCurrentZone();
            }
            else
            {
                _currentFight++;
            }
        }
    }
}
