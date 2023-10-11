namespace RpgCharacterGenerator
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }

        public Player(int id, string name, int strength, int intelligence)
        {
            Id = id;
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
        }
    }

    public class Fighter : Player
    {
        public int Armor { get; set; }

        public Fighter(int id, string name, int strength, int intelligence, int armor) : base(id, name, strength, intelligence)
        {
            Armor = armor;
        }
    }

    public class Wizard : Player
    {
        public int Mana { get; set; }

        public Wizard(int id, string name, int strength, int intelligence, int mana) : base(id, name, strength, intelligence)
        {
            Mana = mana;
        }
    }
}
