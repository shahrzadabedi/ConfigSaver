using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace ConfigSaver
{
    public class RegistrySaver : ISaver
    {
        private string _KeyPath = "Software\\Shahrzad\\ConfigSaver\\";        

        public void Write(string key, string value)
        {
            var reg = Registry.CurrentUser.OpenSubKey(_KeyPath,true);
            if (reg == null)
            {             
               reg =  Registry.CurrentUser.CreateSubKey(_KeyPath, true);
            }
            reg.SetValue(key, value);
        }
        public string Read(string key)
        {
            string res = null;
            var reg = Registry.CurrentUser.OpenSubKey(_KeyPath, true);
            if (reg != null)
            {

                res = (string)reg.GetValue(key);
            }
            return res;
        }

        async Task<string> ISaver.ReadAsync(string key) => await Task.Run(() =>
        {
            string res = null;
            var reg = Registry.CurrentUser.OpenSubKey(_KeyPath, true);
            if (reg != null)
            {

                res = (string)reg.GetValue(key);
            }
            return res;
        });

        async Task ISaver.WriteAsync(string key, string value) => await Task.Run(() =>
        {
            var reg = Registry.CurrentUser.OpenSubKey(_KeyPath, true);
            if (reg == null)
            {
                reg = Registry.CurrentUser.CreateSubKey(_KeyPath, true);
            }
            reg.SetValue(key, value);
        });

        
    }
}