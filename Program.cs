using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Созданеи героя класса Эльф - стрелок");
            Hero Elf = new Hero(new ElfFactory());
            Elf.Hit();
            Elf.Run();
            Elf.WarWhoop();
            
            Console.WriteLine("\nСозданеи героя класса Орк - воин");
            Hero Orc = new Hero(new OrcFactory());
            Orc.Hit();
            Orc.Run();
            Orc.WarWhoop();

            Console.ReadLine();
        }
    }


    //абстрактный класс - оружие
    abstract class Weapon
    {
        public abstract void Hit();
    }
    // абстрактный класс - движение
    abstract class Movement
    {
        public abstract void Move();
    }


    // абстрактный класс - боевой клич
    abstract class WarWhoop
    {
        public abstract void Scream();

    }


    // боевой клич орков
    class OrcScream : WarWhoop
    {
        public override void Scream()
        {
            Console.WriteLine("Издать боевой клич орков");
        }
    }

    // боевой клич эльфов
    class WarElfHorn : WarWhoop
    {
        public override void Scream()
        {
            Console.WriteLine("Использовать боевой горн эльфов");
        }

    }

    // класс лук
    class Bow : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из лука");
        }
    }
    
    // класс секира
    class BattleAx : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьем боевой секирой");
        }
    }





    // движение - полет
    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }
    // движение - бег
    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }


    // класс абстрактной фабрики
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
        public abstract WarWhoop CreateWarWhoop();
    }


    // Фабрика создания элфа - стрелка из лука, который передвигается полетами и может воспользоваться боевым горном
    class ElfFactory : HeroFactory
    {
        public override WarWhoop CreateWarWhoop()
        {
            return new WarElfHorn();
        }
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Bow();
        }
    }

    // Фабрика создания орка с боевой секирой, который может бегать и издавать боевой клич
    class OrcFactory : HeroFactory
    {
        public override WarWhoop CreateWarWhoop()
        {
            return new OrcScream();
        }
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new BattleAx();
        }
    }
    


    class Hero
    {
        private readonly Weapon Weapons;
        private readonly Movement Movements;
        private readonly WarWhoop WarWhoops;
        public Hero(HeroFactory factory)
        {
            Weapons = factory.CreateWeapon();
            Movements = factory.CreateMovement();
            WarWhoops = factory.CreateWarWhoop();

        }
        public void Run()
        {
            Movements.Move();
        }
        public void Hit()
        {
           Weapons.Hit();
        }
        public void WarWhoop()
        {
            WarWhoops.Scream();
        }
    }
}
