using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidAppchik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RiikPage : ContentPage
    {
        public List<Riiigid> riikid { get; set; }
        Label lbl_list;
        ListView list;
        public RiikPage()
        {
            riikid = new List<Riiigid>
            {
                new Riiigid {Riik = "Eesti", Pealinn = "Tallinn", Rahvaarv=1331000, Flag="eesti.jpg"},
                new Riiigid {Riik = "Latvia", Pealinn = "Riga", Rahvaarv=1902000, Flag="latvia.jpg"},
                new Riiigid {Riik = "Leedu", Pealinn = "Vilnius", Rahvaarv=2795000, Flag="leedu.jpg"}
            };
            lbl_list = new Label
            {
                Text = "Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView
            {
                ItemsSource = Riig
                /*GroupHeaderTemplate = new DataTemplate(() =>
                {
                    Label tootja = new Label();
                    tootja.SetBinding(Label.TextProperty, "Nimetus");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { tootja }
                        }
                    };
                }),
                ItemTemplate = new DataTemplate(() =>
                {
                    Label nimetus = new Label { FontSize = 20 };
                    nimetus.SetBinding(Label.TextProperty, "Nimetus");
                    Label hind = new Label();
                    hind.SetBinding(Label.TextProperty, "Hind");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { nimetus, hind }
                        }
                    };
                })*/
            };
            list.ItemSelected += List_ItemSelected;
            /*list.ItemTapped += List_ItemTapped;*/
            this.Content = new StackLayout { Children = { lbl_list, list } };
        }
        /*private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Valitud mudel", $"{selectedPhone.Tootja} -{selectedPhone.Nimetus}", "OK");
        }*/
        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                lbl_list.Text = e.SelectedItem.ToString();
        }
        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Telefon phone = list.SelectedItem as Telefon;
            if (phone != null)
            {
                telefonid.Remove(phone);
                list.SelectedItem = null;
            }
        }
        private void Lisa_Clicked(object sender, EventArgs e)
        {
            telefonid.Add(new Telefon { Nimetus = "Telefon", Tootja = "Tootja", Hind = 1 });
        }
    }
}