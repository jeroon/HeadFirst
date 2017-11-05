using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_3
{
	public partial class Form1 : Form
	{
		public static RichTextBox richTextBox;

		public Form1()
		{
			InitializeComponent();
			if (richTextBox == null) richTextBox = richTextBox1;
			
		}
	}

	class Utils
	{
		public static void Print<T>(T msg)
		{
			Form1.richTextBox.Text += msg.ToString() + Environment.NewLine;
		}
	}
}
