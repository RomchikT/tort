using cake;
using System;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace CakeOrder
{
    public class OrderApp
    {
        public static int Price = 0;
        public static int SelectedMenuIndex = -1;
        public static bool Active = false;
        public static int position = 4;
        public static List<string> MenuTitles = new List<string>()
        {
            "Форма торта",
            "Размер торта",
            "Вкус коржей",
            "Количество коржей",
            "Глазурь торта",
            "Конец заказа"
        };

        public static List<ItemData> ListCastomCake = new List<ItemData>();
       
        public static Dictionary<string, List<ItemData>> CastomMenu = new Dictionary<string, List<ItemData>>()
        {
            {"Форма торта", new List<ItemData>{new ItemData("Куб", 100), new ItemData("Ромб", 200), new ItemData("Круг", 300), new ItemData("Триугольник", 400) } },
            {"Количество коржей", new List<ItemData> { new ItemData("Один ярус", 1000), new ItemData("Два яруса", 2000), new ItemData("Три яруса", 3000), new ItemData("Четыре яруса", 4000) } },
            {"Вкус коржей", new List<ItemData> { new ItemData("Бисквитный", 1500), new ItemData("Медовый", 2999), new ItemData("Песочный", 4000), new ItemData("Шоколадный", 9000) } },
            {"Размер торта", new List<ItemData>{ new ItemData("Маленький", 100), new ItemData("большрой", 200) } },
            {"Глазурь торта", new List<ItemData>{ new ItemData("голубявч", 100), new ItemData("розовая", 50), new ItemData("вкусная", 35500), new ItemData("клубничная", 9000) } },
        };

        static void Main()
        {
            try
            {
                PrintPage("Menu");
                SelectedMenuIndex = -1;
                int pos = 3;
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.DownArrow && pos != 9)
                    {
                        SelectedMenuIndex++;
                        pos++;
                    }
                    else if (key.Key == ConsoleKey.UpArrow && pos != 4)
                    {

                        pos--;
                        SelectedMenuIndex--;
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        try
                        {
                            
                            string path = "C:\\Users\\roma\\Desktop\\Gyglak.txt";

                            string text = JsonConvert.SerializeObject(ListCastomCake);
                            string Date = $"{DateTime.Now.Month}.{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}";
                            if (File.Exists(path))
                            {
                                File.AppendAllText(path, JsonConvert.SerializeObject(Date));
                                File.AppendAllText(path, JsonConvert.SerializeObject(ListCastomCake));
                            }
                            else
                            {
                                File.Create(path);
                                File.AppendAllText(path, JsonConvert.SerializeObject(DateTime.Now.Hour));
                                File.AppendAllText(path, JsonConvert.SerializeObject(DateTime.Now.Minute));
                                File.AppendAllText(path, JsonConvert.SerializeObject(ListCastomCake));
                                Console.ReadLine();
                            }
                        }
                        catch (Exception e) { Console.WriteLine(e.ToString()); return; }
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        PrintPage("CrateCastomizationMenu");
                        return;
                    }

                    PrintPage("Menu");


                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("->");
                }
            }
            catch(Exception e) {Console.WriteLine(e.ToString()); return; }
            
        }

        public static void PrintPage(string title)
        {
            switch(title)
            {
                case "Menu":
                    Console.Clear();
                    var i = 4;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Тортик!");
                    Console.WriteLine("Кастомизация");
                    foreach (var item in MenuTitles) 
                    {
                        Console.SetCursorPosition(3, i++);
                        Console.WriteLine(item);
                        
                    }
                    Console.SetCursorPosition(0, MenuTitles.Count+5);
                    Console.WriteLine($"Цена: {Price}");
                    Console.WriteLine($"Ваш торт:");
                    foreach(var item in ListCastomCake)
                    {
                        Console.WriteLine($" - {item.Name} - {item.Price}");
                    }
                    break;

                case "CrateCastomizationMenu":
                    Console.Clear();
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Для выхода нажмите ESCAPE");
                    Console.WriteLine("Выберите пункт:");
                    i = 4;
                    foreach(var item in CastomMenu[MenuTitles[SelectedMenuIndex]])
                    {
                        Console.SetCursorPosition(3, i++);
                        Console.WriteLine($"{item.Name} - {item.Price}");
                    }
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                    while (true)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.DownArrow)
                        {
                            position++;
                        }
                        else if (key.Key == ConsoleKey.UpArrow && position != 4)
                        {

                            position--;

                        }
                        else if(key.Key == ConsoleKey.Enter)
                        {
                            ListCastomCake.Add(new ItemData(CastomMenu[MenuTitles[SelectedMenuIndex]][position - 4].Name, CastomMenu[MenuTitles[SelectedMenuIndex]][position - 4].Price));
                            Price += CastomMenu[MenuTitles[SelectedMenuIndex]][position - 4].Price;

                            
                            Main();
                            return;
                        }
                        PrintPage("CrateCastomizationMenu");
                        return;
                    }

                    break;
            }
        }
    }
}