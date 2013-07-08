using Newtonsoft.Json;
using Smartboard.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartboard.UI.Views
{
    public partial class LoginView : Form
    {
        public User User;
        
        public LoginView(User user)
        {
            InitializeComponent();
            this.User = user;
        }

        private void CloseView(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginClick(object sender, EventArgs e)
        {
            string email = this.txtEmail.Text;
            string password = this.txtPassword.Text;

            string url =
                String.Format("http://api.linden.pro/user-login?email={0}&password={1}", email, password);
            
            WebRequest request =
                WebRequest.Create(url);
            try
            {
                Stream stream = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string json = reader.ReadToEnd();

                this.User = JsonConvert.DeserializeObject<User>(json);

                if (this.User.Status)
                {

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Giriş yapılamadı.");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
            
        }
    }
}
