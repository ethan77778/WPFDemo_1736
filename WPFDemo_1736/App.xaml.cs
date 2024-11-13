using System.Configuration;
using System.Data;
using System.Windows;
using Oracle.ManagedDataAccess.Client;

namespace WPFDemo_1736
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //App.xaml.cs 是應用程式的入口點，與App.xaml一起執行，此檔案包含程式開啟與關閉等相關邏輯

        /// <summary>
        /// 儲存資料庫連接的變數
        /// </summary>
        // OracleConnection這個類別是負責與 Oracle 資料庫進行通訊和執行 SQL 查詢等操作。
        private OracleConnection _oracleConnection;
        /// <summary>
        /// 程式開啟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                // 初始化 _oracleConnection 物件，並使用 DbConfig 取得資料庫連線字串
                _oracleConnection = new OracleConnection(DbConfig.ConnectionString);
                _oracleConnection.Open();
                MessageBox.Show("資料庫連線成功");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("無法連接資料庫"+ex.Message);
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();            
        }

        /// <summary>
        /// 程式關閉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Exit_1(object sender, ExitEventArgs e)
        {
            // ?的用意是如果 _oracleConnection 是 null，則不會執行 Close()
            //如果沒加_oracleConnection 是 null會拋出錯誤
            _oracleConnection?.Close();
        }
    }

}
