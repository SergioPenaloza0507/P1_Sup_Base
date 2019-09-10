namespace P1_Sup_Base.Logic
{
    public static class TestExtensions
    {
        public static Character Copy(this Character character)
        {
            return new Character(character.HP, character.Strength, character.Resistance);
        }

        public static Hazard Copy(this Hazard hazard)
        {
            return new Hazard(hazard.Strength);
        }

        public static Destructible Copy(this Destructible destructible)
        {
            return new Destructible(destructible.HP);
        }
    }
}