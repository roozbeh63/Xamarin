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
	public partial class AlarmPage : ContentPage
	{
        AlarmViewModel viewModel;
		public AlarmPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel =new AlarmViewModel(App.Session);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Models.Alarm;
            if (item == null)
                return;
           // viewModel.ShowNotification.Execute("notification roozbeh");
            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }
    }
}
