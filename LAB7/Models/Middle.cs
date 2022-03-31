using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LAB7.Models
{
    internal class Middle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public double math = 0;
        public double visualPrograming = 0;
        public double oop = 0;
        public double physicalCulture = 0;
        public double middleMark = 0;
        public double Math
        {
            get => math;
            set
            {
                math = value;
                NotifyPropertyChanged();
            }
        }
        public double VisualPrograming
        {
            get => visualPrograming;
            set
            {
                visualPrograming = value;
                NotifyPropertyChanged();
            }
        }
        public double Oop
        {
            get => oop;
            set
            {
                math = value;
                NotifyPropertyChanged();
            }
        }
        public double PhysicalCulture
        {
            get => physicalCulture;
            set
            {
                physicalCulture = value;
                NotifyPropertyChanged();
            }
        }
        public double MiddleMark
        {
            get => middleMark;
            set
            {
                middleMark = value;
                NotifyPropertyChanged();
            }
        }
        public Middle()
        {
             math = 0;
             visualPrograming = 0;
             oop = 0;
             physicalCulture = 0;
             middleMark = 0;
        }
    }
}
