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
        Button lisa, kustuta;
        public RiikPage()
        {
            riikid = new List<Riiigid>
            {
                new Riiigid {Riik = "Eesti", Pealinn = "Tallinn", Rahvaarv=1331000, Flag="eesti.png"},
                new Riiigid {Riik = "Latvia", Pealinn = "Riga", Rahvaarv=1902000, Flag="latvia.jpg"},
                new Riiigid {Riik = "Leedu", Pealinn = "Vilnius", Rahvaarv=2795000, Flag="leedu.jpg"}
            };
            lbl_list = new Label
            {
                Text = "Riigi loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = riikid,
                ItemTemplate = new DataTemplate(()=>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    ImageCell.SetBinding(ImageCell.TextProperty, "Riik");
                    Binding companyBinding = new Binding { Path = "Pealinn", StringFormat = "Tore telefon firmalt {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                })
            };
            lisa = new Button 
            { 
                Text = "Lisa felefon"
            };
            kustuta = new Button 
            { 
                Text = "Kustuta telefn" 
            };
            list.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout { Children = { lbl_list, list, lisa, kustuta } };
        }
        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Valitud riik", $"{selectedPhone.Tootja} -{selectedPhone.Nimetus}", "OK");
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