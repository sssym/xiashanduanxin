﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace 霞山妇幼短信
{
    class ImportDV
    {
        public void btnImpot_Click(DataGridView dgv,TextBox textBox)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Excel文件";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.Filter = "Excel文件(*.xlsx,*.xls)|*.xlsx;*.xls|所有文件(*.*) |*.*";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strName = ofd.FileName;
                textBox.Text = strName;
            }

            if (strName == "")
            {
                MessageBox.Show("没有选择Excel文件，无法导入");
                return;
            }

            ExcelToDataGridView(strName, dgv);
            //ExcelToSqlServer(strName);
            // GetCount();
            //  DisplayExcel();

        }


        public void ExcelToDataGridView(String str, DataGridView gv)
        {
            OleDbConnection ole = null;
            OleDbDataAdapter da = null;
            DataTable dt = null;
            string strConn = "";

            if (str.Substring(str.Length - 2) == "sx")
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + str + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            }
            else
            {
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;"
                                 + "Data Source=" + str + ";"
                                 + "Extended Properties=Excel 5.0";
            }
            //string sTableName = comboBox1.Text.Trim();
            string strExcel = "select * from [Sheet1$]";
            try
            {
                ole = new OleDbConnection(strConn);
                ole.Open();
                da = new OleDbDataAdapter(strExcel, ole);
                dt = new DataTable();
                da.Fill(dt);
                gv.DataSource = dt;
                ole.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                if (ole != null)
                    ole.Close();
            }
        }
    }
}
