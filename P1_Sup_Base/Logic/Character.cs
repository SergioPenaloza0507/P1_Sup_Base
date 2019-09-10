using System;

namespace P1_Sup_Base.Logic
{
    public class Character : IDamager,IDamageable
    {
        int level;
        int baseStrength;
        int baseResistance;
        int hp;
        //strength + (1 * [(level - 1) * 0.25])

        public int Strength { get => (int)Math.Ceiling(baseStrength + (1 * ((Level - 1) * 0.25F))); }
        public int Resistance { get => (int)Math.Ceiling(baseResistance + (1 * ((Level - 1) * 0.25F))); }

        public int Level {
            get
            {
                return level;
            }

            set
            {
                if (level - value < 1)
                {
                    level = 1;
                }
                else
                {
                    level = value;
                }
            }
        }

        public int HP {

            get {return hp < 0 ? 0 : hp; } 

            set 
            {
                hp = value;
            }
        }

        public void LevelUp()
        {
            level++;
        }

        public void ApplyDamage(IDamageable target)
        {
            target.ReceiveDamage(Strength);
        }

        public void ReceiveDamage(int dmg)
        {
            hp -= (dmg - Resistance) >= 1 ? dmg - Resistance : 1;
        }

        public Character(int _baseResistance, int _baseStrength, int _hp)
        {
            level = 1;
            baseResistance = _baseResistance;
            baseStrength = _baseStrength;
            hp = _hp;
        }
    }
}