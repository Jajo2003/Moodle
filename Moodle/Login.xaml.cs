using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Moodle
{

	public partial class Login : Window
	{
		private string connectionString = "Data Source=DESKTOP-IBERPBJ;Initial Catalog=TEST;Integrated Security=True";

		public Login()
		{
			InitializeComponent();
		}
		


		public void LoginMoodle(object sender,EventArgs a)
		{
			string username = userbox.Text.ToString();
			string password = passbox.Password.ToString();
			List<string> errors = new List<string>();
			errors.Add("Fill username");
			errors.Add("Fill password");
			string move = "SELECT COUNT(*) FROM StudentsData WHERE Username = @user AND Password = @pass";

			if (checkboxes())
			{

				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					using (SqlCommand checklog = new SqlCommand(move, conn))
					{
						checklog.Parameters.AddWithValue("@user", username);
						checklog.Parameters.AddWithValue("@pass", password);

						int exists = (int)checklog.ExecuteScalar();
						if (exists > 0)
						{
							MainMoodle moodle = new MainMoodle();
							moodle.Show();
							this.Close();
						}
						else
						{
							MessageBox.Show("No");
						}

					}



				}
			}
			else
			{
				if(username == "" && password == "")
				{
					MessageBox.Show($"{errors[0]}" + "\n" + $"{errors[1]}");
					
				}
				else if(username == "")
				{
					MessageBox.Show(errors[0]);
					
				}
				else
				{
					MessageBox.Show(errors[1]);
				}
			}


		}
		private bool checkboxes()
		{
			string username = userbox.Text.ToString();
			string password = passbox.Password.ToString();
		

			if (username == "" || password == "")
				return false;

			return true;

		}
	}
}
