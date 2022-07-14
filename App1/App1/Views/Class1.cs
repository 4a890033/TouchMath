using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace App1.Views
{
    internal class Class1
    {
        internal static float CalcByDataTable(string expression)
        {
            try
            {
                object result = new DataTable().Compute(expression, "");
                return float.Parse(result + "");
            }
            catch (Exception ex)
            {

                return float.Parse("0000000");
                
            }
           
        }
    }
}
