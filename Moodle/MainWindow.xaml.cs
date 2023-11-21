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


		public void openLoginWindow(object sender,EventArgs a)
		{
			Login loginWindow = new Login();
			loginWindow.Show();
			this.Close();

		}

		public void openRegisterWindow(object sender,EventArgs a)
		{
			Register registerWindow = new Register();
			registerWindow.Show();
			this.Close();
		}

	}	

	
	
	}
