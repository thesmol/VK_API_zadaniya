using System;
using System.IO;
using System.Text;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.Windows.Forms;
using VkNet.Enums.Filters;

namespace VK_API_zadaniya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
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
            listBox1.Items.Clear();
            
                var api_user = new VkApi();
                api_user.Authorize(new ApiAuthParams
                {
                    AccessToken = textBox1.Text
                });

                var api_group = new VkApi();
                api_group.Authorize(new ApiAuthParams
                {
                    AccessToken = textBox1.Text
                });
            
            try
            {
                if (radioButton1.Checked)
                {
                    var getFriends = api_user.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
                    {
                        Fields = VkNet.Enums.Filters.ProfileFields.All
                    });
                    foreach (User user in getFriends)
                        listBox1.Items.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName + " " + user.LastName)));
                }

            }
            catch
            {
                MessageBox.Show("Некорректный токен");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = getAuthForGroup("token1.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = getAuthForGroup("token2.txt");
        }

        private void button4_Click_1(object sender, EventArgs e)
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
                    wallPost1.Text = Encoding.Default.GetString(Encoding.UTF8.GetBytes(wallPosts.Text));
            }
            catch
            {

            }
        }
    }
}
