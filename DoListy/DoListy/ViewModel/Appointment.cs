using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DoListy.ViewModel
{
    [Table("Appointment")]
    public class Appointment
    {
        public static int count = 0;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        [Unique]
        public string Name { get; set; }

        public string Colorbg {
            get
            {
                string temp="";
                switch (Colorbg)
                {
                    case "Red":
                       temp= "FF0000";
                       break;
                    case "Blue":
                        temp = "0000FF";
                        break;  
                    default:
                        temp = "0000FF";
                        break;  
                }

                return temp;
            }
             set {  }
            
    
        }   
        public string Recurrencerule { get; set; }
        public string Note { get; set;}
        public string State { get; set; }

     
    }
    
}
