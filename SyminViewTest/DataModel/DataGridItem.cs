using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            DataCollection = new ObservableCollection<DataGridItem>()
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
                },
                new DataGridItem
                {
                    Id=3,
                    Name="Bob",
                    Age=18,
                    Mark=true,
                    Gender =Gender.Male,
                },
            };
        }
        public ObservableCollection<DataGridItem> DataCollection { get; set; }
    }
}
