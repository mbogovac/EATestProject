using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework2.Helpers
{
    public class HtmlTableHelper
    {
        private static List<TableDataCollection> _tableDataCollections;

        public static void ReadTable(IWebElement table)
        {
            //initialize the table
            _tableDataCollections = new List<TableDataCollection>();

            //get all columns from the table
            var columns = table.FindElements(By.TagName("th"));
            //get all rows
            var rows = table.FindElements(By.TagName("tr"));

            //create row index
            int rowIndex = 0;
            foreach(var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));
                //store data only if it has value in row
                if(colDatas.Count != 0)
                {
                    foreach(var colValue in colDatas)
                    {
                        _tableDataCollections.Add(new TableDataCollection
                        { 
                            RowNumber = rowIndex,
                            ColumnName = columns[colIndex].Text != "" ?
                                         columns[colIndex].Text : colIndex.ToString(),
                            ColumnValue = colValue.Text,
                            ColumnSpecialValues = GetControl(colValue)
                        });

                        //move to nex column
                        colIndex++;
                    }
                    rowIndex++;
                }
            }
        }

        private static ColumnSpecialValue GetControl(IWebElement columnValue)
        {
            ColumnSpecialValue columnSpecialValue = null;
            //check if the control has specific tags like input/hyperlink etc
            if(columnValue.FindElements(By.TagName("a")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = "hyperlink"
                };
            }

            if(columnValue.FindElements(By.TagName("input")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };
            }
            return columnSpecialValue;
        }

        public static void PerformActionOnCell(string columnIndex, string refColumnName, string refColumnValue, string controlToOperate = null)
        {
            foreach(int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _tableDataCollections
                            where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();

                //need to operate on those controls
                if(controlToOperate != null && cell != null)
                {
                    if(cell.ControlType == "hyperlink")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.Text == controlToOperate
                                               select c).SingleOrDefault();

                        returnedControl.Click();
                    }

                    if (cell.ControlType == "input")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.GetAttribute("value") == controlToOperate
                                               select c).SingleOrDefault();

                        returnedControl.Click();
                    }
                }
                else
                {
                    cell.ElementCollection?.First().Click();
                }
            }
        }

        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            //dynamic row
            foreach(var table in _tableDataCollections)
            {
                if(table.ColumnName == columnName && table.ColumnValue == columnValue)
                    yield return table.RowNumber;
            }
        }


    }

    public class TableDataCollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public ColumnSpecialValue ColumnSpecialValues { get; set; }
    }

    public class ColumnSpecialValue
    {
        public IEnumerable<IWebElement> ElementCollection { get; set; }
        public string ControlType { get; set; }
    }


}
