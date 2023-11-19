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
		public void register(object sender,EventArgs e)
		{
			string username = userbox.Text.ToString();
			string password = passbox.Password.ToString();

			string connectionString = "Data Source=DESKTOP-IBERPBJ;Initial Catalog=TEST;Integrated Security=True";

			string move = "INSERT INTO LoginTable (USERNAME,USERPASSWORD) VALUES (@USERN,@PASS)";

			using(SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();

				using (SqlCommand addStudent = new SqlCommand(move, conn))
				{
					addStudent.Parameters.AddWithValue("@USERN", username);
					addStudent.Parameters.AddWithValue("@PASS", password);

					addStudent.ExecuteNonQuery();
				}

				conn.Close();
				
			}
			userbox.Clear();
			passbox.Clear();
		}



		

		public MainWindow()
		{
			InitializeComponent();
		}


		
	}
	
}
