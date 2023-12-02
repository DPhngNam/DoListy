using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace DoListy.ViewModel
{
    [Table("Goal")]
    public class Goal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Notes { get; set; }

    }
}
