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
    public partial class OrderItemsPage : ContentPage
    {
        public OrderItemsPage()
        {
            InitializeComponent();
        }

         async void Saved_Clicked(object sender, EventArgs e)
        {
            var orderitems = (OrderItems)BindingContext;
            OrderItemsDatabase database =  OrderItemsDatabase.Instance;
            database.SaveItem(orderitems);
            await Navigation.PopAsync();
        }

        async void Deleted_Clicked(object sender, EventArgs e)
        {
            var orderitems = (OrderItems)BindingContext;
            OrderItemsDatabase database = OrderItemsDatabase.Instance;
            database.DeleteItem(orderitems);
            await Navigation.PopAsync();
        }
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}