using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadFirstDesignPatternsChapter1
{
	public partial class Form1 : Form
	{
		static RichTextBox textBox;

		public Form1()
		{
			InitializeComponent();
			if (textBox == null)
				textBox = richTextBox1;

			Duck duck = new ModelDuck();
			duck.PerformFly();
			duck.SetFlyBehaviour(new RocketPowered());
			duck.PerformFly();
			duck.PerformQuack();
			duck.Display();
		}

		public static void Print<T>(T msg)
		{
			textBox.Text += msg.ToString() + Environment.NewLine;
		}
	}

	public abstract class Duck
	{
		protected QuackBehaviour quackBehaviour;
		protected IFlyBehaviour flyBehaviour;

		public void PerformFly()
		{
			flyBehaviour.Fly();
		}

		public void PerformQuack()
		{
			quackBehaviour.Quack();
		}
		public virtual void Display() {
			Form1.Print("Hmm.. no duckie");
		}

		public void SetFlyBehaviour(IFlyBehaviour fb)
		{
			flyBehaviour = fb;
		}
		public void SetQuackBehaviour(QuackBehaviour qb)
		{
			quackBehaviour = qb;
		}
	}

	public class MallardDuck: Duck
	{
		public MallardDuck()
		{
			quackBehaviour = new QuackQuack();
			flyBehaviour = new FlyWithWings();
		}

		public override void Display()
		{
			Form1.Print("I'm a Mallard Duck");
		}
	}

	public class RubberDuck : Duck
	{
		public RubberDuck()
		{
			quackBehaviour = new Mute();
			flyBehaviour = new GroundBound();
		}

		public override void Display()
		{
			Form1.Print("I am a rubber duckie");
		}
	}

	public class ModelDuck : Duck
	{
		public ModelDuck()
		{
			flyBehaviour = new GroundBound();
			quackBehaviour = new QuackQuack();
		}
		public override void Display()
		{
			Form1.Print("I'm a model duck");
		}
	}
}
