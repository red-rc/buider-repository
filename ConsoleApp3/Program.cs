using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public enum WeaponType
    {
        Spear,
        Sword,
        Axe,
        Bow
    }
    public enum ArmorType
    {
        LightArmor,
        HeavyArmor
    }
    public interface IBuilder
    {
        IBuilder SetHealth(int health);
        IBuilder SetAttack(int attack);
        IBuilder SetDefence(int defence);
        IBuilder SetMorality(int morality);
        IBuilder SetWeaponType(WeaponType weaponType);
        IBuilder SetArmorType(ArmorType armorType);
        IBuilder SetShield(bool shield);
        IBuilder SetHorse(bool horse);
        Unit Build();
    }

    public class UnitBuilder : IBuilder
    {
        private Unit unit;

        public IBuilder SetHealth(int health)
        {
            unit.health = health;
            return this;
        }
        public IBuilder SetAttack(int attack)
        {
            unit.attack = attack;
            return this;
        }
        public IBuilder SetDefence(int defence)
        {
            unit.defence = defence;
            return this;
        }
        public IBuilder SetMorality(int morality)
        {
            unit.morality = morality;
            return this;
        }
        public IBuilder SetWeaponType(WeaponType weaponType)
        {
            unit.weaponType = weaponType;
            return this;
        }
        public IBuilder SetArmorType(ArmorType armorType)
        {
            unit.armorType = armorType;
            return this;
        }
        public IBuilder SetShield(bool shield)
        {
            unit.shield = shield;
            return this;
        }
        public IBuilder SetHorse(bool horse)
        {
            unit.horse = horse;
            return this;
        }
        public Unit Build()
        {
            return this.unit;
        }
    }

    public class Unit
    {
        public int health = 0;
        public int attack = 10;
        public int defence = 10;
        public int morality = 100;
        public WeaponType weaponType;
        public ArmorType armorType;
        public bool shield = false;
        public bool horse = false;

        public Unit SetHealth(int health)
        {
            this.health = health;
            return this;
        }
        public Unit SetAttack(int attack)
        {
            this.attack = attack;
            return this;
        }
        public Unit SetDefence(int defence)
        {
            this.defence = defence;
            return this;
        }
        public Unit SetMorality(int morality)
        {
            this.morality = morality;
            return this;
        }

        public void ShowParameters()
        {
            Console.WriteLine($"health: {health}");
            Console.WriteLine($"attack: {attack}");
            Console.WriteLine($"defence: {defence}");
            Console.WriteLine($"morality: {morality}");
            Console.WriteLine($"weaponType: {weaponType}");
            Console.WriteLine($"armorType: {armorType}");
            Console.WriteLine($"shield: {shield}");
            Console.WriteLine($"horse: {horse}");
        }
    }
    public abstract class AbstractFactory : Unit
    {
        public abstract Unit CreateUnit();
    }
    public class InfantryFactory : AbstractFactory
    {
        public override Unit CreateUnit()
        {
            return new UnitBuilder()
                .SetHealth(150)
                .SetAttack(50)
                .SetDefence(50)
                .SetMorality(100)
                .SetWeaponType(WeaponType.Sword)
                .SetArmorType(ArmorType.HeavyArmor)
                .SetShield(true)
                .SetHorse(false)
                .Build();
        }
    }

    public class CavalryFactory : AbstractFactory
    {
        public override Unit CreateUnit()
        {
            return new UnitBuilder()
                .SetHealth(200)
                .SetAttack(70)
                .SetDefence(40)
                .SetMorality(100)
                .SetWeaponType(WeaponType.Spear)
                .SetArmorType(ArmorType.LightArmor)
                .SetShield(false)
                .SetHorse(true)
                .Build();
        }
    }

    public class RiflemanFactory : AbstractFactory
    {
        public override Unit CreateUnit()
        {
            return new UnitBuilder()
                .SetHealth(100)
                .SetAttack(60)
                .SetDefence(30)
                .SetMorality(100)
                .SetWeaponType(WeaponType.Bow)
                .SetArmorType(ArmorType.LightArmor)
                .SetShield(false)
                .SetHorse(false)
                .Build();
        }
    }

    internal class Program
    {
        public static Unit CreateUnit(AbstractFactory factory)
        {
            return factory.CreateUnit();
        }
        static void Main(string[] args)
        {
            Unit infantry = CreateUnit(new InfantryFactory());
            infantry.ShowParameters();

            Unit cavalry = CreateUnit(new CavalryFactory());
            cavalry.ShowParameters();

            Unit rifleman = CreateUnit(new RiflemanFactory());
            rifleman.ShowParameters();
        }
    }
}
