using UnityEngine;

namespace AnatomyJam.SO
{
    [CreateAssetMenu(menuName = "ScriptableObject/CharacterInfo", fileName = "CharacterInfo")]
    public class CharacterInfo : ScriptableObject
    {
        public string Name;

        public int BaseHealth;
        public int BaseMana;

        public float BaseArmor;
        public float BaseAttack;

        public CharacterClass Class;
    }
}
