using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo_1736
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MainWindow.xaml.cs是處理主視窗背後的 C# 程式碼檔案。
        //這裡通常包含了與主視窗相關的事件處理邏輯，例如按鈕點擊事件、視窗載入事件等。
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private async Task LoadData()
        {
            try
            {
                Stock stock = new Stock();
                var stockData = await stock.GetData();

                dgStockDataGrid.ItemsSource = stockData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("資料載入失敗: " + ex.Message);
            }
        }
        //private void LoadData()
        //{
        //    try
        //    {
        //        Stock stock = new Stock();
        //        var stockData = stock.GetData(); // 直接呼叫同步的 GetData 方法

        //        dgStockDataGrid.ItemsSource = stockData; // 假設這裡是要顯示資料
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("資料載入失敗: " + ex.Message);
        //    }
        //}
    }
}