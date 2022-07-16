using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminViewTest.DataModel
{
    public class DataGridItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public int Age { get; set; }
        public bool Remark { get; set; }
    }

    public class DataGridDemo
    {
        public DataGridDemo()
        {
            DataCollection = new List<DataGridItem>()
            {
                new DataGridItem
                {
                    Id=0,
                    Name="Symin",
                    Age=24,
                    Remark=true,
                },
                new DataGridItem
                {
                    Id=1,
                    Name="Mike",
                    Age=23,
                    Remark=false,
                },
                new DataGridItem
                {
                    Id=2,
                    Name="Alice",
                    Age=25,
                    Remark=true,
                }
            };
        }
        public List<DataGridItem> DataCollection { get; set; }
    }
}
