using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidAppchik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TripsTrapsTrulls : ContentPage
    {
        Grid grid2X1, grid3X3;
        Button uus_mang, reeglid;
        Image img;
        public bool esimene;
        int tulemus = -2;
        int[,] Tulemused = new int[3, 3];
        public TripsTrapsTrulls()
        {
            grid2X1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Blue,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
            };
            Uus_mang();
            uus_mang = new Button()
            {
                Text = "Uus mäng"
            };
            reeglid = new Button()
            {
                Text = "Reeglid"
            };
            grid2X1.Children.Add(uus_mang, 0, 1);
            reeglid.Clicked += Reeglid_Clicked;
            uus_mang.Clicked += Uus_mang_Clicked;
            Content = grid2X1;
        }
        private void Reeglid_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Reeglid", "Üks mängija mängib ristiga, teine nulliga. " +
                "Mäng vormistatakse järgmiselt: Ristiga mängija alustab ja joonistab risti keskele. " +
                "Nulliga mängija joonistab nulli ükskõik millisesse ülejäänud ruutu. " +
                "Mängu eesmärgiks on saada ritta (kas diagonaalis, ülevalt alla või vasakult paremale) kolm ühesugust kujundit ja takistada teisel seda saamast. " +
                "Mängu võitja ongi see, kes kolm oma kujundit ritta saab.", "ОK");
        }
        public async void Kes_on_esimene()
        {
            string esimene_valik = await DisplayPromptAsync("Kes on esimene?", "Tee valiku Null-1 või Rist-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (esimene_valik == "1")
            {
                esimene = true;
            }
            else
            {
                esimene = false;
            }
        }
        private void Uus_mang_Clicked(object sender, EventArgs e)
        {
            Uus_mang();
        }
        public async void Uus_mang()
        {
            bool uus = await DisplayAlert("Uus mäng", "Kas tõesti tahad uus mäng?", "Tahan küll!", "Ei taha!");
            if (uus)
            {
                Kes_on_esimene();
                Tulemused = new int[3, 3];
                tulemus = -2;
                grid3X3 = new Grid
                {
                    BackgroundColor = Color.Red,
                    RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                    }
                };
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        img = new Image();
                        img.Source = ImageSource.FromFile("fon.jpg");
                        grid3X3.Children.Add(img, j, i);
                        TapGestureRecognizer tap = new TapGestureRecognizer();
                        tap.Tapped += Tap_Tapped;
                        img.GestureRecognizers.Add(tap);
                    }
                }
                grid2X1.Children.Add(grid3X3, 0, 0);
            }
        }
        public int Kontroll()
        {
            //esimene mängija
            if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[1, 2] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }
            //teine mängija
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 0] == 2 && Tulemused[2, 0] == 2 || Tulemused[0, 1] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 1] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 2] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[0, 1] == 2 && Tulemused[0, 2] == 2 || Tulemused[1, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[1, 2] == 2 || Tulemused[2, 0] == 2 && Tulemused[2, 1] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 2] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 0] == 2)
            {
                tulemus = 2;
            }
            else
            {
                tulemus = -1;
            }
            if (checkTie())
            {
                DisplayAlert("Viik", "Viik", "OK");
            }
            return tulemus;
        }
        private bool checkTie()
        {
            for (int i = 0; i < Tulemused.GetLength(0); i++)
            {
                for (int j = 0; j < Tulemused.GetLength(1); j++)
                {
                    if (Tulemused[i, j] == 2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void Lopp()
        {
            tulemus = Kontroll();
            if (tulemus == 1)
            {
                DisplayAlert("Võit", "Esimine võitis!", "Ok");
                Uus_mang();
            }
            else if (tulemus == 2)
            {
                DisplayAlert("Võit", "Teine võitis!", "Ok");
                Uus_mang();
            }
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var img = (Image)sender;
            var r = Grid.GetRow(img);
            var c = Grid.GetColumn(img);
            if (esimene == true)
            {
                img.Source = ImageSource.FromFile("nolik.jpg");
                img.GestureRecognizers.Clear();
                esimene = false;
                Tulemused[r, c] = 1;
            }
            else
            {
                img.Source = ImageSource.FromFile("krestik.jpg");
                img.GestureRecognizers.Clear();
                esimene = true;
                Tulemused[r, c] = 2;
            }
            grid3X3.Children.Add(img, c, r);
            Lopp();
        }
    }
}