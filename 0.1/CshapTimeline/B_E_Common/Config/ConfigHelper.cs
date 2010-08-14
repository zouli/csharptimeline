/*
 * User: zouli
 * Date: 2010-8-3
 * Time: 14:35
 */
using System;
using System.Configuration;

namespace b_e.Common.Config
{
	/// <summary>
	/// 配置文件帮助类
	/// </summary>
	/// <remarks>使用是需要同时引用System.Configuration.dll</remarks>
	public class ConfigHelper
	{
		public ConfigHelper()
		{}
		
		/// <summary>
		/// 根据ConnectionName取得ConnectionString
		/// </summary>
		/// <param name="connectionName">连接字符串名称</param>
		/// <returns>ConnectionString</returns>
		public static string GetConnectionStrings(string connectionName)
		{
			string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString.ToString();
			return connectionString;
		}
		
		/// <summary>
		/// 根据连ConnectionName取得ProviderName
		/// </summary>
		/// <param name="connectionName">连接字符串名称</param>
		/// <returns>ProviderName</returns>
		public static string GetConnectionProviderName(string connectionName)
		{
			string connectionProviderName = ConfigurationManager.ConnectionStrings[connectionName].ProviderName.ToString();
			return connectionProviderName;
		}
	}
}
