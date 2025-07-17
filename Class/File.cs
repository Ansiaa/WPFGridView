using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows;
using System.Runtime.InteropServices;

namespace WpfGridView.Class
{
    class File
    {
        private const int MAX_READ_LENGTH = 255;
        
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public static void FileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ini files (*.ini)|*.ini|All files (*.*)|*.*";  
            openFileDialog.Multiselect = false;                           

            if (openFileDialog.ShowDialog() == true)
            {
                FileData.SelectedFileName = openFileDialog.FileName;                                                          
               // MessageBox.Show("선택된 파일: " + FileData.SelectedFileName);
            }
        }// File Open Dialog

        public static string ReadINI(string section, string key, string _default)
        {
            StringBuilder sb = new StringBuilder(MAX_READ_LENGTH);
            GetPrivateProfileString(section, key, _default, sb, MAX_READ_LENGTH, FileData.SelectedFileName);
            string value = sb.ToString();
            return value;
        }

    }
}