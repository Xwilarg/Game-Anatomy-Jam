﻿using AnatomyJam.Character;
using AnatomyJam.Player;
using System.Linq;
using UnityEngine;


namespace AnatomyJam.SceneObjects.Station
{
    public class TimerStation : AStation
    {
        [SerializeField]
        private ProgressBar _progress;

        private float _timer = -1f;

        private SceneObject _obj;
        private PlayerController _pc;

        private const float _maxTimer = 3f;

        public override void Deposit(PlayerController pc, SceneObject obj)
        {
            _pc = pc;
            _obj = obj;
            _timer = _maxTimer;
            _progress.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (_timer > 0f)
            {
                _timer -= Time.deltaTime;
                if (_timer <= 0f)
                {
                    _timer = 0f;
                    var result = GetRecipe(_obj);
                    ThrowOnFloor(_pc, _obj, result);
                    _progress.gameObject.SetActive(false);
                }
                else
                {
                    _progress.SetValue(_timer / _maxTimer);
                }
            }
        }
    }
}
