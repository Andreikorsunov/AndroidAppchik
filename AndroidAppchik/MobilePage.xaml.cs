﻿using System;
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
    public partial class MobilePage : ContentPage
    {
        //public List<Telefon> telefons { get; set; }
        //public ObservableCollection<Telefon> telefons { get; set; }
        public ObservableCollection<Ruhm<string, Telefon>> telefonideruhmades { get; set; }
        Label lbl_list;
        ListView list;
        public MobilePage()
        {
            var telefonid = new List<Telefon>
            {
                new Telefon {Nimetus="Samsung Galaxy S22", Tootja ="Samsung", Hind=1249, Pilt ="s22.png" },
                new Telefon {Nimetus="Sony XA1", Tootja ="Sony", Hind=250, Pilt ="xa1.png" },
                new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G", Tootja ="Xiaomi", Hind=339, Pilt ="lite11.png" },
                new Telefon {Nimetus="iPhone 13", Tootja ="Apple", Hind=1179, Pilt ="iphone.png" }
            };
            var ruhmad = telefonid.GroupBy(p => p.Tootja).Select(g => new Ruhm<string, Telefon>(g.Key, g));
            telefonideruhmades = new ObservableCollection<Ruhm<string, Telefon>>(ruhmad);
            lbl_list = new Label
            {
                Text = "Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Telefonid rühmades:",
                Footer = DateTime.Now.ToString("T"),
                HasUnevenRows = true,
                ItemsSource = telefonideruhmades,
                IsGroupingEnabled = true,
                //ItemsSource = telefons,
                GroupHeaderTemplate = new DataTemplate(() =>
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
                })
            };
            list.ItemTapped += List_ItemTapped;
            //this.Content = new StackLayout { Children = { lbl_list, list, lisa, kustuta } };
        }
        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Valitud mudel", $"{selectedPhone.Tootja} -{selectedPhone.Nimetus}", "OK");
        }
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
                //telefonid.Remove(phone);
                list.SelectedItem = null;
            }
        }
        private void Lisa_Clicked(object sender, EventArgs e)
        {
            //telefonid.Add(new Telefon { Nimetus = "Telefon", Tootja = "Tootja", Hind = 1 });
        }
    }
}