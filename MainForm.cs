using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WordAnalysisTask
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ODFPath.ShowDialog();
            txtPath.Text = ODFPath.FileName;            
        }
       
        private void btnRead_Click(object sender, EventArgs e)
        {   
            if (!string.IsNullOrWhiteSpace(txtPath.Text))
            {
                List<string> ArrWords = new List<string>();
                List<string> Palidromes = new List<string>();               
                using (StreamReader file = new StreamReader(txtPath.Text))
                {
                    int counter = 0;
                    string ln;
                    while ((ln = file.ReadLine()) != null)
                    {
                        ArrWords.Add(ln);
                        if (isStringPalindrome(ln))
                        {
                            Palidromes.Add(ln);
                        }
                        counter++;
                    }
                    file.Close();                    
                }               
                lblLongestWord.Text = ArrWords.OrderByDescending(s => s.Length).First();
                lblShortestWord.Text = ArrWords.OrderByDescending(s => s.Length).Last();
                lblAverage.Text = ArrWords.Average(n => n.Length).ToString();
                lblLongestPalindrome.Text = Palidromes.OrderByDescending(s => s.Length).First();
                lblShortestPalindrome.Text = Palidromes.OrderByDescending(s => s.Length).Last();
                lblTotalPalindromes.Text = Palidromes.Count().ToString();
            }
            else
            {
                MessageBox.Show("Please Select a file");
            }            
        }        
        public bool isStringPalindrome(String input)
        {
            var reversed = new string(Enumerable.Range(1, input.Length).Select(i => input[input.Length - i]).ToArray());
            return String.Compare(input, reversed, true) == 0;
        }

    }
}
