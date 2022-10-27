using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework2.Helpers
{
    public class ExcelHelpers
    {
        //create a collection of a custom class
        private static List<Datacollection> _dataCol = new List<Datacollection>();

        //populate data into collection
        public static void PopulateInColletion(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //iterate through the rows and columns of the table
            for(int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    _dataCol.Add(dtTable);
                }
            }
        }

        private static DataTable ExcelToDataTable(string fileName)
        {
            //open file and returns as stream
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    //get all the tables
                    DataTableCollection table = result.Tables;
                    //store it in DataTable
                    DataTable resultTable = table["Sheet1"];
                    return resultTable;
                }
            }

        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //retriving Data using LINQ to reduce much of iterations
                string data = (from colData in _dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch
            {
                return null;
            }

        }
    }

    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }

}
