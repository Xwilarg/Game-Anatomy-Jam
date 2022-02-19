using UnityEngine;

namespace AnatomyJam.SO
{
    [CreateAssetMenu(menuName = "ScriptableObject/CharacterInfo", fileName = "CharacterInfo")]
    public class CharacterInfo : ScriptableObject
    {
        [Tooltip("Name of the character")]
        public string Name;

        [Tooltip("Health of the character")]
        public int BaseHealth;
        [Tooltip("Mana of the character, used for special attacks")]
        public int BaseMana;

        [Tooltip("Natural armor of the character, damage are substracted by it")]
        public float BaseArmor;
        [Tooltip("Base damage")]
        public float BaseAttack;

        [Tooltip("Class of the character")]
        public CharacterClass Class;
        [Tooltip("Does character target its allie of enemy when attacking? (Healer \"attack\" their allie)")]
        public TargetType Type;
    }
}
