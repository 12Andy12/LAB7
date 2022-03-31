using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LAB7.Models
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        double VisualMiddleMark;
        public double visualMiddleMark
        {
            get => VisualMiddleMark;
            set
            {
                VisualMiddleMark = value;
                NotifyPropertyChanged();
            }
        }

        public int visualMath { get; private set; }
        public int visualPrograming { get; private set; }
        public int visualOOP { get; private set; }
        public int visualPhysicalCulture { get; private set; }
        
        public string visualName { get; set; }

        public Student(string VisualName, int VisualMath, int VisualVisualPrograming, int VisualOOP, int VisualPhysicalCulture, double VisualMiddleMark)
        {
            visualMiddleMark = VisualMiddleMark;
            visualName = VisualName;
            visualMath = VisualMath;
            visualOOP = VisualOOP;
            visualPhysicalCulture = VisualPhysicalCulture;
            visualPrograming = VisualVisualPrograming;
        }

    }
}
