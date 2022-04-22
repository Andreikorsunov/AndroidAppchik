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
        Editor et;
        Label lb;
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
            lb = new Label();
            et = new Editor 
            { 
                Placeholder = "Maakond",
                Text = ""
            };
            et.TextChanged += ET_TextChanged;

            Content = new StackLayout { Children = { picker, picker2, img, lb, et } };
        }

        private void ET_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (et.Text == "Harjumaa")
            {
                img.Source = "harjumaa.png";
                lb.Text = "Harju maakond ehk Harjumaa on 1. järgu haldusüksus Põhja-Eestis. " +
                    "Harju maakond hõlmab peaaegu täielikult Eesti NSV aegse Harju rajooni ala 1960. aastate lõpul väljakujunenud piirides. " +
                    "Ajaloolisest Harjumaast hõlmab tänapäevane Harju maakond ligikaudu põhjapoolsed kaks kolmandikku.";
            }
            else if (et.Text == "Läänemaa")
            {
                img.Source = "laanemaa.png";
                lb.Text = "Lääne maakond ehk Läänemaa on 1. järgu haldusüksus Eesti lääneosas." +
                    "Hõlmab ajaloolise Läänemaa põhjaosa. " +
                    "Naabermaakonnad on kirdes Harju maakond, idas Rapla maakond, lõunas Pärnu maakond, edelas Saare ja läänes Hiiu maakond. " +
                    "Maakonnas on kolm omavalitsusüksust: Haapsalu linn, Lääne-Nigula vald ja Vormsi vald.";
            }
            else if (et.Text == "Lääne-Virumaa")
            {
                img.Source = "laaneviru.png";
                lb.Text = "ääne-Viru maakond ehk Lääne-Virumaa on 1. järgu haldusüksus Eestis. " +
                    "Lääne-Viru maakond asub Põhja-Eestis. Lääne-Virumaa piirneb idas Ida-Viru, lõunas Jõgeva, ning läänes Järva ja Harju maakonnaga. " +
                    "Lääne-Virumaa kõrgeim tipp on Emumägi, pikim jõgi Kunda jõgi ja suurim järv on Porkuni järv. " +
                    "Rannajoone pikkus on 134 km.";
            }
            else if (et.Text == "Ida-Virumaa")
            {
                img.Source = "ida-viru.png";
                lb.Text = "Ida-Viru maakond ehk Ida-Virumaa on 1. järgu haldusüksus Eesti kirdeosas, Ida-Eesti piirkonnas. " +
                    "Hõlmab ajaloolise Virumaa idaosa. " +
                    "Ida-Virumaa piirneb läänes Lääne-Viru ja edelas Jõgeva maakonnaga ning idas Leningradi oblastiga Venemaal.";
            }
            else if (et.Text == "Hiiumaa")
            {
                img.Source = "hiiumaa.png";
                lb.Text = "Hiiumaa on Eesti suuruselt teine saar, Lääne-Eesti saarestiku põhjapoolseim saar. " +
                    "Hiiumaa piirneb kagus Väinamerega, põhjas ja läänes avamerega. " +
                    "Saart eraldab Saaremaast Soela väin ja Vormsist Hari kurk. " +
                    "Hiiumaast loodes asub laevasõiduks ohtlik Hiiu madal.";
            }
            else if (et.Text == "Hiiumaa")
            {
                img.Source = "hiiumaa.png";
                lb.Text = "Hiiumaa on Eesti suuruselt teine saar, Lääne-Eesti saarestiku põhjapoolseim saar. " +
                    "Hiiumaa piirneb kagus Väinamerega, põhjas ja läänes avamerega. " +
                    "Saart eraldab Saaremaast Soela väin ja Vormsist Hari kurk. " +
                    "Hiiumaast loodes asub laevasõiduks ohtlik Hiiu madal.";
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            picker2.SelectedIndex = picker.SelectedIndex;
        }
        private void Picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            picker.SelectedIndex = picker2.SelectedIndex;
            if (picker2.SelectedIndex == 0)
            {
                img.Source = "tallinn.png";
                lb.Text = "Tallinn on Eesti pealinn ja Harju maakonna halduskeskus" +
                    ", mis paikneb Põhja-Eesti rannikul Tallinna lahe ääres. " +
                    "Teadaolevalt on Tallinna, tolleaegse nimega Revalit, " +
                    "koos oma kodanikkonnaga esimest korda mainitud linnana aastal 1238.";
            }
            else if (picker2.SelectedIndex == 1)
            {
                img.Source = "haapsalu.jpg";
                lb.Text = "Haapsalu on linn Eestis Läänemere ääres Haapsalu lahe lõunakaldal, " +
                    "Lääne maakonna ja omavalitsusliku Haapsalu linna halduskeskus. " +
                    "Linna territooriumi hulka kuulub Krimmi holm.";
            }
            else if (picker2.SelectedIndex == 2)
            {
                img.Source = "rakvere.jpg";
                lb.Text = "Rakvere on linn Lääne-Viru maakonnas, maakonna haldus-, majandus- ja kultuurikeskus. " +
                    "Rakvere on linn alates 12. juunist 1302, kui sai Taani kuningas Erik Menvedilt Lübecki linnaõiguse. " +
                    "Rakvere linn on elanike arvult Eesti suuruselt 8. linn ja 14. omavalitsus.";
            }
            else if (picker2.SelectedIndex == 3)
            {
                img.Source = "narva.jpg";
                lb.Text = "Rakvere on linn Lääne-Viru maakonnas, maakonna haldus-, majandus- ja kultuurikeskus. " +
                    "Rakvere on linn alates 12. juunist 1302, kui sai Taani kuningas Erik Menvedilt Lübecki linnaõiguse. " +
                    "Rakvere linn on elanike arvult Eesti suuruselt 8. linn ja 14. omavalitsus.";
            }
            else if (picker2.SelectedIndex == 4)
            {
                img.Source = "kardla.jpg";
                lb.Text = "Kärdla on Hiiu maakonna halduskeskus ja Hiiumaa valla sisene linn. " +
                    "Tegemist on ainsa linnaga maakonnas. " +
                    "Läbi linna voolavad Nuutri jõgi, Lumumba jõgi ja Kärdla oja. " +
                    "Paul Ariste on Kärdla rootsikeelset nime Kärrdal tõlkinud kui Võsaoru. " +
                    "Hiidlaste seltside jaotuses nimetatakse Kärdla rahvast kohvilähkriteks.";
            }
            else if (picker2.SelectedIndex == 5)
            {
                img.Source = "kuressaare.jpg";
                lb.Text = "Kuressaare on Saaremaa ainus linn, Saaremaa valla keskus ja Saare maakonna halduskeskus. " +
                    "Kuressaare asub Saaremaa lõunarannikul ja on ühtlasi Eesti läänepoolseim linn.";
            }
            else if (picker2.SelectedIndex == 6)
            {
                img.Source = "rapla.jpg";
                lb.Text = "Rapla on linn Kesk-Eestis, Tallinnast umbes 50 km edelas. " +
                    "Rapla on Rapla maakonna ja Rapla valla halduskeskus. " +
                    "Linna läbib Vigala jõgi ehk Konuvere jõgi.";
            }
            else if (picker2.SelectedIndex == 7)
            {
                img.Source = "paide.jpg";
                lb.Text = "Paide on linn Kesk-Eestis, Järva maakonna ja Paide linna nimelise omavalitsusüksuse keskus." +
                    " Linna on esmakordselt kirjalikes allikates mainitud seoses 1265. aastaga, mil alustati Paide ordulinnuse rajamist." +
                    " Asula sai linnaõigused 1291. aastal. 2019. aasta alguse seisuga elas linnas 7905 inimest.";
            }
            else if (picker2.SelectedIndex == 8)
            {
                img.Source = "jogeva.jpg";
                lb.Text = "Jõgeva on linn Jõgeva maakonnas, maakonna ja Jõgeva valla halduskeskus. " +
                    "Linna idapiiril voolab Pedja jõgi. Linna pindala on 3,86 km², 2012. aastal oli arvestuslik rändega rahvaarv 5597. " +
                    "Jõgeva sai aleviks 13. oktoobril 1919 ja kolmanda astme linnaks 1. mail 1938.";
            }
            else if (picker2.SelectedIndex == 9)
            {
                img.Source = "parnu.jpg";
                lb.Text = "Pärnu on sadamalinn Eesti edelarannikul Pärnu lahe ääres Pärnu jõe alamjooksul," +
                    " samanimelise haldusüksuse ja Pärnu maakonna halduskeskus. " +
                    "Ligi 40 000 elanikuga on Pärnu Eesti suuruselt neljas linn. " +
                    "Linn hõlmab 33,15 km² suuruse maa-ala, sealhulgas 20% on parkide ja haljasalade all.";
            }
            else if (picker2.SelectedIndex == 10)
            {
                img.Source = "viljandi.jpg";
                lb.Text = "Viljandi on linn Lõuna-Eestis. " +
                    "Viljandi on Viljandi maakonna halduskeskus. " +
                    "Linn asub Sakala kõrgustikul, Viljandi järve kaldal." +
                    " 2000. aasta rahvaloenduse järgi oli Viljandis elanikke 20 756; 2004. aastal 20 454 ja 2012. aasta jaanuaris arvestuslikult 17 868." +
                    " Viljandi on elanike arvult Eestis kuues linn.";
            }
            else if (picker2.SelectedIndex == 11)
            {
                img.Source = "tartu.jpg";
                lb.Text = "Tartu on rahvaarvult Eesti teine linn, linnasisese linnana haldusliku Tartu linna keskasula," +
                    " Lõuna-Eesti suurim keskus ja Tartu maakonna halduskeskus. " +
                    "Linn asub Emajõe kallastel.";
            }
            else if (picker2.SelectedIndex == 12)
            {
                img.Source = "valga.jpg";
                lb.Text = "Valga on maakonnalinn Lõuna-Eestis Eesti-Läti piiril, Valga maakonna ja Valga valla halduskeskus. " +
                    "Valga on Eesti kõige lõunapoolsem linn. " +
                    "Enne iseseisvate Eesti ja Läti riikide teket moodustas Valga koos Läti Valkaga ühtse linna. " +
                    "Valgat läbib Pedeli jõgi. " +
                    "Linnas asub Valga raudteejaam.";
            }
            else if (picker2.SelectedIndex == 13)
            {
                img.Source = "polva.jpg";
                lb.Text = "Põlva on vallasisene linn Orajõe alamjooksul Põlva maakonnas Põlva vallas." +
                    " Põlvas asub nii Põlva valla kui Põlva maakonna halduskeskus. ";
            }
            else if (picker2.SelectedIndex == 14)
            {
                img.Source = "voru.jpg";
                lb.Text = "Võru on linn Eesti kaguosas, mis on Võru maakonna haldus- ja majanduskeskuseks. " +
                    "Linna pindala on 14 km² ja elanikke on 2019. aasta seisuga 11 859. " +
                    "Võrus räägitakse peamiselt eesti ja võru keelt. " +
                    "Võru kaitsepühak on püha Jüri, kelle nime kannab ka Võru peatänav.";
            }
        }
    }
}