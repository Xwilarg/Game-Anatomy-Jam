using AnatomyJam.Player;
using AnatomyJam.SO;
using System.Collections;
using UnityEngine;

namespace AnatomyJam.Manager
{
    public class ProgressManager : MonoBehaviour
    {
        public static ProgressManager S;

        private void Awake()
        {
            S = this;
        }

        [SerializeField]
        private MapZone[] _zones;

        // ANIMATION
        [SerializeField]
        private Animator _animWin;

        [SerializeField]
        private AnimatorOverrideController _anim1, _anim2, _anim3;

        [SerializeField]
        private GameObject _village2Unlock, _village3Unlock;

        private int _currentZone;
        private int _currentFight;

        private int _bossNode;

        public MapZone CurrentZone => _zones[_currentZone];

        private void Start()
        {
            InitCurrentZone();
        }

        public void InitCurrentZone()
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

        public void WinFight(System.Action next)
        {
            if (_currentFight == _bossNode)
            {
                _animWin.gameObject.SetActive(true);

                if (_currentZone == 1)
                {
                    _animWin.runtimeAnimatorController = _anim2;
                    _village2Unlock.SetActive(true);
                }
                else if (_currentZone == 2)
                {
                    _animWin.runtimeAnimatorController = _anim3;
                    _village3Unlock.SetActive(true);
                }

                StartCoroutine(WaitCoroutine(next));
                _currentZone++;
                InitCurrentZone();
            }
            else
            {
                _currentFight++;
                next?.Invoke();
            }
        }

        public IEnumerator WaitCoroutine(System.Action next)
        {
            PlayerController.S.CanMove = false;

            yield return new WaitForSeconds(3.4f * 4f);
            _animWin.gameObject.SetActive(false);
            next?.Invoke();

            PlayerController.S.CanMove = true;
            _animWin.gameObject.SetActive(false);
        }
    }
}
