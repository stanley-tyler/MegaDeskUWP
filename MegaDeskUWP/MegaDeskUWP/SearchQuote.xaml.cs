using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MegaDeskUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchQuote : Page
    {
        public SearchQuote()
        {
            this.InitializeComponent();
        }

        private async void searchButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = "";
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile saveFile = await storageFolder.GetFileAsync("Quotes.json");
           
            string quoteFile = await FileIO.ReadTextAsync(saveFile);
            
            //quoteFile = JsonConvert.DeserializeObject<string>(quoteFile);
            string material;
            string[] splitString;
            material = ((ContentControl)materialComboBox.SelectedItem).Content.ToString();

            for (int i = 0; i < quoteFile.Length; i++)
            {
                if (quoteFile.Contains(material))
                {
                    splitString = quoteFile.Split(',');
                    for (int j = 0; j < splitString.Length; j++)
                    {
                        resultTextBox.Text += splitString[j] + "\n";
                    }
                }

            }
        }
    }
}
