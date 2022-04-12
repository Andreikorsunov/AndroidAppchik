using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidAppchik
{
    public partial class Maakonnad : ContentPage
    {
        Image img;
        Picker picker, picker2;
        StackLayout st;
        string[] maakond = new string[15] { "Harjumaa", "Läänemaa", "Lääne-Virumaa", "Ida-Virumaa"
            , "Hiiumaa", "Saaremaa", "Raplamaa", "Järvamaa", "Jõgevamaa", "Pärnumaa"
            , "Viljandimaa", "Tartumaa", "Valgamaa", "Põlvamaa", "Võrumaa" };
        string[] pealinn = new string[15] { "Tallinn", "Haapsalu", "Rakvere", "Narva"
            , "Kärdla", "Kuressaare", "Rapla", "Paide", "Jõgeva", "Pärnu"
            , "Viljnadi", "Tartu", "Valga", "Põlva", "Võru" };
        public Maakonnad()
        {
            picker = new Picker
            {
                Title = "Maakonnad"
            };
            picker.Items.Add("Harjumaa");
            picker.Items.Add("Läänemaa");
            picker.Items.Add("Lääne-Virumaa");
            picker.Items.Add("Ida-Virumaa");
            picker.Items.Add("Hiiumaa");
            picker.Items.Add("Saaremaa");
            picker.Items.Add("Raplamaa");
            picker.Items.Add("Järvamaa");
            picker.Items.Add("Jõgevamaa");
            picker.Items.Add("Pärnumaa");
            picker.Items.Add("Viljandimaa");
            picker.Items.Add("Tartumaa");
            picker.Items.Add("Valgamaa");
            picker.Items.Add("Põlvamaa");
            picker.Items.Add("Võrumaa");

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            picker2 = new Picker
            {
                Title = "Pealinnad"
            };
            picker2.Items.Add("Tallinn");
            picker2.Items.Add("Haapsalu");
            picker2.Items.Add("Rakvere");
            picker2.Items.Add("Narva");
            picker2.Items.Add("Kärdla");
            picker2.Items.Add("Kuressaare");
            picker2.Items.Add("Rapla");
            picker2.Items.Add("Paide");
            picker2.Items.Add("Jõgeva");
            picker2.Items.Add("Pärnu");
            picker2.Items.Add("Viljandi");
            picker2.Items.Add("Tartu");
            picker2.Items.Add("Valga");
            picker2.Items.Add("Põlva");
            picker2.Items.Add("Võru");

            picker2.SelectedIndexChanged += Picker2_SelectedIndexChanged;

            img = new Image();
            if (picker2 == "Tallinn")
            {
                img.Source = ImageSource.FromFile("narva.jpg");
            }

            st = new StackLayout { Children = { picker, picker2, img } };
            Content = st;
        }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            picker2.SelectedIndex = picker.SelectedIndex;
        }
        private void Picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            picker.SelectedIndex = picker2.SelectedIndex;
        }
    }
}
