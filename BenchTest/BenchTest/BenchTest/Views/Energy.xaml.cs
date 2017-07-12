using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BenchTest.ViewModels;
namespace BenchTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Energy : ContentPage
	{
		public Energy ()
		{
			InitializeComponent ();
            BindingContext = new EnergyViewModel(App.Session);

        }
	}
}
