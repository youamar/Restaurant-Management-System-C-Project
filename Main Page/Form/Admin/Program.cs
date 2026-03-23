using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main_Page.Order;
using Main_Page.Reservation;

namespace Main_Page
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Customer_Login());

            //string folderPath = @"C:\Users\End User\source\repos\IOOP\Hall Picture";  // 这里是你的图片文件夹路径
            //string connectionString = "VegeMeat";

            //// 获取文件夹中所有的 JPG 文件
            //string[] files = Directory.GetFiles(folderPath, "*.jpg");

            //foreach (string filePath in files)
            //{
            //    // 获取文件名，不包含扩展名（例如：NasiLemak.jpg -> NasiLemak）
            //    string itemName = Path.GetFileNameWithoutExtension(filePath);

            //        // 读取图片文件并转换成 byte[]
            //        byte[] imageBytes = File.ReadAllBytes(filePath);

            //        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ToString()))
            //        {
            //            conn.Open();

            //            // 插入 SQL 语句
            //            string query = "UPDATE hall SET photo = @Photo WHERE hall_id = @ItemID";
            //            using (SqlCommand cmd = new SqlCommand(query, conn))
            //            {
            //                // 参数化查询，防止 SQL 注入
            //                cmd.Parameters.AddWithValue("@ItemID", itemName);
            //                cmd.Parameters.AddWithValue("@Photo", imageBytes);

            //                // 执行更新操作
            //                int rowsAffected = cmd.ExecuteNonQuery();

            //                if (rowsAffected > 0)
            //                {
            //                    Console.WriteLine($"Item '{itemName}' 的图片已成功更新！");
            //                }
            //                else
            //                {
            //                    Console.WriteLine($"Item '{itemName}' 找不到，无法更新！");
            //                }
            //            }
            //        }


            //}

            //Console.WriteLine("所有图片已上传完成！");
        }
    }
}
