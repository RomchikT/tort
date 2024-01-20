using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop
{
    public class Menu
    {
        public int Min;
        public int Max;

        public Menu(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Show()
        {
            int pos = 1;

            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos != Min)
                {
                    pos--;
                    App.IndexSetting--;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos != Max)
                {
                    pos++;
                    App.IndexSetting++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (App.Page == 0)
                    {
                        if (App.IndexSetting == 4)
                        {
                            App.SaveToJSON();
                        }
                        App.SelectedPage(App.IndexSetting);
                        
                    }
                    else if(App.Page != 0)
                    {
                        App.SettigsListGood.Add(App.SettingsList[App.Page][App.IndexSetting]);
                        App.SelectCake(1);
                    }
                }
            } while(key.Key != ConsoleKey.Escape);

            return pos;
        }
    }
}
