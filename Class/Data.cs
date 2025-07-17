using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfGridView.Class
{
    public class ListData
    {
        public static List<string> TypeList = new List<string>() { "Circle", "Region", "Horizonal", "Vertical", "User", "W_Horizonal", "W_Vertical", "Region2", "Block", "IqCheck","T_Horizonal", "T_Vertical", "User2" };
    }
    public class ObservableCollectionData
    {
        public static ObservableCollection<Data.PatternData> PatternDataC { get; set; }= new ObservableCollection<Data.PatternData>();
        public static ObservableCollection<Data.FilterData> FilterDataC { get; set; } = new ObservableCollection<Data.FilterData>();
        public static ObservableCollection<Data.FilterData> FilterViewC { get; set; } = new ObservableCollection<Data.FilterData>();
        public static ObservableCollection<Data.InfoData> InfoDataC { get; set; } = new ObservableCollection<Data.InfoData>();
    }

    public class Data
    {
        public class PatternData
        {
            public string Name { get; set; }
            public string Omit { get; set; }
            public string PC { get; set; }
            public string PreBlur { get; set; }

            public bool IsUseOmit
            {
                get => Omit == "1";
                set => Omit = value ? "1" : "0";
            }
            public bool IsUsePC
            {
                get => PC == "1";
                set => PC = value ? "1" : "0";
            }
            public bool IsPreBlur
            {
                get => PreBlur == "1";
                set => PreBlur = value ? "1" : "0";
            }

        }
        public class FilterData
        {
            public string sNum1 = "1";
            public string sFloat1 = "0.00";
            public string sFloat2 = "0.0000";
            public string sSubrect = "0, 0, 0, 0";
            public string sSize = "0, 0";
            public string sLog = "LOG";

            public string Name { get; set; }
            public string FilterName { get; set; }
            public string Use { get; set; }
            public bool IsUse
            {
                get => Use == "1";
                set => Use = value ? "1" : "0";
            }
            public string Omit { get; set; }
            public bool IsOmit
            {
                get => Omit == "1";
                set => Omit = value ? "1" : "0";
            }
            public string Special { get; set; }
            public bool IsSpecial
            {
                get => Special == "1";
                set => Special = value ? "1" : "0";
            }
            public string bit12 { get; set; }
            public bool Isbit12
            {
                get => bit12 == "1";
                set => bit12 = value ? "1" : "0";
            }
            public string HR { get; set; }
            public bool IsHR
            {
                get => HR == "1";
                set => HR = value ? "1" : "0";
            }
            public string Blur { get; set; }
            public string CodeName { get; set; }
            public string Type { get; set; }

            public static Dictionary<string, string> TypeDictionary = new Dictionary<string, string>()
            {
                { "0", "Circle" },
                { "1", "Region" },
                { "2", "Horizonal" },
                { "3", "Vertical" },
                { "4", "User" },
                { "5", "W_Horizonal" },
                { "6", "W_Vertical" },
                { "7", "Region2" },
                { "8", "Block" },
                { "9", "IqCheck" },
                { "10", "T_Horizonal" },
                { "11", "T_Vertical" },
                { "12", "User2" }
            };
            public static Dictionary<string, string> GetTypeDictionary()
            {
                return TypeDictionary;
            }
            public string MinSize { get; set; }
            public string MaxSize { get; set; }

            public string Black { get; set; }
            public string White { get; set; }
            public string MaxFactor { get; set; }
            public string Inverse { get; set; }
            public string SubRect { get; set; }
            public string Count { get; set; }
            public string Angle { get; set; }

            public string MaskGroup { get; set; }
            public string MinLevelB { get; set; }
            public string MinLevelW { get; set; }
            public string MinGrade { get; set; }


            public string Pitch { get; set; }
            public string ShiftBg { get; set; }
            public string MAG { get; set; }
            public string OmitRatio { get; set; }
            public string MinSharpness { get; set; }
            public string MaxSharpness { get; set; }
            public string MinVariation { get; set; }
            public string MaxVariation { get; set; }
            public string MinNCC { get; set; }

            public string MaxDefect { get; set; }
            public string Sampling { get; set; }
            public string MaxLevel { get; set; }
            public string LastModify { get; set; }
        }
        public class InfoData
        {
            public string SIZE_X { get; set; }
            public string SIZE_Y { get; set; }
            public string ACTIVE_SIZE_X { get; set; }
            public string ACTIVE_SIZE_Y { get; set; }
            public string MR { get; set; }
            public string PITCH { get; set; }
            public string ROI_THRESHOLD { get; set; }
            public string ROI_OFFSET { get; set; }
            public string COORD { get; set; }
            public string SPECIAL { get; set; }
            public string FILTERNAME { get; set; }
            public string FILTER_X { get; set; }
            public string FILTER_Y { get; set; }
            public string MAP_GRID_X { get; set; }
            public string MAP_GRID_Y { get; set; }
            public string PROFILEMAX { get; set; }
            public string MEDIANUSE { get; set; }
            public string AREAUSE { get; set; }
            public string PREBLUR_SIZE { get; set; }
            public string PREBLUR_Count { get; set; }
        }
    }
    public class DataIndex
    {
        public static Data.PatternData LoadPatternDataFromINI(int index)
        {
            return new Data.PatternData
            {
                Name = Bind.ReadValue("PATTERN", "Name", index),
                Omit = Bind.ReadValue("PATTERN", "Mask", index),
                PC = Bind.ReadValue("PATTERN", "UsePC", index),
                PreBlur = Bind.ReadValue("PATTERN", "PreBlur", index)
            };
        }
        public static Data.FilterData LoadFilterDataFromINI(string section, int index)
        {
            return new Data.FilterData
            {
                FilterName = Bind.ReadValue(section, "FilterName", index),
                Use = Bind.ReadValue(section, "Use", index),
                Omit = Bind.ReadValue(section, "Omit", index),
                Special = Bind.ReadValue(section, "Special", index),
                bit12 = Bind.ReadValue(section, "12bit", index),
                HR = Bind.ReadValue(section, "HR", index),

                Blur = Bind.ReadValue(section, "Blur", index),
                CodeName = Bind.ReadValue(section, "CodeName", index),
                Type = Bind.ReadValue(section, "Type", index),
                MinSize = Bind.ReadValue(section, "MinSize", index),
                MaxSize = Bind.ReadValue(section, "MaxSize", index),

                Black = Bind.ReadValue(section, "Black", index),
                White = Bind.ReadValue(section, "White", index),
                MaxFactor = Bind.ReadValue(section, "MaxLevel", index),
                SubRect = Bind.ReadValue(section, "SubRect", index),
                Count = Bind.ReadValue(section, "Count", index),
                Angle = Bind.ReadValue(section, "Angle", index),

                MaskGroup = Bind.ReadValue(section, "MaskGroup", index),
                MinLevelB = Bind.ReadValue(section, "MinLevelB", index),
                MinLevelW = Bind.ReadValue(section, "MinLevelW", index),
                MinGrade = Bind.ReadValue(section, "MinGrade", index),

                Pitch = Bind.ReadValue(section, "Pitch", index),
                ShiftBg = Bind.ReadValue(section, "ShiftBg", index),
                MAG = Bind.ReadValue(section, "MAG", index),
                OmitRatio = Bind.ReadValue(section, "OmitRatio", index),
                MinSharpness = Bind.ReadValue(section, "MinSharpness", index),
                MaxSharpness = Bind.ReadValue(section, "MaxSharpness", index),

                MinVariation = Bind.ReadValue(section, "MinVariation", index),
                MaxVariation = Bind.ReadValue(section, "MaxVariation", index),
                MinNCC = Bind.ReadValue(section, "MinNCC", index),
                MaxDefect = Bind.ReadValue(section, "MaxDefect", index),

                MaxLevel = Bind.ReadValue(section, "MaxLevelThres", index),
                LastModify = Bind.ReadValue(section, "LastModify", index)
            };
        }
        public static Data.InfoData LoadInfoDataFromINI()
        {
            return new Data.InfoData
            {
                SIZE_X = File.ReadINI("CELL_INFO", "SIZE_X", ""),
                SIZE_Y = File.ReadINI("CELL_INFO", "SIZE_Y", ""),
                ACTIVE_SIZE_X = File.ReadINI("CELL_INFO", "ACTIVE_SIZE_X", ""),
                ACTIVE_SIZE_Y = File.ReadINI("CELL_INFO", "ACTIVE_SIZE_Y", ""),
                MR = File.ReadINI("CELL_INFO", "MR", ""),
                PITCH = File.ReadINI("CELL_INFO", "PITCH", ""),
                ROI_THRESHOLD = File.ReadINI("CELL_INFO", "ROI_THRESHOLD", ""),
                ROI_OFFSET = File.ReadINI("CELL_INFO", "ROI_OFFSET", ""),
                COORD = File.ReadINI("CELL_INFO", "COORD", ""),
                SPECIAL = File.ReadINI("CELL_INFO", "SPECIAL", ""),

                FILTERNAME = File.ReadINI("GRID_INFO", "FILTERNAME", ""),
                FILTER_X = File.ReadINI("GRID_INFO", "FILTER_X", ""),
                FILTER_Y = File.ReadINI("GRID_INFO", "FILTER_Y", ""),
                MAP_GRID_X = File.ReadINI("GRID_INFO", "MAP_GRID_X", ""),
                MAP_GRID_Y = File.ReadINI("GRID_INFO", "MAP_GRID_Y", ""),

                PROFILEMAX = File.ReadINI("PROFILE", "MAX", ""),
                MEDIANUSE = File.ReadINI("MEDIAN", "USE", ""),
                AREAUSE = File.ReadINI("MEDIAN", "AREA_AUTO_ROI", ""),

                PREBLUR_SIZE = File.ReadINI("PREBLUR_INFO", "PREBLUR_SIZE", ""),
                PREBLUR_Count = File.ReadINI("PREBLUR_INFO", "PREBLUR_Count", "")
            };
                
        }
    }
    public static class FileData
    {
        public static string SelectedFileName { get; set; }
        public static int Ptncount { get; set; }
    }
}
