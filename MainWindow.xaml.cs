using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;         // Color 클래스
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfGridView.Class;

namespace WpfGridView
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();

            //this.DataContext = new ObservableCollectionData();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        { 
            PatternDataGrid.ItemsSource = ObservableCollectionData.PatternDataC;
            InfoDataGrid.ItemsSource = ObservableCollectionData.InfoDataC;

            File.FileDialog();            
            Bind.PatternListInsert();
            
            Bind.FilterListInsert();
            Bind.InfoListInsert();
            //string text = FileData.SelectedFileName;
            RecipePath.Text = FileData.SelectedFileName;
        }

        private void UP_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = PatternDataGrid.SelectedItem as Data.PatternData;
            Controller.GridUp(PatternDataGrid, selectedItem, ObservableCollectionData.PatternDataC);
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = PatternDataGrid.SelectedItem as Data.PatternData;
            Controller.GridDown(PatternDataGrid, selectedItem, ObservableCollectionData.PatternDataC);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = PatternDataGrid.SelectedItem as Data.PatternData;
            Controller.GridAdd(selectedItem, ObservableCollectionData.PatternDataC);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = PatternDataGrid.SelectedItem as Data.PatternData;
            Controller.GridDel(selectedItem, ObservableCollectionData.PatternDataC);
        }

        private void PtnClick(object sender, MouseButtonEventArgs e)
        {
            var selectedPattern = (Data.PatternData)((DataGrid)sender).SelectedItem;
            if (selectedPattern == null)
                return;

            string selectedId = selectedPattern.Name;

          
            var matchedDetails = ObservableCollectionData.FilterDataC
                                  .Where(f => f.Name == selectedId)
                                  .ToList();
            //TextBox
            PtnName.Text = selectedId;
            // FilterViewC 갱신
            ObservableCollectionData.FilterViewC.Clear();

            foreach (var detail in matchedDetails)
            {
                ObservableCollectionData.FilterViewC.Add(detail);
            }
            FilterDataGrid.ItemsSource = ObservableCollectionData.FilterViewC;
            
        }
        private void FUP_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = FilterDataGrid.SelectedItem as Data.FilterData;
            Controller.GridUp(FilterDataGrid, selectedItem, ObservableCollectionData.FilterViewC);
        }

        private void FDown_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = FilterDataGrid.SelectedItem as Data.FilterData;
            Controller.GridDown(FilterDataGrid, selectedItem, ObservableCollectionData.FilterViewC);
        }

        private void FAdd_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = FilterDataGrid.SelectedItem as Data.FilterData;
            // 
            Controller.GridAdd(selectedItem, ObservableCollectionData.FilterViewC);
        }

        private void FDel_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = FilterDataGrid.SelectedItem as Data.FilterData;
            Controller.GridDel(selectedItem, ObservableCollectionData.FilterViewC);
        }
    }
}
