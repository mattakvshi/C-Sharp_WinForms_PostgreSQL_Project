using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace WinFormProducts
{
    public partial class GraphForm : Form
    {   
        //Дата и сумма по дате
        List<Tuple<DateTime, decimal>> graphData = new List<Tuple<DateTime, decimal>>();

        public GraphForm(List<Tuple<DateTime, decimal>> graphData)
        {
            /*
             Функция-конструктор, которая формирует график
             */

            InitializeComponent();
            this.graphData = graphData;
            InitializeGraph();
        }

        private void InitializeGraph()
        {
            // Очистка предыдущих серий данных
            graph.Series.Clear();

            // Группировка данных по дате
            var groupedData = graphData.GroupBy(data => data.Item1);

            // Создание серии для каждой уникальной даты
            foreach (var group in groupedData)
            {
                var seriesName = group.Key.ToShortDateString();
                Series series = new Series(seriesName)
                {
                    ChartType = SeriesChartType.Column
                };

                // Добавление точки данных для текущей даты
                series.Points.AddXY(group.Key, group.Sum(g => g.Item2));
                series.Points[0].AxisLabel = seriesName;
                series.Points[0].Label = group.Sum(g => g.Item2).ToString();

                // Настройка внешнего вида серии
                series.CustomProperties = "PixelPointWidth=100";
                graph.Series.Add(series);
            }

            // Настройка осей графика
            graph.ChartAreas[0].AxisX.Interval = 1;
            graph.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            graph.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yyyy";
            graph.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

            // Настройка легенды
            graph.Legends[0].Enabled = true;
        }
    }
}
