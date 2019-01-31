using System;

namespace classWork
{

    public delegate void NewStringValueDelegate(string s);

    public class UIString
    {
        string str = "Default text";
        public string Str { get { return str; } set { str = value; } }

        public void OnStringValueChanged(string s)
        {
            this.Str = s;
        }

    }
    class ConsoleUI
    {

        public event NewStringValueDelegate StringValueChanged;

        UIString s = new UIString(); // специальная строка
        public UIString S { get { return s; } set { s = value; } }
        public void GetStringFromUI()
        {
            Console.WriteLine("Введите новое значение строки");
            string str = Console.ReadLine();
            StringValueChanged(str);
            RefreshUI();
        }
        public void CreateUI()
        {
            StringValueChanged += s.OnStringValueChanged;
            RefreshUI();
        }
        public void RefreshUI()
        {      // обновление строки     
            Console.Clear();
            Console.WriteLine("Текст строки: " + s.Str);
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            ConsoleUI c = new ConsoleUI();
            c.CreateUI(); // запускаем выполнение объекта класса ConsoleUI
            do
            {
                c.GetStringFromUI();  // изменяем значение строки
                Console.WriteLine("Чтобы закончить эксперименты, нажмите ESC...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}
