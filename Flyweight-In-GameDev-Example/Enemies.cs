class EnemyType
{
    public string Name { get; }
    public int Health { get; }
    public int Speed { get; }
    public int Damage { get; }

    public EnemyType(string name, int health, int speed, int damage)
    {
        Name = name;
        Health = health;
        Speed = speed;
        Damage = damage;
    }

    public void ShowСharacteristics()
    {
        Console.WriteLine($"Type: {Name}, Health: {Health}, Speed: {Speed}, Damage: {Damage}");
    }
}

class EnemyFactory
{
    private Dictionary<string, EnemyType> _types = new();

    public EnemyType GetEnemyType(string name, int health, int speed, int damage)
    {
        if (_types.ContainsKey(name))
            return _types[name];

        var type = new EnemyType(name, health, speed, damage);
        _types[name] = type;
        return type;
    }
}

class Enemy
{
    private EnemyType _type;
    private int _x, _y;
    private int _currentHealth;

    public Enemy(EnemyType type, int x, int y)
    {
        _type = type;
        _x = x;
        _y = y;
        _currentHealth = type.Health;
    }

    public void Show()
    {
        _type.ShowСharacteristics();
        Console.WriteLine($"Enemy position: ({_x}, {_y})");
        Console.WriteLine($"Current health: {_currentHealth}");
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0) _currentHealth = 0;
    }
}

//Usage
class Program
{
    static void Main()
    {
        EnemyFactory enemyFactory = new();

        EnemyType goblinType = enemyFactory.GetEnemyType("Goblin", 50, 15, 12);
        EnemyType orcType = enemyFactory.GetEnemyType("Orc", 300, 8, 60);
        EnemyType ogreType = enemyFactory.GetEnemyType("Ogre", 1200, 4, 300);

        Enemy goblin1 = new(goblinType, 5, 3);
        Enemy goblin2 = new(goblinType, 4, 2);
        Enemy orc1 = new(orcType, 12, 7);
        Enemy orc2 = new(orcType, 3, 17);
        Enemy ogre1 = new(ogreType, 12, 15);

        goblin1.Show();
        goblin2.Show();
        orc1.Show();
        orc2.Show();
        ogre1.Show();

        orc1.TakeDamage(88);
        orc1.Show();
    }
}
