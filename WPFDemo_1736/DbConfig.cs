using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo_1736
{
    /// <summary>
    /// 提取app.config檔中的連線字串
    /// </summary>
    public  static class DbConfig
    {
        //將app.config中的連線字串提取 並使用static(靜態)，當應用程式開啟時會自動執行，當使用此類別也不需要再new出來直接就能使用方便存取

        /// <summary>
        /// 連線字串變數
        /// </summary>
        //透過=>符號 將App.config所設定的連線字串值返還存到 ConnectionString中
        // ConfigurationManager這是專門讀取配置檔中的設置資料的類
        public static string ConnectionString=> ConfigurationManager.ConnectionStrings["OracleDbConnection"].ConnectionString;
    }
}
