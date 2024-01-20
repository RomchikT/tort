using CakeShop;
using System;
using Newtonsoft.Json;


public class App
{
    private static List<string> appList = new List<string>()
    {
        "1. Толщина коржей",
        "2. Пропитка",
        "3. Начинка",
        "4. Цвет",
        "5. Сделать заказ",
        "6. Выход",
    };

    public static Dictionary<int, List<string>> SettingsList = new Dictionary<int, List<string>>()
    {
        {1, new List<string>()
        {
            "5mm",
            "10mm",
            "15mm",
            "20mm"
        } },
        {2, new List<string>()
        {
            "Малина",
            "Мед",
            "Клубника",
            "Млоко"
        } },
        {3, new List<string>()
        {
           "Йгурт",
           "Вишня",
           "Клубника"
        } }, 
        {4, new List<string>()
        { 
            "Белый",
            "Шоколадный",
            "Ванильный"
        } }
    };
    public static List<string> SettigsListGood = new List<string>();
    static void Main()
    {
        try
        {
            Console.WriteLine("1.Заказать торт \n2.Выход");
            int a = Convert.ToInt32(Console.ReadLine());
            SelectCake(a);
        }
        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
    }
    public static int IndexSetting = 0;
    public static void SelectCake(int b)
    {
        switch (b)
        {
            case 1:
                Console.Clear();
                Page = 0;
                IndexSetting = 0;
                int i = 1;
                Console.WriteLine("Давай собирем торт");
                foreach (var item in appList)
                {
                    Console.SetCursorPosition(2, i);
                    Console.WriteLine($"{item}");
                    i++;
                }
                Console.WriteLine("Уже в заказе:");
                foreach (var itm in SettigsListGood)
                {
                    Console.WriteLine($"{itm}");
                }
                Menu menu = new Menu(1, appList.Count);
                int pos = menu.Show();
                break;
        }
        
    }

    public static void SaveToJSON()
    {
        string json = JsonConvert.SerializeObject(SettigsListGood);
        string projectPath = Directory.GetCurrentDirectory();
        string fileName = "data.json";
        string filePath = Path.Combine(projectPath, fileName);

        // Записываем JSON в файл
        File.WriteAllText(filePath, json);
        Console.Clear();
        Console.WriteLine("Спасибо за заказ!)");
    }
    public static int Page = 0;
    public static void SelectedPage(int a)
    {
        App.IndexSetting = 0;
        switch (a)
        {
            case 0:
                Console.Clear();
                int i = 1;
                Page = 1;
                Console.WriteLine("Выберите толщину коржей");
                foreach (var item in SettingsList[a+1])
                {
                    Console.SetCursorPosition(2, i);
                    Console.WriteLine($"{item}");
                    i++;
                }
                Menu menu = new Menu(1, appList.Count);
                int pos = menu.Show();
                break;
            case 1:
                Console.Clear();
                i = 1;
                Page = 2;
                Console.WriteLine("Выберите толщину коржей");
                foreach (var item in SettingsList[a + 1])
                {
                    Console.SetCursorPosition(2, i);
                    Console.WriteLine($"{item}");
                    i++;
                }
                menu = new Menu(1, appList.Count);
                pos = menu.Show();
                break;
            case 2:
                Console.Clear();
                i = 1;
                Page = 3;
                Console.WriteLine("Выберите толщину коржей");
                foreach (var item in SettingsList[a + 1])
                {
                    Console.SetCursorPosition(2, i);
                    Console.WriteLine($"{item}");
                    i++;
                }
                menu = new Menu(1, appList.Count);
                pos = menu.Show();
                break;
            case 3:
                Console.Clear();
                i = 1;
                Page = 4;
                Console.WriteLine("Выберите толщину коржей");
                foreach (var item in SettingsList[a + 1])
                {
                    Console.SetCursorPosition(2, i);
                    Console.WriteLine($"{item}");
                    i++;
                }
                menu = new Menu(1, appList.Count);
                pos = menu.Show();
                break;
        }
    }
}
