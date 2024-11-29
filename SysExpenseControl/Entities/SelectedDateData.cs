using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysExpenseControl.Entities
{
    public static class SelectedDateData
    {
        public static int Month { get; set; }
        public static int Year { get; set; }

        public static void SetData(string month, string year)
        {
            Year = Convert.ToInt32(year);

            Month = GetMonth(month);

            Debug.WriteLine("Mês: " + Month + " Ano: " + Year);
        }

        private static int GetMonth(string value)
        {
            switch (value.ToLower()) // Tornar a comparação insensível a maiúsculas/minúsculas
            {
                case "janeiro(1)":
                    return 1;
                case "fevereiro(2)":
                    return 2;
                case "março(3)":
                    return 3;
                case "abril(4)":
                    return 4;
                case "maio(5)":
                    return 5;
                case "junho(6)":
                    return 6;
                case "julho(7)":
                    return 7;
                case "agosto(8)":
                    return 8;
                case "setembro(9)":
                    return 9;
                case "outubro(10)":
                    return 10;
                case "novembro(11)":
                    return 11;
                case "dezembro(12)":
                    return 12;
                default:
                    return 0; // Retorna 0 se o valor não for um mês válido
            }
        }
    }
}
