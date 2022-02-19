using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnatomyJam.Character
{
    public class UIDisplay : MonoBehaviour
    {
        [SerializeField]
        private SO.CharacterInfo _info;

        [SerializeField]
        private ProgressBar _health, _mana;

        [SerializeField]
        private TMP_Text _name;

        [SerializeField]
        private Image _image;

        [SerializeField]
        private SpriteRenderer _sprite;

        public SO.CharacterInfo Info => _info;

        public void Toggle(bool value)
        {
            _name.gameObject.SetActive(value);
            _health.gameObject.SetActive(value);
            _sprite.gameObject.SetActive(value);
        }

        public void Init(SO.CharacterInfo info)
        {
            _name.text = info.Name;
            _health.SetValue(1f);
        }

        public void UpdateHealth(int value, int max)
        {
            _health.SetValue(value / (float)max);
            if (value == 0)
            {
                _sprite.gameObject.SetActive(false);
            }
        }
    }
}