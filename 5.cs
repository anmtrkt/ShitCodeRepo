using System.Linq.Expressions;

Dictionary<int, string> levels = new Dictionary<int, string>()
{ [0] = "Начало",
  [1] = "Первый уровень"
};
var actions = new Dictionary<string, Action>
{
    ["game"] = () => { ; },
    ["initLevel"] = () => Console.WriteLine("B")
};
int Health = 20;
int Damage = 3;
bool Blocked = false;
Tuple<int, int, bool> Personaje = new Tuple<int, int, bool>(Health, Damage, Blocked);



bool GameIdet = true;
int currentlevel = 0;

string result;
string returnRegion;
Game();
void Game()
{

    while (GameIdet)
    {
        InitLevel();
    }
}
void InitLevel()
{
    try { int.Parse(If(currentlevel, 0)); Init(); }
    catch
    {
        try { int.Parse(If(currentlevel, 1)); FirstLevel(); }
        catch
        {
            try { int.Parse(If(currentlevel, 2)); SecondLevel(); }
            catch { try { int.Parse(If(currentlevel, 3)); ThirdLevel(); }
                catch{ try { int.Parse(If(currentlevel, 4)); ForthLevel(); }
                    catch {  Final(true); }
                }

        }


    }
}
    }
void Final(bool win) {
    try
    {
        int.Parse(If(win, true));
        var _ = "Ура ты победил!!\n ты нашел выход из пещеры и жил долгую счастливую жизнь!"; GameIdet = false;
        Console.WriteLine(_);
    }
    catch {

        var _ = "Ты умер и теперь твои кости обгладают крысы и ты станешь скелетом этой пещеры"; GameIdet = false;
        Console.WriteLine(_);
    }




}
void ForthLevel()
{

    bool level = true;

    int bokHealth = 30;
    int bokDamage = 3;
    bool Blocked = false;
    Tuple<int, int, bool> Skelet = new(bokHealth, bokDamage, Blocked);
    string _ = $"Ты идешь дальше, и видишь Безумно Огромную Крысу!!. Её здоровье - {bokHealth}, урон - {bokDamage}. Твои здоровье - {Health}, Твой урон - {Damage}. \n Твои действия?\n(1- бить, 2 - блокировать)";
    Console.WriteLine(_);
    string ___ = "Ты убил Безумно Огромная Крысу!!урааа!!";
    while (level)
    {
        Blocked = false;
        string __ = Console.ReadLine();
        try
        {
            int.Parse(If(__, "1"));
            bokHealth -= Damage;
            var _2 = $"Ты ударил врага на {Damage}! У него осталось {bokHealth} хп";
            Console.WriteLine(_2);
            try { int.Parse(If(bokHealth, 0, true)); Console.WriteLine(___); ChooseLvl(); return; }
            catch
            {
                Console.WriteLine("Теперь ходит Безумно Огромная Крыса!");
                EnemyHod(bokDamage, Blocked);
            }
            continue;
        }
        catch
        {
            try
            {
                int.Parse(If(__, "2"));
                Blocked = true;

                try { int.Parse(If(bokHealth, 0)); Console.WriteLine(___); ChooseLvl(); return; }
                catch
                {
                    Console.WriteLine("Теперь ходит Безумно Огромная Крыса!");
                    EnemyHod(bokDamage, Blocked);
                    continue;
                }
            }
            catch { Console.WriteLine("Вводи 1 или 2!!"); continue; }
        }
    }
}
void ChooseLvl() => currentlevel++;
void ThirdLevel()
{

    bool level = true;

    int zkHealth = 20;
    int zkDamage = 4;
    bool Blocked = false;
    Tuple<int, int, bool> Skelet = new(zkHealth, zkDamage, Blocked);
    string _ = $"Ты идешь дальше, и видишь Здоровенную Крысу. Её здоровье - {zkHealth}, урон - {zkDamage}. Твои здоровье - {Health}, Твой урон - {Damage}. \n Твои действия?\n(1- бить, 2 - блокировать)";
    Console.WriteLine(_);
    string ___ = "Ты убил Здоровенную Крысу! +1 к урону и +5 к хп";
    while (level)
    {
        Blocked = false;
        string __ = Console.ReadLine();
        try
        {
            int.Parse(If(__, "1"));
 

                zkHealth -= Damage;
            var _2 = $"Ты ударил врага на {Damage}! У него осталось {zkHealth} хп";
            Console.WriteLine(_2);

            try { int.Parse(If(zkHealth, 0, true)); Console.WriteLine(___); ChooseLvl(); return; }
            catch
            {
                Console.WriteLine("Теперь ходит Здоровенная Крыса!");
                EnemyHod(zkDamage, Blocked);
            }
            continue;
        }
        catch
        {
            try
            {
                int.Parse(If(__, "2"));
                Blocked = true;

                try { int.Parse(If(zkHealth, 0)); Console.WriteLine(___); ChooseLvl(); return; }
                catch
                {
                    Console.WriteLine("Теперь ходит  Здоровенная Крыса!");
                    EnemyHod(zkDamage, Blocked);
                    continue;
                }
            }
            catch { Console.WriteLine("Вводи 1 или 2!!"); continue; }
        }
    }
}

void SecondLevel()
    {

        bool level = true;

        int gbHealt = 12;
        int gbDamage = 1;
        bool Blocked = false;
        Tuple<int, int, bool> Skelet = new(gbHealt, gbDamage, Blocked);
        string _ = $"Ты идешь дальше, и видишь Гоблина. Его здоровье - {gbHealt}, урон - {gbDamage}. Твои здоровье - {Health}, Твой урон - {Damage}. \n Твои действия?\n(1- бить, 2 - блокировать)";
        Console.WriteLine(_);
        string ___ = "Ты убил Гоблина!+1 к урону и +5 к хп";
        while (level)
        {
        Blocked = false;
        string __ = Console.ReadLine();
            try
            {
                int.Parse(If(__, "1"));
            gbHealt -= Damage;
            var _2 = $"Ты ударил врага на {Damage}! У него осталось {gbHealt} хп";

           
            Console.WriteLine(_2);
            try { int.Parse(If(gbHealt, 0, true)); Console.WriteLine(___); ChooseLvl(); return; }
                catch
                {
                    Console.WriteLine("Теперь ходит Гоблин!");
                    EnemyHod(gbDamage, Blocked);
                }
                continue;
            }
            catch
            {
                try
                {
                    int.Parse(If(__, "2"));
                    Blocked = true;

                    try { int.Parse(If(gbHealt, 0)); Console.WriteLine(___); ChooseLvl(); return; }
                    catch
                    {
                        Console.WriteLine("Теперь ходит Гоблин!");
                        EnemyHod(gbDamage, Blocked);
                        continue;
                    }
                }
                catch { Console.WriteLine("Вводи 1 или 2!!"); continue; }
            }
        }
    }
    void FirstLevel()
    {
        bool level = true;

        int skHealt = 8;
        int skDamage = 3;
        bool Blocked = false;
        Tuple<int, int, bool> Skelet = new(skHealt, skDamage, Blocked);
        string _ = $"Ты идешь по пещере, и видишь Скелета. Его здоровье - {skHealt}, урон - {skDamage}. Твои действия?\n(1- бить, 2 - блокировать)";
        Console.WriteLine(_);
        string ___ = "Ты убил Скелета! +1 к урону и +5 к хп\n \n";
        while (level)
        {
            string __ = Console.ReadLine();
            try
            {
                int.Parse(If(__, "1"));
    

            skHealt -= Damage;

            var _2 = $"Ты ударил врага на {Damage}! У него осталось {skHealt} хп";

            Console.WriteLine(_2);

            try { int.Parse(If(skHealt, 0, true)); Console.WriteLine(___); Damage++; Health += 5; ChooseLvl(); return; }
                catch
                {
                    Console.WriteLine("Теперь ходит скелет!");
                    EnemyHod(skDamage, Blocked);
                }
                continue;
            }
            catch
            {
                try
                {
                    int.Parse(If(__, "2"));
                    Blocked = true;

                    try { int.Parse(If(skHealt, 0)); Console.WriteLine(___); ChooseLvl(); return; }
                    catch
                    {
                        Console.WriteLine("Теперь ходит скелет!");
                        EnemyHod(skDamage, Blocked);
                        continue;
                    }
                }
                catch { Console.WriteLine("Вводи 1 или 2!!"); continue; }
            }
        }
    }


    void EnemyHod(int damage, bool blocked)
    {
        string _ = "Враг пытается ударить, но вы блокируете!";
        string __ = "Враг ударяет вас на " + damage;
        Random rg = new Random();
        int res = rg.Next(1, 3);
        try { int.Parse(If(res, 1)); try { int.Parse(If(blocked, true)); Console.WriteLine(_); } catch 
        { Console.WriteLine(__); Health -= damage; try { int.Parse(If(Health, 0, true)); Console.WriteLine("Ты погиб, и теперь станешь скелетом...."); Final(false); }
            catch { } } } catch { Console.WriteLine("Враг защищается!"); }
    }
    void Init()
    {
        string _string = "Привет, это текстовая игра. Тебе предстоит пройти 4 уровня с монстрами. " +
            "Твои характеристики: Здоровье" + Health + " Урон: " + Damage + "\n" +
            "Бить - вводи 1, Защищаться - 2. Сначала действуешь ты, потом монстр. Потом снова ты, а потом монстр. И так далее. \nЧто бы начать введи что угодно";
        Console.WriteLine(_string);
        Console.ReadLine();
        currentlevel++;
        return;

    }
    string If(dynamic whatINeedToCompare, dynamic whatItShouldBe, bool isEqualOrMenshe = false)
    {
        while (isEqualOrMenshe) { while (whatINeedToCompare <= whatItShouldBe) { return "123"; } return "asdd"; }
        while (whatINeedToCompare == whatItShouldBe)
        {
            return "123";
        }
        return "asdd";
    }


    var enemy = new KeyValuePair<string, int>[2];
