using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MegaDeskUWP
{
    class DeskQuote
    {
        public int deskQuote { get; set; }
        public DateTime quoteDate { get; set; }

        public int BASEPRICE = 200;
        private int BASESIZE = 1000;
        private int DRAWERCOST = 50;
        private string text;

        public async void SaveRushOrder()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile saveFile = await storageFolder.GetFileAsync("rushOrderPrices.txt");
            text = await FileIO.ReadTextAsync(saveFile);
        }

        public string[,] GetRushOrder()
        {
            SaveRushOrder();
            int rows = 3;
            int columns = 3;
            string[,] grid = new string[rows, columns];
            int count = 0;

            try
            {
                
                for (int i = 0; i != rows; i++)
                {
                    for (int j = 0; j != columns; j++)
                    {
                        grid[i, j] += text;
                        count++;
                    }
                }
                return grid;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}