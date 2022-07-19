using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminViewTest.DataModel
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class DataGridItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public int Age { get; set; }
        public bool Mark { get; set; }
        public Gender Gender { get; set; }
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
                    Mark=true,
                    Gender=Gender.Other,
                },
                new DataGridItem
                {
                    Id=1,
                    Name="Mike",
                    Age=23,
                    Mark=false,
                    Gender=Gender.Male,
                },
                new DataGridItem
                {
                    Id=2,
                    Name="Alice",
                    Age=25,
                    Mark=true,
                    Gender =Gender.Female,
                }
            };
        }
        public List<DataGridItem> DataCollection { get; set; }
    }
}
