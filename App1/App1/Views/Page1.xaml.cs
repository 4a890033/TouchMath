using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();     
        }
        

        void btnClicked(object sender, EventArgs args)
        {
            string ans = Entry.Text;
            string ans2 = "";
            string t1 = "(";
            string t2 = ")";
            string inFix, postFix = string.Empty;
            for (int i = 0 ; i < ans.Length ; i++) //判斷左括弧前面是不是數字 並加上乘號
            {
                int index = ans.IndexOf(t1, i);
                
                if (index != -1)
                { 
                    if (index > 0)
                    {
                        if(Char.IsNumber(ans, index - 1))
                        {
                            ans = ans.Insert(index, "*");
                        }
                    }
                    
                    i = index + 1;
                }
                
            }
            for (int i = 0; i < ans.Length; i++) //判斷右括弧後面是不是數字 並加上乘號
            {
                int index = ans.IndexOf(t2, i);
                if (index != -1)
                {
                    if (index > 0 && index + 1 < ans.Length)
                    {
                        if (Char.IsNumber(ans, index + 1))
                        {
                            ans = ans.Insert(index + 1, "*");
                        }
                    }
                    i = index + 1;
                }

            }
            ans2 = ans.Replace(")(" , ")*("); //判斷左右括弧是否相鄰 並加入乘號

            lable1.Text = ans2; //補完符號的結果
            inToPost test = new inToPost();
            lable1.Text += "\n" + test.GetResult(ans2); // 後序式的結果
            lable1.Text +="\n"+ Class1.CalcByDataTable(ans2).ToString(); // 最後解答


            

        }
        


    }
}