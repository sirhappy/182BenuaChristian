using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using task3;

namespace task3Desk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int CellsInRow = 6;
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < CellsInRow; ++i)
            {
                var column = new ColumnDefinition();
                column.Width = new GridLength(1.0 / CellsInRow, GridUnitType.Star);
                myGrid.ColumnDefinitions.Add(column);
            }

            var colors = ColorsJsonReader.ReadeColors("../../../task3/colors.json");

            for (int i = 0; i < colors.Count; ++i)
            {
                var row = i / CellsInRow;
                var column = i % CellsInRow;
                if (row >= myGrid.RowDefinitions.Count)
                {
                    var rowDef = new RowDefinition();
                    rowDef.Height = new GridLength(60);
                    myGrid.RowDefinitions.Add(rowDef);
                }

                var canvas = new Canvas();
                canvas.ToolTip = colors[i].ColorName;
                var color = new Color();
                color.R = colors[i].R;
                color.G = colors[i].G;
                color.B = colors[i].B;
                color.A = 255;
                canvas.Background = new SolidColorBrush(color);
                myGrid.Children.Add(canvas);
                Grid.SetRow(canvas, row);
                Grid.SetColumn(canvas, column);
            }

        }
    }
}
