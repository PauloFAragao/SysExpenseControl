﻿using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SysExpenseControl.Forms
{
    public partial class FrmHome : Form
    {
        DateTime _date;

        public FrmHome()
        {
            InitializeComponent();

            // Inicializando os Graficos
            InitializeChartSpent();
            InitializeChartComparison();

            TEMPORARIO();

            _date = DateTime.Now;
            //_date = new DateTime(2024,11,7);
            // exibir o mês selecionado
            SetInterfaceDate();

            // Carregando as categorias
            Task.Run(() => InitializeCategories("Sem categoria"));

            // Carregando os dados do DataGridView gastos por categoria
            Task.Run(() => InitializeSpendingByCategory("Sem categoria"));
            
            // Carregando os dados do DataGridView Resumo dos gastos
            Task.Run(() => InitializeSpent());

            // Carregando os dados do DataGridView reservas
            Task.Run(() => InitializeReserves());

        }

        private void SetInterfaceDate()
        {
            this.LblMonth.Text = _date.ToString("MM/yyyy");
        }

        private void InitializeChartSpent()
        {
            // Título principal
            Title titulo = new Title();
            titulo.Font = new Font("Elephant", 12, FontStyle.Bold);
            titulo.ForeColor = Color.DarkBlue;
            titulo.Text = "Gastos do mês de " + DateTime.Now.ToString("MMMM");
            this.ChartSpent.Titles.Add(titulo);

            // inserir legenda
            this.ChartSpent.Legends.Add("Legenda");
            this.ChartSpent.Legends[0].Title = "Gastos";

            this.ChartSpent.Series.Add("Gastos");
            this.ChartSpent.Series[0].ChartType =
                   System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            // Mostrar os valores sobre as fatias de pizza
            this.ChartSpent.Series[0].IsValueShownAsLabel = true;

            // gráfico em 3d
            this.ChartSpent.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.ChartSpent.ChartAreas[0].Area3DStyle.Inclination = 30;
            this.ChartSpent.ChartAreas[0].Area3DStyle.Rotation = -5;

            // paleta de cores
            //this.ChartSpent.Palette = ChartColorPalette.Excel;
            this.ChartSpent.Palette = ChartColorPalette.SemiTransparent;
        }

        // dados temporarios
        private void TEMPORARIO()
        {
            //chart = new Chart();
            //ChartComparison.Dock = DockStyle.Fill;
            //this.Controls.Add(ChartComparison);

            // Criar área do gráfico
            //ChartArea chartArea = new ChartArea();
            //ChartComparison.ChartAreas.Add(chartArea);

            // Criar legenda
            Legend legend = new Legend("Legend1");
            ChartComparison.Legends.Add(legend);

            // Criar série
            Series series = new Series
            {
                Name = "Valores Mensais",
                IsValueShownAsLabel = false, // Não mostrar rótulos nas barras
                ChartType = SeriesChartType.Column // Tipo de gráfico de barras
            };

            // Adicionar dados
            series.Points.AddXY("Janeiro", 500.45);
            series.Points.AddXY("Fevereiro", 450.95);
            series.Points.AddXY("Março", 685.25);

            // Alterar cores das barras
            series.Points[0].Color = Color.Red;    // Janeiro
            series.Points[1].Color = Color.Green;  // Fevereiro
            series.Points[2].Color = Color.Blue;   // Março

            // Adicionar série ao gráfico
            ChartComparison.Series.Add(series);

            // Adicionar a legenda para cada ponto
            series.Points[0].LegendText = "Janeiro";
            series.Points[1].LegendText = "Fevereiro";
            series.Points[2].LegendText = "Março";
        }

        private void InitializeChartComparison()
        {
            // Título principal
            Title titulo = new Title();
            titulo.Font = new Font("Elephant", 10, FontStyle.Bold);
            titulo.ForeColor = Color.DarkBlue;
            titulo.Text = "Gastos dos últimos meses";
            this.ChartComparison.Titles.Add(titulo);

            // inserir legenda
            //this.ChartComparison.Legends.Add("Legenda");
            //this.ChartComparison.Legends[0].Title = "Gastos";

            this.ChartComparison.Series.Add("Gastos");
           //this.ChartComparison.Series[0].ChartType =
                   //System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            // Mostrar os valores sobre as fatias de pizza
            this.ChartComparison.Series[0].IsValueShownAsLabel = true;

            // gráfico em 3d
            //this.ChartComparison.ChartAreas[0].Area3DStyle.Enable3D = true;
            //this.ChartComparison.ChartAreas[0].Area3DStyle.Inclination = 30;
            //this.ChartComparison.ChartAreas[0].Area3DStyle.Rotation = -5;

            // paleta de cores
            this.ChartComparison.Palette = ChartColorPalette.Excel;
            //this.ChartComparison.Palette = ChartColorPalette.SemiTransparent;
        }

        private void SelectedIndexChanged()
        {
            string category = this.CbxCategories.Text;

            // Carregando os dados do DataGridView gastos por categoria
            Task.Run(() => InitializeSpendingByCategory(category));
        }

        private void ChangeDate()
        {
            FrmSelectDate frmSelectDate = new FrmSelectDate(CallBackChangeDate);
            frmSelectDate.ShowDialog();
        }


        // ------------------------- Eventos
        private void CallBackChangeDate()
        {
            DateTime newDate = new DateTime(SelectedDateData.Year, SelectedDateData.Month, 1);

            _date = newDate;

            // exibir o mês selecionado
            SetInterfaceDate();

            // ---- Recarregar todos os dados

            // Carregando os dados do DataGridView gastos por categoria
            Task.Run(() => InitializeSpendingByCategory("Sem categoria"));

            // Carregando os dados do DataGridView Resumo dos gastos
            Task.Run(() => InitializeSpent());
        }

        // ------------------------- Thread
        // ------------ Categorias
        private void InitializeCategories(string category)
        {
            List<string> data = DataConsultant.GetCategorys();

            // Carregando os dados no comboBox
            ThreadHelper.SetComboBoxData(CbxCategories, data);

            if (category != "")
                ThreadHelper.SetPropertyValue(CbxCategories, "Text", category);

            else
                ThreadHelper.SetPropertyValue(CbxCategories, "SelectedIndex", 0);
        }

        // ------------ Gastos por categoria
        private void InitializeSpendingByCategory(string category)
        {
            if(LoadDataSpendingByCategory(category))
            {
                ChangeColumnsSpendingByCategory();
            }
        }

        private bool LoadDataSpendingByCategory(string category)
        {
            DataTable dataTable = DataConsultant.GetMonthlyExpensesByCategory(category, 
                _date.Year, _date.Month);

            if (dataTable != null)
            {
                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(DgvData, "DataSource", dataTable);

                return true;
            }
            else
                return false;
        }

        private void ChangeColumnsSpendingByCategory()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvData, 0, "Nome");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 0, DataGridViewAutoSizeColumnMode.Fill);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 1, "Valor R$");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 1, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 2, "Data");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 2, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 3, "Descrição");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 3, DataGridViewAutoSizeColumnMode.DisplayedCells);
        }

        // ------------ Resumo dos gastos
        private void InitializeSpent()
        {
            if (LoadDataSpent())
            {
                //ChangeColumnsSpent();
                //HideColumnsSpent();
            }
        }

        private bool LoadDataSpent()
        {
            DataTable dataTable = DataConsultant.ViewMonthExpenses(_date.Year, _date.Month);

            if (dataTable != null)
            {
                // retirando as contas que ainda não foram pagas
                foreach (DataRow row in dataTable.Rows)
                {
                    var paymentDate = row[3];
                    if (!DateTime.TryParse(paymentDate.ToString(), out DateTime result))
                        row.Delete();// marcando para deletar
                }
                dataTable.AcceptChanges();// confirmando a deleção

                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(DgvSpent, "DataSource", dataTable);

                FillChartSpent(dataTable);

                return true;
            }
            else
                return false;
        }

        private void FillChartSpent(DataTable dataTable)
        {
            List<string> categories = new List<string>();
            List<decimal> values = new List<decimal>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string category = dataTable.Rows[i][4].ToString();
                decimal value = Convert.ToDecimal(dataTable.Rows[i][2]);

                if (!categories.Contains(category))
                {
                    categories.Add(category);
                    values.Add(value);
                }
                else
                {
                    values[categories.IndexOf(category)] += value;
                }
            }

            /*for(int i = 0; i < categories.Count; i++)
            {
                Debug.WriteLine("Categoria: " + categories[i] + " Valor: " + values[i]);
            }*/

            if (categories != null)
            {
                ThreadHelper.SetChartData(this.ChartSpent, categories, values);
            }
        }

        private void ChangeColumnsSpent()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvSpent, 1, "Nome");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvSpent, 1, DataGridViewAutoSizeColumnMode.Fill);

            ThreadHelper.SetColumnHeaderText(this.DgvSpent, 2, "Valor R$");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvSpent, 2, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvSpent, 3, "Data");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvSpent, 3, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvSpent, 4, "Categoria");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvSpent, 4, DataGridViewAutoSizeColumnMode.DisplayedCells);
        }

        private void HideColumnsSpent()
        {
            ThreadHelper.SetColumnVisibility(this.DgvSpent, 0, false);//mudando a visibilidade da coluna id
            ThreadHelper.SetColumnVisibility(this.DgvSpent, 5, false);//mudando a visibilidade da coluna descrição
        }

        // ------------ Reservas
        private void InitializeReserves()
        {
            if (LoadDataReserves())
            {
                HideColumnsReserves();
                ChangeColumnsReserves();

                ThreadHelper.SetDefaultCellStyle(DgvReserves, "reservationAmount");// para a coluna dos valores ter ,00

            }
        }

        private bool LoadDataReserves()
        {
            DataTable dataTable = DataConsultant.ViewReserves();

            if (dataTable != null)
            {
                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(this.DgvReserves, "DataSource", dataTable);
                return true;
            }
            else
                return false;
        }

        private void HideColumnsReserves()
        {
            ThreadHelper.SetColumnVisibility(this.DgvReserves, 0, false);//coluna id
            ThreadHelper.SetColumnVisibility(this.DgvReserves, 2, false);//coluna tableName
        }

        private void ChangeColumnsReserves()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvReserves, 1, "Nome");

            ThreadHelper.SetColumnHeaderText(this.DgvReserves, 3, "Valor na reserva");

            ThreadHelper.SetColumnHeaderText(this.DgvReserves, 4, "Quantidade de operações");

            ThreadHelper.SetColumnHeaderText(this.DgvReserves, 5, "Descrição");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvReserves, 5, DataGridViewAutoSizeColumnMode.DisplayedCells);
        }

        // ------------------------- Métodos criados pelo visual studio
        private void CbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged();
        }

        private void BtnChangeMonth_Click(object sender, EventArgs e)
        {
            ChangeDate();
        }
    }
}
