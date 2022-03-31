using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Utilities
{
    public class TablePrinter
    {
        private readonly string[] _titles;
        private readonly List<int> _lengths;
        private readonly List<string[]> _rows = new List<string[]>();

        public TablePrinter(params string[] titles)
        {
            this._titles = titles;
            _lengths = titles.Select(t => t.Length).ToList();
        }

        public void AddRow(params object[] row)
        {
            if (row.Length != _titles.Length)
            {
                throw new System.Exception($"Added row length [{row.Length}] is not equal to title row length [{_titles.Length}]");
            }
            _rows.Add(row.Select(o => o.ToString()).ToArray());
            for (int i = 0; i < _titles.Length; i++)
            {
                if (_rows.Last()[i].Length > _lengths[i])
                {
                    _lengths[i] = _rows.Last()[i].Length;
                }
            }
        }

        public void Print()
        {
            _lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");

            string line = "";
            for (int i = 0; i < _titles.Length; i++)
            {
                line += "| " + _titles[i].PadRight(_lengths[i]) + ' ';
            }
            System.Console.WriteLine(line + "|");

            _lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");

            foreach (var row in _rows)
            {
                line = "";
                for (int i = 0; i < row.Length; i++)
                {
                    if (int.TryParse(row[i], out int n))
                    {
                        line += "| " + row[i].PadLeft(_lengths[i]) + ' ';  // numbers are padded to the left
                    }
                    else
                    {
                        line += "| " + row[i].PadRight(_lengths[i]) + ' ';
                    }
                }
                System.Console.WriteLine(line + "|");
            }

            _lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");
        }
    }
}
