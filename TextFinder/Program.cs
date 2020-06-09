using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace TextFinder
{
    class Program
    {   
        [STAThread]
        static void Main(string[] args)
        {                       
            var file = new OpenFileDialog(){
                InitialDirectory = @"C:\",
                Filter = "テキストファイル(*.txt;*.csv;*.tsv)|*.txt;*.csv;*.tsv",
                Multiselect = false,
                Title = "文字列検索を行うファイルを指定してください。",
            };
            if (file.ShowDialog() == DialogResult.OK){
                RegSearch(file.FileName);
            }
        }
        public static void RegSearch(string filepath){
            var count = 0;
            var srKey = Console.ReadLine();
            
            var regexSearch = new Regex(srKey, RegexOptions.IgnoreCase);    //大文字・小文字は区別しない
            //ファイル読み込み、検索            
            try{
                StreamReader file = new StreamReader(filepath);
                var line = "";
                while ((line = file.ReadLine()) != null){
                    if (regexSearch.Match(line).Success){
                        count++;
                        Console.WriteLine(line);
                    }
                    else{
                        //Console.WriteLine("UnMatch!");
                    }
                }
                MessageBox.Show($"{count}件ヒットしました。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.ReadKey();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }                            
        }
    }
}
