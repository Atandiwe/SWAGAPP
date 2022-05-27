using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwaggApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsListPage : ContentPage
    {


        public ItemsListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            OrderItemsDatabase database = OrderItemsDatabase.Instance;
            listView.ItemsSource = database.GetOrders();
        }

        async void ItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderItemsPage
            {
                BindingContext = new OrderItems()
            });
        }
        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {

                await Navigation.PushAsync(new OrderItemsPage
                {
                    BindingContext = e.SelectedItem as OrderItems
                });
            }
        }



    }
}
