using AndroidAppchik.ViewModels;
using AndroidAppchik.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidAppchik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Table_page : ContentPage
    {
        TableView tabelview;
        SwitchCell sc;
        ImageCell ic;
        TableSection fotosection;
    }
    /*public Table_Page()
    {
        sc = new SwitchCell { Text = "Näita veel " };
        sc.OnChanged += Sc_OnChanged;
        ic = new ImageCell
        {
            ImageSource = ImageSource.FromFile(""),
            Text = "Foto nimetus",
            Detail = "Foto kirjeldus"
        };
        fotosection = new TableSection();
        new TableSection("Kontaktandmed:")
        {
            new EntryCell
            {
                Label="Telefon",
                Placeholder="Sisesta tel. number",
                Keyboard=Keyboard.Telephone
            },
            new EntryCell
            {
                Label="Email",
                Placeholder="Sisesta email",
                Keyboard=Keyboard.Email
            },
            sc
        },
        fotosection
    }
    private void Sc_OnChanged(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            fotosection.Title = "Foto:";
            fotosection.Add(ic);
            sc.Text = "Peida";
        }
        else
        {
            fotosection.Title = "";
            fotosection.Remove(ic);
            sc.Text = "Näita veel";
        }
    }*/
}