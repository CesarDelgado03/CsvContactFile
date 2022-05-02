using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvContact.Helpers
{
    public class FileHelper
    {
        public DataTable GetDAtaFromCsv(string FilePath, string ColumnPosition)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("DateBirht");
            dt.Columns.Add("Address");
            dt.Columns.Add("Phone");
            dt.Columns.Add("CredictCard");
            dt.Columns.Add("Franchise");
            dt.Columns.Add("Email");
            dt.AcceptChanges();

            int[] columns = ColumnPosition.Split('|').Select(n => Convert.ToInt32(n)).ToArray();

            foreach (string line in System.IO.File.ReadAllLines(FilePath).Skip(1))
            {
                var values = line.Split(',');
                var dr = dt.NewRow();
                int index = 0;
                foreach (int col in columns)
                {
                    dr[index] = values[col - 1];
                    index++;
                }
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();

            return dt;
        }

        public string DataToCsv(DataTable dt, string FileFolder)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }
            var dtNow = DateTime.Now.ToString().Replace(" ", "").Replace("/", "_").Replace(":", "_");
            var NewFileName = $@"{FileFolder}\CsvFile_{dtNow}.csv";
            System.IO.File.WriteAllText(NewFileName, sb.ToString());

            return NewFileName;
        }
    }
}
