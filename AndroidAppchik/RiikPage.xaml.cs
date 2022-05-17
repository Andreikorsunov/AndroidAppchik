using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace AndroidAppchik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RiikPage : ContentPage
    {
        public ObservableCollection<Riiigid> riikid { get; set; }
        Label lbl_list;
        ListView list;
        Button lisa, kustuta;
        public RiikPage()
        {
            riikid = new ObservableCollection<Riiigid>
            {
                new Riiigid {Riik = "Eesti", Pealinn = "Tallinn", Rahvaarv=1331000, Flag="eesti.png"},
                new Riiigid {Riik = "Latvia", Pealinn = "Riga", Rahvaarv=1902000, Flag="latvia.jpg"},
                new Riiigid {Riik = "Leedu", Pealinn = "Vilnius", Rahvaarv=2795000, Flag="leedu.jpg"},
                new Riiigid {Riik = "Tšehhi", Pealinn = "Praha", Rahvaarv=10700000, Flag="chech.jpg"},
                new Riiigid {Riik = "Austria", Pealinn = "Viin", Rahvaarv=8917000, Flag="austria.png"},
                new Riiigid {Riik = "Belgia", Pealinn = "Brüssel", Rahvaarv=11560000, Flag="belgia.jpg"},
                new Riiigid {Riik = "Bulgaaria", Pealinn = "Leev", Rahvaarv=6927000, Flag="bulgaria.jpg"},
                new Riiigid {Riik = "Ungari", Pealinn = "Forint", Rahvaarv=9750000, Flag="vengria.jpg"},
                new Riiigid {Riik = "Saksamaa", Pealinn = "Berliin", Rahvaarv=83240000, Flag="saksamaa.jpg"},
                new Riiigid {Riik = "Kreeka", Pealinn = "Ateena", Rahvaarv=10720000, Flag="grecia.jpg"},
                new Riiigid {Riik = "Taani", Pealinn = "Kopenhaagen", Rahvaarv=5831000, Flag="dania.jpg"}
            };
            lbl_list = new Label
            {
                Text = "Riigi loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Europa Riigid",
                Footer = DateTime.Now.ToString("T"),
                HasUnevenRows = true,
                ItemsSource = riikid,
                ItemTemplate = new DataTemplate(()=>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Riik");
                    Binding companyBinding = new Binding { Path = "Pealinn", StringFormat = "{0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Flag");
                    return imageCell;
                })
            };
            lisa = new Button 
            { 
                Text = "Lisa riik"
            };
            kustuta = new Button 
            { 
                Text = "Kustuta riik"
            };
            list.ItemTapped += List_ItemTapped;
            kustuta.Clicked += Kustuta_Clicked;
            lisa.Clicked += Lisa_Clicked;
            this.Content = new StackLayout { Children = { lbl_list, list, lisa, kustuta } };
        }
        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Riiigid selectedRiik = e.Item as Riiigid;
            if (selectedRiik != null)
                await DisplayAlert("Valitud riik", $"{selectedRiik.Rahvaarv} inimesed - {selectedRiik.Riik}", "OK");
        }
        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Riiigid riik = list.SelectedItem as Riiigid;
            if (riik != null)
            {
                riikid.Remove(riik);
                list.SelectedItem = null;
            }
        }
        public async void Lisa_Clicked(object sender, EventArgs e)
        {
            string riik = await DisplayPromptAsync("Lisage riik", "Nimetus riik: ", initialValue: "", keyboard: Keyboard.Chat);
            string pealinn = await DisplayPromptAsync("Lisage pealinn", $"{riik}" + " pealinna nimi: ", initialValue: "", keyboard: Keyboard.Chat);
            string rahvaarv = await DisplayPromptAsync("Lisage elanikkond", "Kui palju inimesi elab " + $"{riik}" + ": ", initialValue: "1", keyboard: Keyboard.Numeric);
            int rahvaarvi = Convert.ToInt32(rahvaarv);
            string flag = await DisplayPromptAsync("Lisage foto", "Saadaval riigipildi: austria.png belgia.jpg bulgaria.jpg " +
                   "chech.jpg dania.jpg eesti.png grecia.jpg latvia.jpg leedu.jpg saksamaa.jpg vengria.jpg", "ОK", "Cancel");
            riikid.Add(new Riiigid { Riik = riik, Pealinn = pealinn, Rahvaarv = rahvaarvi, Flag = flag });
        }
    }
}