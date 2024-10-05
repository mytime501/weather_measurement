using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WeatherApp.ViewModel
{
    internal class TempColorTextBlock: TextBlock
    {
        public double Temp
        {
            get { return (double)GetValue(MyProperty); }
            set { SetValue(MyProperty, value); }
        }

        public static readonly DependencyProperty MyProperty = DependencyProperty.Register(
            "Temp",
            typeof(double),
            typeof(TempColorTextBlock),
            new PropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged)));

        private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TempColorTextBlock tb = d as TempColorTextBlock;
            if(tb.Temp >  293.15)
            {
                tb.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                tb.Foreground = new SolidColorBrush(Colors.Blue);
            }
        }
    }
}
