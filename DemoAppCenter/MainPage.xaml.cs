using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace DemoAppCenter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Evento_Clicked(object sender, EventArgs e)
        {
        
           var evento = new Dictionary<string, string>
                    {
                        { "Usuario", "Bertuzzi" },
                        { "ClienteID", "1" }
                    };

            Analytics.TrackEvent("Login Efetuado", evento);
        }

        public void Erro_Clicked(object sender, EventArgs e)
        {

            Crashes.GenerateTestCrash();

            try
            {
                List<string> teste = null;
                teste.Add("Vai dar erro");
            }
            catch(Exception ex)
            {
                var properties = new Dictionary<string, string> {
                    { "Category", "Tela de Login" },
                    { "List", "Add" }
                  };
                Crashes.TrackError(ex, properties);
            }
        }
    }
}
