namespace AnatomyJam.Character
{
    public class CharacterBehavior
    {
        private int _maxHealth, _maxMana;
        private int _currentHealth, _currentMana;

        public CharacterBehavior(UIDisplay display, SO.CharacterInfo info)
        {
            _maxHealth = info.BaseHealth;
            _maxMana = info.BaseMana;
            _currentHealth = _maxHealth;
            _currentMana = _maxMana;
            display.Init(info);
        }
    }
}
