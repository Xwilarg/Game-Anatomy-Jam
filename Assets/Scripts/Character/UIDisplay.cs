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
    }
}