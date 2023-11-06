

namespace DoListy.Pages;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
public class MonthInfo
{
    public int Month { get; set; }
    public int Year { get; set; }
    public MonthInfo()
    {
        Month = 1;
    }
}
public partial class YearPage : ContentPage
{
    public List<MonthInfo> MonthData { get; set; }

    public YearPage()
    {
        InitializeComponent();
        MonthData = new List<MonthInfo>
            {
                new MonthInfo { Year = 2023, Month = 1 },
                new MonthInfo { Year = 2023, Month = 2 },
                                new MonthInfo { Year = 2023, Month = 3 },
                new MonthInfo { Year = 2023, Month = 4 },
                new MonthInfo { Year = 2023, Month = 5 },
                new MonthInfo { Year = 2023, Month = 6 },
                new MonthInfo { Year = 2023, Month = 7 },
                new MonthInfo { Year = 2023, Month = 8 },
                new MonthInfo { Year = 2023, Month = 9 },
                new MonthInfo { Year = 2023, Month = 10 },
                new MonthInfo { Year = 2023, Month = 11},
                new MonthInfo { Year = 2023, Month = 12 },

            };

    }
}