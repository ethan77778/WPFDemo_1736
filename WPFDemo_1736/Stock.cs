using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Dapper;

namespace WPFDemo_1736
{
    /// <summary>
    /// 庫存
    /// </summary>
   public class Stock
    {
        /// <summary>
        /// 庫存編號
        /// </summary>
        public string Stock_No { get; set; }
        /// <summary>
        /// 庫存名稱
        /// </summary>
        public string Stock_Name { get; set; }
        /// <summary>
        /// 最低價格
        /// </summary>
        public string Low_Price{get;set; }
        /// <summary>
        /// 最高價格
        /// </summary>
        public string High_Price { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime Modify_Date { get; set; }
        /// <summary>
        /// 修改使用者
        /// </summary>
        public string Modify_User {  get; set; }

        /// <summary>
        /// 抓取資料 
        /// </summary>
        /// <returns></returns>
        //使用IEnumerable而不是使用list好處是IEnumerable<T> 不會立刻加載所有的元素，它支持延遲加載（Lazy Loading）
        //對於處理大量資料或者需要異步處理的場景非常有用。
        //而list 它表示一個已經加載完成的集合，因此每個元素會在返回時都被加載到內存中。如果你的數據量很大，
        //返回 List<T> 會消耗更多的內存
        public async Task<IEnumerable<Stock>> GetData()
        {
            try
            {
                // query存放sql語法
                string query = "select  stock_no,stock_name,low_price,high_price,modify_date,modify_user from STOCK t";
                //建立connection 變數存放從DbConfig類中的連線字串
                using (var connection = new OracleConnection(DbConfig.ConnectionString)) 
                {
                    //OpenAsync 方法為打開資料庫連接
                    await connection.OpenAsync();
                    //QueryAsync方法負責執行 SQL 查詢並返回查詢結果
                    var stockData =await connection.QueryAsync<Stock>(query);
                    return stockData;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("查詢資料失敗: " + ex.Message);
                return new List<Stock>();
            }
        }
        //public IEnumerable<Stock> GetData()
        //{
        //    try
        //    {
        //        // query 存放 SQL 語法
        //        string query = "select stock_no, stock_name, low_price, high_price, modify_date, modify_user from STOCK t";

        //        // 建立 connection 變數存放從 DbConfig 類中的連線字串
        //        using (var connection = new OracleConnection(DbConfig.ConnectionString))
        //        {
        //            connection.Open(); // 使用同步開啟連線
        //            var stockData = connection.Query<Stock>(query); // 使用同步的 Query 方法
        //            return stockData;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("查詢資料失敗: " + ex.Message);
        //        return new List<Stock>();
        //    }
        //}
    }
}
