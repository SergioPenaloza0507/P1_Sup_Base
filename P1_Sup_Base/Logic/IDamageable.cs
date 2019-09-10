namespace P1_Sup_Base.Logic
{
    public interface IDamageable
    {
        int HP { get; set; }

        void ReceiveDamage(int dmg);
    }
}