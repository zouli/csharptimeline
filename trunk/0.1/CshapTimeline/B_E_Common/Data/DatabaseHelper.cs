/*
 * User: zouli
 * Date: 2010-8-3
 * Time: 14:24
 */
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using b_e.Common.Config;

namespace b_e.Common.Data
{
	/// <summary>
	/// DB帮助类
	/// </summary>
	public class DatabaseHelper
	{
		#region 属性
		/// <summary>
		/// 连接字名称
		/// </summary>
		private static string _connectionName = "ConnectionString";
		private string ConnectionName {
			get { return _connectionName; }
			set { _connectionName = value; }
		}
		
		/// <summary>
		/// DB驱动类名
		/// </summary>
		private string _connectionProviderName;
		public string ConnectionProviderName {
			get { return _connectionProviderName; }
			set { _connectionProviderName = value; }
		}
		
		/// <summary>
		/// 连接字符串
		/// </summary>
		private string _connectionString;
		public string ConnectionString {
			get { return _connectionString; }
			set { _connectionString = value; }
		}
		#endregion
		
		public DatabaseHelper() : this(_connectionName) {}
		
		/// <param name="connectionName">连接字名称</param>
		public DatabaseHelper(string connectionName) : this(
			ConfigHelper.GetConnectionStrings(connectionName),
			ConfigHelper.GetConnectionProviderName(connectionName)
		)
		{
			this.ConnectionName = connectionName;
		}
		
		/// <param name="connectionString">连接字符串</param>
		/// <param name="connectionProviderName">DB驱动类名</param>
		public DatabaseHelper(string connectionString, string connectionProviderName)
		{
			this.ConnectionProviderName = connectionProviderName;
			this.ConnectionString = connectionString;
			
			SqlHelperDbProviderFactories.ConnectionProviderName = connectionProviderName;
		}
		
		/// <summary>
		/// 执行查询，取得DataTable
		/// </summary>
		/// <param name="sql">查询语句</param>
		/// <returns>查询结果</returns>
		public DataTable ExecuteReaderDataTable(string sql)
		{
			DbParameter[] parameters = new DbParameter[0];
			return ExecuteReaderDataTable(sql, parameters);
		}
		
		/// <summary>
		/// 执行查询，取得DataTable
		/// </summary>
		/// <param name="sql">查询语句</param>
		/// <param name="parameters">参数</param>
		/// <returns>查询结果</returns>
		public DataTable ExecuteReaderDataTable(string sql, params DbParameter[] parameters)
		{
			DataTable dt = new DataTable();
			dt.Load(SqlHelperDbProviderFactories.ExecuteReader(this.ConnectionString,
			                                                   CommandType.Text,
			                                                   sql,
			                                                   parameters));
			return dt;
		}
		
		/// <summary>
		/// 执行添加，修改，删除
		/// </summary>
		/// <param name="sql">添加，修改，删除语句</param>
		/// <returns>影响行数</returns>
		public int ExecuteNonQuery(string sql)
		{
			DbParameter[] parameters = new DbParameter[0];
			return ExecuteNonQuery(sql, parameters);
		}
		
		/// <summary>
		/// 执行添加，修改，删除
		/// </summary>
		/// <param name="sql">添加，修改，删除语句</param>
		/// <param name="parameters">参数</param>
		/// <returns>影响行数</returns>
		public int ExecuteNonQuery(string sql,params DbParameter[] parameters)
		{
			int result;
			if(null == dbTransaction)
			{
				result = SqlHelperDbProviderFactories.ExecuteNonQuery(this.ConnectionString,
				                                                      CommandType.Text,
				                                                      sql,
				                                                      parameters);
			}
			else
			{
				result = SqlHelperDbProviderFactories.ExecuteNonQuery(dbTransaction,
				                                                      CommandType.Text,
				                                                      sql,
				                                                      parameters);
			}
			return result;
		}
		
		private DbTransaction dbTransaction = null;
		private DbConnection connectionTransaction = null;
		/// <summary>
		/// 启动事务
		/// </summary>
		public void BeginTransaction() 
		{
			connectionTransaction = SqlHelperDbProviderFactories.GetProviderFactory().CreateConnection();
			connectionTransaction.ConnectionString = this.ConnectionString;
			connectionTransaction.Open();
			
			dbTransaction = connectionTransaction.BeginTransaction();
		}
		
		/// <summary>
		/// 回滚事务
		/// </summary>
		public void RollbackTransaction()
		{
			dbTransaction.Rollback();
			connectionTransaction.Close();
		}
		
		/// <summary>
		/// 提交事务
		/// </summary>
		public void CommitTransaction()
		{
			dbTransaction.Commit();
			connectionTransaction.Close();
		}
		
		/// <summary>
		/// 创建Parameter
		/// </summary>
		public DbParameter CreateParameter(string field, DbType dbtype, string value)
		{
			DbParameter param = SqlHelperDbProviderFactories.GetProviderFactory().CreateParameter();
			param.ParameterName = field;
			param.DbType = dbtype;
			param.Value = value;
			return param;
		}
	}
}
