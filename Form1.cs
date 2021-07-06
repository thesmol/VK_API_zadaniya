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
        public static string getAuthForGroup(string fileName)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = getAuthForGroup("token1.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = getAuthForGroup("token2.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // получит запись со стены (для пользователя)
            var api_user = new VkApi();
            // обработать исключения!
            try
            {
                api_user.Authorize(new ApiAuthParams
                {
                    AccessToken = textBox1.Text
                });
                var get = api_user.Wall.Get(new WallGetParams());
                foreach (var wallPosts in get.WallPosts)
                    wallPost.Text = Encoding.Default.GetString(Encoding.UTF8.GetBytes(wallPosts.Text));
            }
            catch
            {

            }
        }
    }
}
