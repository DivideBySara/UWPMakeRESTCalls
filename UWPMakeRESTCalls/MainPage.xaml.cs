using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPMakeRESTCalls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // *** Gets the http of a website ***
            //var httpClient = new HttpClient();
            //var text = await httpClient.GetStringAsync("http://sarajade.co.nf");
            //tBox.Text = text;

            // *** Doesn't work: Parses xml to get titles of a feed ***
            //var client = new HttpClient();
            //var response = await client.GetAsync("http://labs.pearson.com/feed");
            //var text = await response.Content.ReadAsStringAsync();

            //XElement xml;

            //try
            //{
            //    xml = XElement.Parse(text);
            //    var titles = xml.Element("channel")
            //                  .Elements("item")
            //                  .Select(i => i.Element("title").Value);
            //    tBox.Text = string.Join("\n", titles);
            //}
            //catch (Exception)
            //{
            //    tBox.Text = "Exception thrown";
            //}

            //*** Gets the names of plants in the api in the ValuesController using built-in deserializer
            //var client = new HttpClient();
            //var response = await client.GetAsync("http://localhost:12394/api/Values"); // I had to use the localhost # in an open window
            //                                                                         // as a result of starting an instance of the webapp

            //using (var stream = await response.Content.ReadAsStreamAsync())
            //{
            //    var deserializer = new DataContractJsonSerializer(typeof(Plant[]));
            //    var garden = (Plant[])deserializer.ReadObject(stream);
            //    var names = string.Join(", ", garden.Select(plant => plant.Name));

            //    tBox.Text = names;
            //}

            // *** Gets the categories of the plants in the api in the ValuesController using Newtonsoft deserializer
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:12394/api/Values"); // I had to use the localhost # in an open window
                                                                                   // as a result of starting an instance of the webapp
            var text = await response.Content.ReadAsStringAsync();
            Plant[] garden = JsonConvert.DeserializeObject<Plant[]>(text);

            tBox.Text = string.Join(", ", garden.Select(plant => plant.Category));
        }

    }

    // See ValuesController for the source of this info.
    // Right-Click GardenWebApp --> Debug --> Start new instance
    // localhost1234://.../api/values
    // Copy all
    // Edit --> Past special --> Paste JSON as classes
    public class Garden
    {
        public Plant[] plants { get; set; }
    }

    public class Plant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
