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
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MegaDeskUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddQuote : Page
    {
        int width = 0;
        int depth = 0;
        int drawers = 0; //number of desk drawers
        int price = 0;
        int materialCost = 0;
        string[,] rushOrderArray = new string[3, 3];
        int rushCost = 0;
        int squareFeet;
        string material;
        string customerName;
        string rushOrder;
        string[] lines = new string[7];
        DeskVariable cDesk = new DeskVariable();
        List<DesktopMaterial> dMaterial = new List<DesktopMaterial>();
        DeskQuote test = new DeskQuote();

        public AddQuote()
        {
            this.InitializeComponent();         
        }

        private async void getQuote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //test.SaveRushOrder();
                rushOrderArray = test.GetRushOrder();
                cDesk.Width = int.Parse(widthTextBox.Text);
                cDesk.Depth = int.Parse(heightTextBox.Text);
                squareFeet = cDesk.Width * cDesk.Depth;
                cDesk.NumDrawers = int.Parse(numOfDrawersTextBox.Text);
                width = int.Parse(widthTextBox.Text);
                depth = int.Parse(heightTextBox.Text);
                drawers = int.Parse(numOfDrawersTextBox.Text);
                //material = deskMaterialComboBox.Items.ToString();
               material = ((ContentControl)deskMaterialComboBox.SelectedItem).Content.ToString();
               customerName = nameTextBox.Text;
               rushOrder = ((ContentControl)rushOptionsComboBox.SelectedItem).Content.ToString();

                //switch (rushOrder)
                //{
                //    case "3 day":
                //        if (squareFeet < 1000)
                //        {
                //            rushCost = int.Parse(rushOrderArray[0, 0]);
                //        }
                //        else if (squareFeet >= 1000 && squareFeet < 2000)
                //        {
                //            rushCost = int.Parse(rushOrderArray[0, 1]);
                //        }
                //        else if (squareFeet > 2000)
                //        {
                //            rushCost = int.Parse(rushOrderArray[0, 2]);
                //        }
                //        break;
                //    case "5 day":
                //        if (squareFeet < 1000)
                //        {
                //            rushCost = int.Parse(rushOrderArray[1, 0]);
                //        }
                //        else if (squareFeet >= 1000 && squareFeet < 2000)
                //        {
                //            rushCost = int.Parse(rushOrderArray[1, 1]);
                //        }
                //        else if (squareFeet > 2000)
                //        {
                //            rushCost = int.Parse(rushOrderArray[1, 2]);
                //        }
                //        break;
                //    case "7 day":
                //        if (squareFeet < 1000)
                //        {
                //            rushCost = int.Parse(rushOrderArray[2, 0]);
                //        }
                //        else if (squareFeet >= 1000 && squareFeet < 2000)
                //        {
                //            rushCost = int.Parse(rushOrderArray[2, 1]);
                //        }
                //        else if (squareFeet > 2000)
                //        {
                //            rushCost = int.Parse(rushOrderArray[2, 2]);
                //        }
                //        break;
                //    default:
                //        break;
                //}


                price = ((200 + (cDesk.Width * cDesk.Depth) + (50 * drawers)) + 50) + rushCost;
                string priceString = price.ToString();
                lines[4] = widthTextBox.Text;
                lines[1] = heightTextBox.Text;
                lines[2] = numOfDrawersTextBox.Text;
                lines[3] = material;
                lines[5] = rushOrder;
                lines[6] = priceString;
                lines[0] = customerName;
                string csv = JsonConvert.SerializeObject(lines);
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile saveFile = await storageFolder.CreateFileAsync("Quotes.json", CreationCollisionOption.OpenIfExists);
                await FileIO.AppendTextAsync(saveFile,csv);
                this.Frame.Navigate(typeof(MainPage), null);

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}