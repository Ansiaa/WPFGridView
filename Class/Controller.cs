using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using System.Collections.ObjectModel;

namespace WpfGridView.Class
{
    class Controller
    {
        public static void GridUp<T>(DataGrid dataGrid, T selectedItem, ObservableCollection<T> datac)
        {
            if (selectedItem == null || !datac.Contains(selectedItem))
                return;

            int index = datac.IndexOf(selectedItem);
            if (index > 0)
            {
                datac.Move(index, index - 1);
                dataGrid.SelectedItem = selectedItem; 
            }
        }
        public static void GridDown<T>(DataGrid dataGrid, T selectedItem, ObservableCollection<T> datac)
        {
            if (selectedItem == null || !datac.Contains(selectedItem))
                return;

            int index = datac.IndexOf(selectedItem);
            if (index < datac.Count - 1)
            {
                datac.Move(index, index + 1);
                dataGrid.SelectedItem = selectedItem;
            }
        }
        public static void GridAdd<T>(T selectedItem, ObservableCollection<T> datac) where T : new()
        {
            int index = datac.IndexOf(selectedItem);

            if (index < 0)
            {
                datac.Add(new T());
            }
            else
            {
                datac.Insert(index + 1, new T());
            }
            /*if (selectedItem == null || !datac.Contains(selectedItem))
            {
                return;
            }

            datac.Add(selectedItem);*/
        }
        public static void GridDel<T>(T selectedItem, ObservableCollection<T> datac)
        {
            if (selectedItem == null || !datac.Contains(selectedItem))
            {
                return;
            }

            int index = datac.IndexOf(selectedItem);
            datac.Remove(selectedItem);
        }
    }
}
