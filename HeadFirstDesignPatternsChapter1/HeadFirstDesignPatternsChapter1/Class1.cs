using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPatternsChapter1
{
	public abstract class QuackBehaviour
	{
		public abstract void Quack();
	}

	public class QuackQuack : QuackBehaviour
	{
		public override void Quack()
		{
			Form1.Print("I am quacking");
		}
	}

	public class Squeak : QuackBehaviour
	{
		public override void Quack()
		{
			Form1.Print("I am squeaking");
		}
	}

	public class Mute : QuackBehaviour
	{
		public override void Quack()
		{
			Form1.Print("I am silent");
		}
	}

	public interface IFlyBehaviour
	{
		void Fly();
	}

	public class FlyWithWings : IFlyBehaviour
	{
		public void Fly()
		{
			Form1.Print("I am flying with wings!");
		}
	}

	public class GroundBound : IFlyBehaviour
	{
		public void Fly()
		{
			Form1.Print("I am on the ground");
		}
	}

	public class RocketPowered : IFlyBehaviour
	{
		public void Fly()
		{
			Form1.Print("Wheeeeeeeeee");
		}
	}
}
