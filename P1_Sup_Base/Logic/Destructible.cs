namespace P1_Sup_Base.Logic
{
    public class Destructible : IDamageable
    {
        int hp;

        public Destructible(int _hp)
        {
            HP = _hp;
        }

        public int HP
        {
            get { return hp < 0 ? 0 : hp; }
            set
            {
                hp = value;
            }
        }

        public void ReceiveDamage(int dmg)
        {
            HP -= dmg;
        }
    }
}