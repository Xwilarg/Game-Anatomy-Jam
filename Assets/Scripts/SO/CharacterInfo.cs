using AnatomyJam.Util;
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
        public int BaseArmor;
        [Tooltip("Base damage")]
        public int BaseAttack;

        [Tooltip("Time between 2 attacks in seconds")]
        public Range AttackSpeed;

        [Tooltip("Class of the character")]
        public CharacterClass Class;
        [Tooltip("Does character target its allie of enemy when attacking? (Healer \"attack\" their allie)")]
        public TargetType Type;
    }
}
