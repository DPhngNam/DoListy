using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


    using System.ComponentModel;

    namespace DoListy.TaskManager
    {
        public class Task : INotifyPropertyChanged
        {
            private string _title;

            public int Id { get; set; }

            public string Title
            {
                get { return _title; }
                set
                {
                    if (_title != value)
                    {
                        _title = value;
                        OnPropertyChanged(nameof(Title));
                    }
                }
            }

            // Add other properties

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }



