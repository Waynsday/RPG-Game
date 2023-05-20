using System;

namespace RPGGame
{
    public class Monster
    {
        public string Name;
        public int MonsterX{get; set;}
        public int MonsterY{get; set;}
        public double HP = 100;
        public double MaxHP = 100;
        public double Strength = 2;
        public int AutoAttack = 6;
        public double Armor = 2;
        public char MonsterImage = '@';
        public int DamageType = 1;
        /* damage type
        1 = normal
        2 poison
        3 electric */
        public Monster(string a, int x, int y){
            Name = a;
            MonsterX = x;
            MonsterY = y;
        }
        
        public double Attack(){
            Random r = new Random();
            if(r.NextDouble() > 0.3){
                if(r.NextDouble() < 0.1){
                    return Strength * AutoAttack * 1.5;
                } else {
                    return Strength * AutoAttack;
                }
            } else {
                return 0;
            }
        }
        public void MonsterDamage(int a){
            HP -= a;
            if(HP <= 0){
                HP = 0;
            }
        }
    }
}