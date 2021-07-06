using System;
using System.IO;
using System.Text;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.Windows.Forms;

namespace VK_API_zadaniya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string getAuthForGroup()
        {
            string fileName = @"token.txt";
            string token = "";
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    token = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return token;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //комментраий
        }
    }
}
