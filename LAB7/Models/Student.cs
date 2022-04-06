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
        double VisualMiddleMark; // Я в курсе что должно быть наоборот, в следующий раз исправлюсь
        public double visualMiddleMark
        {
            get => VisualMiddleMark;
            set
            {
                VisualMiddleMark = value;
                NotifyPropertyChanged();
            }
        }

        public string ColorMiddleMark = "Red";
        public string colorMiddleMark
        {
            get => ColorMiddleMark;
            set
            {
                ColorMiddleMark = value;
                NotifyPropertyChanged();
            }
        }

        public int VisualMath;
        public int visualMath 
        {
            get => VisualMath;
            set
            {
                VisualMath = value;
                NotifyPropertyChanged();
            }
        }
        public int VisualPrograming;
        public int visualPrograming
        {
            get => VisualPrograming;
            set
            {
                VisualPrograming = value;
                NotifyPropertyChanged();
            }
        }
        public int VisualOOP;
        public int visualOOP
        {
            get => VisualOOP;
            set
            {
                VisualOOP = value;
                NotifyPropertyChanged();
            }
        }
        public int VisualPhysicalCulture;
        public int visualPhysicalCulture
        {
            get => VisualPhysicalCulture;
            set
            {
                VisualPhysicalCulture = value;
                NotifyPropertyChanged();
            }
        }
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

        public bool IsSelected { get; set; }
    }
}
