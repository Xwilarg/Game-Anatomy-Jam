using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Minigame
{
    public class QuenchingManager : AMiniGameManager
    {
        [SerializeField]
        private Slider _scroller;

        [SerializeField]
        private TMP_Text _text;


        private float _negative_rate = 0.3f;

        private float _positive_rate = 0.05f;

        private float _currentVal = 0f;

        private MinigameCallBack _cb_result;
        // Update is called once per frame
        void Update()
        {
            _currentVal -= _negative_rate * Time.deltaTime;
            if (_currentVal < 0)
                _currentVal = 0;
            _scroller.value = _currentVal;

        }


        public void Hit(InputAction.CallbackContext value)
        {
            if (!gameObject.activeSelf)
                return;
            if (value.phase == InputActionPhase.Started)
            {
                _currentVal += _positive_rate;
                _scroller.value = _currentVal;

                if (_currentVal >= 1)
                {
                    _cb_result();
                    gameObject.SetActive(false);
                }
            }

        }

        public override void RunMinigame(MinigameCallBack cb_result, int difficultyFactor)
        {
            _cb_result = cb_result;
            _currentVal = 0;
            base.RunMinigame(cb_result, difficultyFactor);
        }
    }
}