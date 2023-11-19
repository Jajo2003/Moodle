using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Moodle
{
	
	public partial class MainWindow : Window
	{
		



		public MainWindow()
		{
			InitializeComponent();
		}

		public void checkData(object sender,EventArgs e)
		{
			string username = userbox.Text.ToString();
			string password = passbox.Password.ToString();
			if (checkboxes()) {
			
			string connectionString = "Data Source=DESKTOP-IBERPBJ;Initial Catalog=TEST;Integrated Security=True";

			string move = "INSERT INTO LoginTable (USERNAME,USERPASSWORD) VALUES (@name,@pass)";

			using(SqlConnection conn = new SqlConnection(connectionString)) {

				conn.Open();

				using (SqlCommand addStudent = new SqlCommand(move, conn))
				{
					addStudent.Parameters.AddWithValue("@name", username);
					addStudent.Parameters.AddWithValue("@pass", password);

						if (!checkexist(username))
						{

							int rowsAffected = addStudent.ExecuteNonQuery();

							if (rowsAffected > 0)
							{
								MessageBox.Show("Student added Succesfully");
							}
							
						}
						else
						{
							MessageBox.Show("This Username already taken! choose different Username");
						}
					}
				conn.Close();
			}
			}
			else
			{
				MessageBox.Show("Fill all fields");
			}
			userbox.Clear();
			passbox.Clear();
		}
		
		private bool checkboxes()
		{
			string username = userbox.Text.ToString();
			string password = passbox.Password.ToString();

			if(username == "" || password == "")
			{
				userbox.Clear();
				passbox.Clear();
				return false;
			}
			return true;
			
		}
		private bool checkexist(string user)
		{
			string connectionString = "Data Source=DESKTOP-IBERPBJ;Initial Catalog=TEST;Integrated Security=True";

			string move = "SELECT COUNT(*) FROM LoginTable WHERE USERNAME = @User";

			using(SqlConnection conn = new SqlConnection(connectionString)) {

				conn.Open();
			
				using(SqlCommand checkexist = new SqlCommand(move,conn))
				{
					checkexist.Parameters.AddWithValue("@User", user);
					
					int result = (int)checkexist.ExecuteScalar();

					conn.Close();

					return result > 0;
				}
				
			}

		}

	}
	
}
