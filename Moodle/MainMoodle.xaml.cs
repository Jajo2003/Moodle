﻿using System;
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

namespace Moodle
{
	public partial class MainMoodle : Window
	{
		public MainMoodle()
		{
			InitializeComponent();
		}
		public void logOut(object sender, EventArgs e)
		{
			MainWindow Mainwindow = new MainWindow();
			Mainwindow.Show();
			this.Close();
		}
	}
}
