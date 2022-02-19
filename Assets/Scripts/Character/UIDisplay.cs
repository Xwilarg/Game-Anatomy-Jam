using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnatomyJam.Character
{
    public class UIDisplay : MonoBehaviour
    {
        [SerializeField]
        private ProgressBar _health, _mana;

        [SerializeField]
        private TMP_Text _name;

        [SerializeField]
        private Image _image;

        [SerializeField]
        private SO.CharacterInfo _info;

        private int _maxHealth, _maxMana;
        private int _currentHealth, _currentMana;

        private void Start()
        {
            _maxHealth = _info.BaseHealth;
            _maxMana = _info.BaseMana;
            _currentHealth = _maxHealth;
            _currentMana = _maxMana;

            _name.text = _info.Name;
        }
    }
}