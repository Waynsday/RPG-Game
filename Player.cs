using System;

namespace RPGGame
{
    public class Player
    {
        public string Name;
        public double MaxHP = 100;
        public double HP = 100;
        public int XP = 0;
        public int MaxXP = 10;
        public double MaxMP = 100;
        public double MP = 100;
        public double Strength = 2;
        public int AutoAttack = 5;
        public double Resistance = 2;
        private double HealingRate = 0.01;
        public double Armor = 2;
        public int Level = 1;
        public int PlayerState = 1;
        /*state
        1 = Normal
        2 = poisoned
        3 = Paralyzed
        4 = Dead*/
        public Player(string a){
            Name = a;
        }
        public void LevelUp(){
            Level +=1;
            Armor +=1;
            Resistance +=1;
            Strength+=1;
            HealingRate += 0.01;
            MaxMP = MaxMP *1.05;
            MaxHP = MaxHP * 1.05;
            MaxXP += 10;
        }
        public void UpStrength(int a){
            Strength +=a;
        }
        public void UpResist(int a){
            Resistance +=a;
        }
        public void ArmorShred(float a){
            Armor = Armor * (1 - a);
        }
        public bool PoisonParalysis(double a, double b){
            Random rand = new Random();
            double Probability = (a*rand.NextDouble()) - (Resistance*rand.NextDouble());
            if(Probability > 0.5){
                switch(b){
                    case 2:
                        PlayerState = 2;
                        break;
                    case 3:
                        PlayerState = 3;
                        break;
                }
                return true;
            }
            return false;
        }

        public void PlayerDamage(int a){
            HP -= a;
            if(HP <= 0){
                HP = 0;
                PlayerState = 4;
            }
        }
        public void PlayerHeal(int a){
            HP +=a;
            if(HP > MaxHP){
                HP = MaxHP;
            }
        }
        public bool SkillUse(int a){
            if(MP - a < 0){
                return false;
            } else {
                MP -= a;
            }
            return true;
        }
        public void MPHeal(int a){
            MP += a;
            if(MP > MaxMP){
                MP = MaxMP;
            }
        }

        public double Attack(){
            Random rand = new Random();
            double a = rand.NextDouble();
            if(a > 0.2){
                a = rand.NextDouble();
                if(a < 0.2){
                    return Strength * 2 * AutoAttack;
                }
                return Strength * AutoAttack;
            } else {
                return 0;
            }
        }
    }
}