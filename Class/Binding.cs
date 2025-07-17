using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data;

namespace WpfGridView.Class
{
    public class Bind
    {
        public static string ReadValue(string section,string keyPrefix, int index)
        {
            string key = $"{keyPrefix}_{index}";
            
            return File.ReadINI(section, key, "");
        }
        static public void PatternListInsert()
        {
            FileData.Ptncount = Convert.ToInt32(File.ReadINI("PATTERN", "COUNT", ""));
            for (int i = 0; i < FileData.Ptncount; i++)
            {
                Data.PatternData pattern = DataIndex.LoadPatternDataFromINI(i);

                if (!string.IsNullOrWhiteSpace(pattern?.Name))
                {
                    PatternBinding(pattern);
                }           
            }
        }
        public static void PatternBinding(Data.PatternData pattern)
        {
            ObservableCollectionData.PatternDataC.Add(pattern);
        }

        static public void FilterListInsert()
        {
            for (int i = 0; i < FileData.Ptncount; i++)
            {
                string RecipeKey = $"Recipe_{i}";
                int count = Convert.ToInt32(File.ReadINI(RecipeKey, "RECIPE_COUNT", ""));
                for (int j = 0; j < count;  j++)
                {
                    Data.FilterData filter = DataIndex.LoadFilterDataFromINI(RecipeKey,j);
                    
                    FilterBinding(i, filter);
                }
            }
            /*string RecipeKey = $"Recipe_{i}";
            int count = Convert.ToInt32(file.ReadINI(RecipeKey, "RECIPE_COUNT", ""));
            for (int j = 0; j < count; j++)
            {
                Data.FilterData filter = DataIndex.LoadFilterDataFromINI(RecipeKey, j);
                FilterBinding(j,filter);
            }*/
        }
        public static void FilterBinding(int i, Data.FilterData filter)
        {
            Data.PatternData pattern = ObservableCollectionData.PatternDataC[i];
            filter.Name = pattern.Name;
            ObservableCollectionData.FilterDataC.Add(filter);
            
        }
        static public void InfoListInsert()
        {
            Data.InfoData cellinfo = DataIndex.LoadInfoDataFromINI();
            ObservableCollectionData.InfoDataC.Add(cellinfo);
        }

    }
}
