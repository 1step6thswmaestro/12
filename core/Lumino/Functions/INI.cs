using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Lumino.Functions
{
    class INI
    {
        private string Path;

        public INI(string Path)
        {
            this.Path = Path;
        }

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            String section,
            String key,
            String def,
            StringBuilder retVal,
            int size,
            String filePath);

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(
             String section,
             String key,
             String val,
             String filePath);

        public String GetValue(String Section, String Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, Path);
            return temp.ToString();
        }

        public void SetValue(String Section, String Key, String Value)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }
    }
}
