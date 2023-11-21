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
using System.Windows.Shapes;

namespace Moodle
{
	
	
	public partial class Register : Window
	{
		private string connectionString = "Data Source=DESKTOP-IBERPBJ;Initial Catalog=TEST;Integrated Security=True";

		public Register()
		{
			InitializeComponent();
		}
		


		public void addAccount(object sender, EventArgs e)
		{
			string username = userbox.Text.ToString();
			string password = passbox.Password.ToString();
			string Email = MailBox.Text.ToString();

			if (checkboxes())
			{


				string move = "INSERT INTO StudentsData (Username,Password,Email) VALUES (@name,@pass,@mail)";

				using (SqlConnection conn = new SqlConnection(connectionString))
				{

					conn.Open();

					using (SqlCommand addStudent = new SqlCommand(move, conn))
					{

						//checking if email exists in DB
						if (!checkmailExist(Email))
						{
							//if email contains required symbols new account will be added in DB
							if (validEmail(Email))
							{
								addStudent.Parameters.AddWithValue("@name", username);
								addStudent.Parameters.AddWithValue("@pass", password);
								addStudent.Parameters.AddWithValue("@mail", Email);
								int rowsAffected = addStudent.ExecuteNonQuery();

								if (rowsAffected > 0)
								{
									MessageBox.Show("Your account Created Succesfully");
									userbox.Clear();
									passbox.Clear();
									MailBox.Clear();
									MainMoodle mainMoodle = new MainMoodle();
									mainMoodle.Show();
									this.Close();

								}
							}
							else
							{
								MessageBox.Show("Email must Contain '@' symbol");
							}

						}
						else
						{
							MessageBox.Show("This Email is Already Used! try another one");
						}

					}
					conn.Close();
				}
			}
			else
			{
				MessageBox.Show("Fill all fields");
			}

		}

		private bool checkboxes()
		{
			string username = userbox.Text.ToString();
			string password = passbox.Password.ToString();
			string Email = MailBox.Text.ToString();

			if (username == "" || password == "" || Email == "")
				return false;

			return true;

		}
		private bool checkmailExist(string mail)
		{


			string move = "SELECT COUNT(*) FROM StudentsData WHERE Email = @mail";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{

				conn.Open();

				using (SqlCommand checkexist = new SqlCommand(move, conn))
				{
					checkexist.Parameters.AddWithValue("@mail", mail);

					int result = (int)checkexist.ExecuteScalar();

					return result > 0;

				}

			}

		}


		public bool validEmail(string a)
		{
			return ((a.Contains("@gmail.com")) || (a.Contains("@mail.ru")));
		}

	}








}

