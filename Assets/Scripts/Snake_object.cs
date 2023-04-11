using System.Collections;
using System.Collections.Generic;
using  UnityEngine;

namespace HomeWork_1_4
{
    public class Snake_link
    {
        // public string Name;
        //  public int Year;
        public GameObject Snake_link_prefab;

        public void Message()
        {
           
            //    Console.WriteLine("Имя: " + Name);
            //    Console.WriteLine("Год выпуска: " + Year);
            //    Console.WriteLine("Сложность: " + Difficulty);
        }
    }

    public abstract class Snake_object : Snake_link
    {

        public int Max_Death;

        // Stack<Snake_link> persons = new Stack<Snake_link>();

        public Snake_object(int M)
        {
            Max_Death = M;
            //        Console.WriteLine("Создана змея с количеством жизней: " + Max_Death);
        }

        public virtual void DestroyObject()
        {

        }




    }
}
