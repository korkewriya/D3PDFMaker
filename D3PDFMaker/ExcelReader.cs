using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NPOI.SS.UserModel;

namespace D3PDFMaker
{
    public class ExcelReader
    {
        FileStream stream;
        IWorkbook book;

        public ExcelReader(string file)
        {
            stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            book = WorkbookFactory.Create(stream);
        }

        public void Close()
        {
            book.Close();
            stream.Close();
        }

        public ISheet GetSheet(int sheetIndex)
        {
            return book.GetSheetAt(sheetIndex);
        }

        public int GetSheetLen()
        {
            return book.NumberOfSheets;
        }

        public string[] GetSheetNameArr(int sheetLen)
        {
            var sheetNameArr = new string[sheetLen];
            for(int i = 0; sheetLen > i; i++)
            {
                var sheet = GetSheet(i);
                sheetNameArr[i] = sheet.SheetName;
            }
            return sheetNameArr;
        }

        public int GetLastRow(ISheet sheet)
        {
            return sheet.LastRowNum;
        }

        public List<string> ReadCol(ISheet sheet, int colIndex, int fromRow)
        {
            List<string> ColContent = new List<string>();
            int lastRowNum = GetLastRow(sheet);

            for (int rowIndex = fromRow; rowIndex <= lastRowNum; rowIndex++)
            {
                IRow row = sheet.GetRow(rowIndex);

                if (row == null) continue;

                ICell cell = row.GetCell(colIndex);
                ColContent.Add(Convert.ToString(cell));
            }
            return ColContent;
        }

        // 規定のエクセルシートか調べる
        public bool IsRegularExcel(ISheet sheet)
        {
            bool HasValue(int _row, int _col, string value)
            {
                IRow row = sheet.GetRow(_row);
                ICell cell = row.GetCell(_col);
                if (Convert.ToString(cell) == value) return true;
                return false;
            }

            int[,] coordArr = new int[4, 2] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 1, 2 } };
            string[] valueArr = new string[] { "第三企画 マンション名・地名リスト",
                                               "No.",
                                               "印刷 マンション名・地名",
                                               "部数" };
            for (int i = 0; valueArr.Length > i; i++)
            {
                int _row = coordArr[i, 0];
                int _col = coordArr[i, 1];
                if (!HasValue(_row, _col, valueArr[i])) return false;
            }
            return true;
        }
    }
}
