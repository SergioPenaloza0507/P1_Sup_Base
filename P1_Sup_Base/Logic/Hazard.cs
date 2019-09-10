namespace P1_Sup_Base.Logic
{
    public class Hazard : IDamager
    {
        int baseStrength;

        public Hazard(int _strength)
        {
            baseStrength = _strength;
        }

        public int Strength { get => baseStrength; }
        public int Resistance { get => 0; }

        public void ApplyDamage(IDamageable target)
        {
            target.ReceiveDamage(Strength);
        }
    }
}