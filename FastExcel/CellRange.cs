﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastExcel
{
    /// <summary>
    /// Represents a range of cells
    /// </summary>
    public class CellRange
    {
        public string SheetName,
            ColumnStart,
            ColumnEnd;
        public int RowStart = 1;
        public int? RowEnd;
        public bool IsColumn = false;

        /// <summary>
        /// Defines a range of cells using a reference string
        /// </summary>
        /// <param name="reference">Reference string i.e. Sheet1!$A$1</param>
        public CellRange(string reference)
        {
            string[] splitReference = reference.Split('!');

            SheetName = splitReference[0];
            string range = splitReference[1];

            if (range.Contains(":"))
            {
                string[] splitRange = range.Split(':');
                IsColumn = splitRange[0].Count(c => c == '$') == 1;
                ColumnStart = splitRange[0].Split('$')[1];
                ColumnEnd = splitRange[1].Split('$')[1];
                if (!IsColumn)
                {
                    RowStart = Convert.ToInt32(splitRange[0].Split('$')[2]);
                    RowEnd = Convert.ToInt32(splitRange[1].Split('$')[2]);
                }
            }
            else
            {
                ColumnStart = ColumnEnd = range.Split('$')[1];
                RowEnd = RowStart = Convert.ToInt32(range.Split('$')[2]);
            }
        }

        /// <summary>
        /// Defines a cell range using varibles
        /// </summary>
        /// <param name="sheetName">Name of sheet</param>
        /// <param name="columnStart">Column Letter start</param>
        /// <param name="columnEnd">Column Letter end</param>
        /// <param name="rowStart">First row number</param>
        /// <param name="rowEnd">last row number</param>
        public CellRange(string sheetName, string columnStart, string columnEnd, int rowStart = 1, int? rowEnd = null)
        {
            if (columnStart == ColumnEnd && rowEnd == null)
                IsColumn = true;
            SheetName = sheetName;
            ColumnStart = columnStart;
            ColumnEnd = columnEnd;
            RowStart = rowStart;
            RowEnd = rowEnd;
        }

        /// <summary>
        /// Defines a cell range using varibles
        /// </summary>
        /// <param name="columnStart">Column Letter start</param>
        /// <param name="columnEnd">Column Letter end</param>
        /// <param name="rowStart">First row number</param>
        /// <param name="rowEnd">last row number</param>
        public CellRange(string columnStart, string columnEnd, int rowStart = 1, int? rowEnd = null)
           : this("", columnStart, columnEnd, rowStart, rowEnd)
        {
            
        }
    }
}
