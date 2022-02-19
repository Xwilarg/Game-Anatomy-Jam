﻿using AnatomyJam.SO;
using UnityEngine;

namespace AnatomyJam.Character
{
    [System.Serializable]
    public class CharacterBehavior
    {
        private int _maxHealth, _maxMana;
        private int _currentHealth, _currentMana;

        private UIDisplay _display;
        private SO.CharacterInfo _info;

        public float _timeBeforeAttack;

        public CharacterBehavior(UIDisplay display, SO.CharacterInfo info)
        {
            _display = display;
            _info = info;

            _maxHealth = info.BaseHealth;
            _maxMana = info.BaseMana;
            _currentHealth = _maxHealth;
            _currentMana = _maxMana;
            display.Init(info);
        }

        public bool IsAlive => _currentHealth > 0;
        public bool CanAttack => _timeBeforeAttack <= 0f;
        public TargetType TargetType => _info.Type;

        /// <summary>
        /// Lower health given the damage given in parameter
        /// If damage is negative, will heal the character instead
        /// </summary>
        public void TakeDamage(int value)
        {
            // Substract armor
            if (value > 0)
            {
                value = Mathf.Clamp(_info.BaseArmor - value, 0, _info.BaseArmor);
            }
            _currentHealth = Mathf.Clamp(_currentHealth - value, 0, _maxHealth);
            _display.UpdateHealth(value, _maxHealth);
        }

        /// <summary>
        /// Attack the target given in parameter
        /// </summary>
        public void Attack(CharacterBehavior target)
        {
            target.TakeDamage(_info.BaseAttack);
            ResetTimerAttack();
        }

        /// <summary>
        /// Called when a fight start, reset the state
        /// </summary>
        public void ReadyForFight()
        {
            ResetTimerAttack();
        }

        /// <summary>
        /// Called every frame, reduce the attack timer
        /// </summary>
        public void PassTime(float deltaTime)
        {
            _timeBeforeAttack -= deltaTime;
        }

        /// <summary>
        /// Called once an attack was done, reset the timer for the next attack
        /// </summary>
        private void ResetTimerAttack()
        {
            _timeBeforeAttack = Random.Range(_info.AttackSpeed.Min, _info.AttackSpeed.Max);
        }

        public override string ToString() => $"{_info.Name} ({_info.Class}): {_currentHealth} / {_maxHealth} HP";
    }
}