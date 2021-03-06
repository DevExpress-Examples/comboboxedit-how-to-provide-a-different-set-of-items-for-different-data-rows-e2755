﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DynamicComboBoxItemsSource {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            List<TestData> list = new List<TestData>();
            for(int i = 0; i < 10; i++)
                list.Add(new TestData() { Text = "Row" + i, Number = i });
            grid.ItemsSource = list;
        }

        private void PART_Editor_PopupOpening(object sender, RoutedEventArgs e) {

        }
    }

    public class TestData {
        public string Text { get; set; }
        public int Number { get; set; }
    }

    public class TextToItemsSourceConverter : IValueConverter {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            List<TestData> list = new List<TestData>{
                new TestData() { Text = "Text0", Number = 0 },
                new TestData() { Text = "Text1", Number = 1 },
                new TestData() { Text = "Text2", Number = 2 },
                new TestData() { Text = "Text3", Number = 3 },
                new TestData() { Text = "Text4", Number = 4 },
                new TestData() { Text = "Text5", Number = 5 },
                new TestData() { Text = "Text6", Number = 6 },
                new TestData() { Text = "Text7", Number = 7 },
                new TestData() { Text = "Text8", Number = 8 },
                new TestData() { Text = "Text9", Number = 9 },
                new TestData() { Text = "Text10", Number = 10 },
            };
            string text = value as string;
            if(string.IsNullOrEmpty(text))
                return list;
            if(text == "Row0") list.RemoveRange(1, 2);
            if(text == "Row3") list.RemoveRange(4, 3);
            return list;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
        #endregion
    }
}
