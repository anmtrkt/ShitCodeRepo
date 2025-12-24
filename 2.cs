
using Zadacha.Robin.Usloviya;


public static class Program
{
        public static void Main(string[] args)
        {
        int t = int.Parse(Console.ReadLine());
        Zadacha.zadacha.SetUslZAd(t);
        int c = 0;
 zadacha:
          if (c++ < t)
        {
            var param = Console.ReadLine();
                int n = int.Parse(param.Split(" ")[0]);
                int k = int.Parse(param.Split(" ")[1]);

            Zadacha.zadacha.SetYslovia(n, k);
            int[] m = new int[n];
            var param2 = Console.ReadLine();
            string[] stringP = param2.Split(" ");
            for (int i = 0; i < stringP.Length; i++)
            {
                m[i] = int.Parse(stringP[i]);
            }
             Zadacha.zadacha.SetMonesToPersonInRow(m);
                 goto zadacha;
        }
        Zadacha.zadacha.StartZadachy();
    }
}
namespace Zadacha {
    static class zadacha

    {
            public static int counter = 0;
        public static UsloviyaRyada[] usl;
            
        public static void SetUslZAd(int t) => usl = new UsloviyaRyada[t];

        public static void SetYslovia(int k, int n)
        {
            usl[counter++] = new UsloviyaRyada(n, k) {number = --counter};
            counter++;
        }
        public static void SetMonesToPersonInRow(int[] mones)
        {
            int i = 0;
            do
            {
                 usl[counter - 1].Set_Many(i, mones[i++]);
                
            }

            while (i < mones.Length);
        }

        public static void StartZadachy()
        {
            Robin.rObin rob = new Robin.rObin();
                int counter = 0;
            foreach(UsloviyaRyada uslov in usl)
            {
                Array.ForEach(uslov.persons, x => rob.GiveSomeMoneyToPerson(x, uslov.K, counter));
                Console.WriteLine(rob.moneyCounter);
                rob.moneyCounter = 0;
                counter++;
                    rob.koshelek.Kolvo_deneg_kotoroe_est_y_robina = 0;
            }
        }

}
    

    namespace Robin
    {
        public class rObin
        {
            public int moneyCounter = 0;
            int myCount = 0;
            public RobinsKoshelek koshelek = new();
            public bool GiveSomeMoneyToPerson(
                    Person_that_meet_robina.Person_that_Meet_robin_and_ask_him_for_money 
                person, int k, int uslNum)
            {
          
                    if(zadacha.usl[uslNum].CompareK(person.koshel
                    .Kolvo_deneg_kotoroe_est_y_persona_that_meet_robina) is true)
                {
                    return koshelek.RobinTakesAllPersonsManeyAndLeave(person, k);

                }
                
                    return koshelek.RobinTryinToGiveMoneyToSomePerson(person, k, ref moneyCounter);
                
               
            }
        }
        public struct RobinsKoshelek
        {
            public int Kolvo_deneg_kotoroe_est_y_robina;
        
        public bool RobinTryinToGiveMoneyToSomePerson(
        Person_that_meet_robina.Person_that_Meet_robin_and_ask_him_for_money 
        person, int k, ref int money)
            {
            if(person.koshel.Kolvo_deneg_kotoroe_est_y_persona_that_meet_robina == 0){
                        if(Kolvo_deneg_kotoroe_est_y_robina > 0) { 
                    person.koshel.Kolvo_deneg_kotoroe_est_y_persona_that_meet_robina += 1;
                        Kolvo_deneg_kotoroe_est_y_robina -= 1;
   

                        money++;
                        }

                }
                return true;
        }

            public bool RobinTakesAllPersonsManeyAndLeave(Person_that_meet_robina.Person_that_Meet_robin_and_ask_him_for_money
        person, int k)
            {
                if (person.koshel.Kolvo_deneg_kotoroe_est_y_persona_that_meet_robina >= k)
                {
                    Kolvo_deneg_kotoroe_est_y_robina += person.koshel.Kolvo_deneg_kotoroe_est_y_persona_that_meet_robina;
                    person.koshel.Kolvo_deneg_kotoroe_est_y_persona_that_meet_robina = 0;
                }
                return true;
            }
            }
    namespace Usloviya
    {
        public struct UsloviyaRyada
        {
                public int number;
                public
                    Person_that_meet_robina.
                    Person_that_Meet_robin_and_ask_him_for_money[] persons;

                public int N;
                public int K;


            public UsloviyaRyada(int n, int k)
                {
                    N = k; K=n;
                    persons = new Person_that_meet_robina.
                    Person_that_Meet_robin_and_ask_him_for_money[N];
                }

                public void Set_Many(int i, int n)
                {
                    persons[i] = new Person_that_meet_robina.Person_that_Meet_robin_and_ask_him_for_money();
                    persons[i].koshel = new(n);
                }
               
            public bool? CompareK(int k)
            {
                if (this.K <= k) return true;
                if (k == 0) return false;
                return null;
            }

        }
    }
    namespace Person_that_meet_robina {
        public class Person_that_Meet_robin_and_ask_him_for_money
        {
                public Koshelek_Persona_that_Meet_robin_and_ask_him_for_money koshel;
            }
        public struct Koshelek_Persona_that_Meet_robin_and_ask_him_for_money
        {

            public Koshelek_Persona_that_Meet_robin_and_ask_him_for_money(int n)
                {
                    Kolvo_deneg_kotoroe_est_y_persona_that_meet_robina = n;
                }
            public int Kolvo_deneg_kotoroe_est_y_persona_that_meet_robina;
        }
    }
        }
        }