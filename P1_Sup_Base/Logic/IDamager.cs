namespace P1_Sup_Base.Logic
{
    public interface IDamager
    {
        int Strength { get; }
        int Resistance { get; }

        void ApplyDamage(IDamageable target);
    }
}