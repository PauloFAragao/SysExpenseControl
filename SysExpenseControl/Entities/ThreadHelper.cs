﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SysExpenseControl.Entities
{
    public static class ThreadHelper
    {
        public static void SetPropertyValue(Control control, string property, object value)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => SetPropertyValue(control, property, value)));
            }
            else
            {
                try
                {
                    PropertyInfo prop = control.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);

                    if (prop != null && prop.CanWrite)
                    {
                        prop.SetValue(control, value);
                    }
                }
                catch (TargetInvocationException ex)
                {
                    Console.WriteLine(ex.InnerException?.Message);
                }
            }
        }

        //-------------------------- métodos para manipular DataGridView
        public static void SetColumnVisibility(DataGridView dataGridView, int columnIndex, bool visible)
        {
            try
            {
                if (!dataGridView.IsDisposed)
                {
                    if (dataGridView.InvokeRequired)
                    {
                        // Chama o método usando o delegate
                        dataGridView.Invoke(new Action(() => SetColumnVisibility(dataGridView, columnIndex, visible)));
                    }
                    else
                    {
                        // Define a visibilidade da coluna
                        dataGridView.Columns[columnIndex].Visible = visible;
                    }
                }
            }
            catch (ObjectDisposedException ex)
            {
                Debug.WriteLine($"O controle foi descartado: {ex.Message}");
            }
        }

        public static void SetColumnHeaderText(DataGridView dataGridView, int columnIndex, string headerText)
        {
            try
            {
                if (!dataGridView.IsDisposed)
                {
                    if (dataGridView.InvokeRequired)
                    {
                        // Chama o método usando o delegate
                        dataGridView.Invoke(new Action(() => SetColumnHeaderText(dataGridView, columnIndex, headerText)));
                    }
                    else
                    {
                        // Define o texto do cabeçalho da coluna
                        dataGridView.Columns[columnIndex].HeaderText = headerText;
                    }
                }
            }
            catch (ObjectDisposedException ex)
            {
                Debug.WriteLine($"O controle foi descartado: {ex.Message}");
            }
        }

        public static void SetColumnAutoSizeMode(DataGridView dataGridView, int columnIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            try
            {
                if (!dataGridView.IsDisposed)
                {
                    if (dataGridView.InvokeRequired)
                    {
                        // Chama o método usando o delegate
                        dataGridView.Invoke(new Action(() => SetColumnAutoSizeMode(dataGridView, columnIndex, autoSizeMode)));
                    }
                    else
                    {
                        // Define o modo de redimensionamento automático da coluna
                        dataGridView.Columns[columnIndex].AutoSizeMode = autoSizeMode;
                    }
                }
            }
            catch (ObjectDisposedException ex)
            {
                Debug.WriteLine($"O controle foi descartado: {ex.Message}");
            }
        }

        public static void SelectFirstRow(DataGridView dataGridView)
        {
            try
            {
                if (!dataGridView.IsDisposed)
                {
                    if (dataGridView.InvokeRequired)
                    {
                        // Chama o método no thread da interface do usuário
                        dataGridView.BeginInvoke(new Action(() => SelectFirstRow(dataGridView)));
                    }
                    else
                    {
                        // Verifica se há pelo menos uma linha
                        if (dataGridView.Rows.Count > 0)
                            dataGridView.Rows[0].Selected = true; // Seleciona a linha 0
                    }
                }
            }
            catch (ObjectDisposedException ex)
            {
                Debug.WriteLine($"O controle foi descartado: {ex.Message}");
            }
        }

        //-------------------------- métodos para manipular Chart
        public static void SetChartData(Chart chart, List<string> strings, List<decimal> decimals)
        {
            try
            {
                if (!chart.IsDisposed)
                {
                    if (chart.InvokeRequired)
                    {
                        // Chama o método usando o delegate
                        chart.Invoke(new Action(() => SetChartData(chart, strings, decimals)));
                    }
                    else
                    {
                        // Define a visibilidade da coluna
                        chart.Series[0].Points.DataBindXY(strings, decimals);
                    }
                }
            }
            catch (ObjectDisposedException ex)
            {
                Debug.WriteLine($"O controle foi descartado: {ex.Message}");
            }
        }
    
    }
}