using OxyPlot.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BenchTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrendingEnergy : ContentPage
    {
        ViewModels.TrendingEnergyViewModel viewModel;
        public TrendingEnergy()
        {

            InitializeComponent();
            viewModel = new ViewModels.TrendingEnergyViewModel(App.Session);
            this.BindingContext = viewModel;

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.Children.Add(new Label
            {
                HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center,
                Text = "DC Voltage, Current and Power of EpuA"

            });
            grid.Children.Add(new PlotView
            {
                WidthRequest = 300,
                HeightRequest = 500,
                BackgroundColor = Color.WhiteSmoke,
                Model = viewModel.energyTredningChart
            });
            Content = new StackLayout
            {
                Children = { grid }
            };
//            Content = new StackLayout
//            {
//                Children = {
//                        new Label {
//                            HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center,
//                            Text = "DC Voltage, Current and Power of EpuA"

//                        },
//                      new PlotView
//                         {
//                                WidthRequest = 300,
//                                HeightRequest = 500,
//                                BackgroundColor = Color.WhiteSmoke,
//                                Model = viewModel.energyTredningChart
//}
//                        }
//            };

        }




    }
}
