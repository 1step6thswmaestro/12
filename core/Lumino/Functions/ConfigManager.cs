using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lumino.Functions
{
    public class ConfigManager
    {
        public static string VirtualStore = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Lumino";
        public static string WidgetPath = VirtualStore + "\\Widgets";
        public static string ConfigFile = VirtualStore + "\\Config.cfg";
        private GridDock MasterDock;

        public void Initialize(GridDock Target)
        {
            // 객체 갱신
            MasterDock = Target;

            // 구성 디렉토리 생성
            if (!Directory.Exists(VirtualStore))
            {
                Directory.CreateDirectory(VirtualStore);
            }

            // 위젯 디렉토리 생성
            if (!Directory.Exists(WidgetPath))
            {
                Directory.CreateDirectory(WidgetPath);
            }

            // 구성 파일 생성
            if (!File.Exists(ConfigFile))
            {
                File.Create(ConfigFile).Close();
            }
        }

        public void SaveWidgets()
        {
            List<string> Result = new List<string>();
            foreach (GridWidget Widget in MasterDock.WidgetList)
            {
                Result.Add(Widget.Row + "|" + Widget.Column + "|" + Widget.INI);
            }

            File.WriteAllLines(ConfigFile, Result.ToArray());
        }

        public void LoadWidgets()
        {
            try
            {
                string[] Widgets = File.ReadLines(ConfigFile).ToArray();
                foreach (string Conifg in Widgets)
                {
                    string[] ConfigSplit = Conifg.Split('|');
                    GridWidget Widget = new GridWidget
                    {
                        Row = int.Parse(ConfigSplit[0]),
                        Column = int.Parse(ConfigSplit[1])
                    };

                    Widget.Load(ConfigSplit[2]);
                    MasterDock.Add(Widget);
                }
            }
            catch
            {
                Console.WriteLine("Widget Load Error");
            }
        }
    }
}
