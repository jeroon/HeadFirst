using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadFirstDesignPatternsChapter2
{
	public partial class Form1 : Form
	{
		static public EventHandler handler;
		static public WeatherData StaticWeatherData;
		CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay();

		public Form1()
		{
			if (StaticWeatherData == null)
				StaticWeatherData = new WeatherData();

			InitializeComponent();
			
			
		}

		public void MeasurementsChanged()
		{
			handler?.Invoke(null, null);
			Tuple<float, float, float> tup =  currentConditionsDisplay.ReturnValues();
			Print(tup.Item1 + " " + tup.Item2 + " " +  tup.Item3);
		}

		void Print<T>(T msg)
		{
			richTextBox1.Text += msg.ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MeasurementsChanged();
		}
	}
	public abstract class Display
	{
		public Display()
		{
			Form1.handler += new EventHandler(MeasurementsUpdated);
		}

		public void OnDestroy()
		{
			Form1.handler -= MeasurementsUpdated;
		}

		internal abstract void MeasurementsUpdated(object sender, EventArgs e);
	}
	public class CurrentConditionsDisplay : Display
	{
		float temperature;
		float humidity;
		float pressure;
		

		public CurrentConditionsDisplay() : base()
		{
			
		}

		internal override void MeasurementsUpdated(object sender, EventArgs e)
		{
			temperature = Form1.StaticWeatherData.GetTemperature();
			humidity = Form1.StaticWeatherData.GetHumidity();
			pressure = Form1.StaticWeatherData.GetPressure();
		}

		public Tuple<float, float, float> ReturnValues()
		{
			return new Tuple<float, float, float>(temperature, humidity, pressure);

		}
	}
	public class StatisticsDisplay : Display
	{
		internal override void MeasurementsUpdated(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
	//public class ForecastDisplay : Display
	//{

	//}


	public class WeatherData
	{
		float temperature;
		float humidity;
		float pressure;

		public float GetTemperature()
		{
			return temperature=3;
		}
		public float GetHumidity()
		{
			return humidity=2;
		}
		public float GetPressure()
		{
			return pressure=1;
		}

	}
}
