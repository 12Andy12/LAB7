using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB7.Models;

namespace LAB7.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public double middleMath = 0;
        public double middleVisualPrograming = 0;
        public double middleOOP = 0;
        public double middlePhysicalCulture = 0;
        public double middleMiddleMark = 0;

        public ObservableCollection<Student> Items { get; set; }
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Student>(BuildAllStudents());
            BuildActualMarks();
        }

        public void BuildActualMarks()
        {
            for(int i=0;i<Items.Count;i++)
            {
                middleMath += Items[i].visualMath;
                middleVisualPrograming += Items[i].visualPrograming;
                middleOOP += Items[i].visualOOP;
                middlePhysicalCulture += Items[i].visualPhysicalCulture;
                Items[i].visualMiddleMark = 0;
                Items[i].visualMiddleMark += Items[i].visualMath;
                Items[i].visualMiddleMark += Items[i].visualPrograming;
                Items[i].visualMiddleMark += Items[i].visualOOP;
                Items[i].visualMiddleMark += Items[i].visualPhysicalCulture;
                Items[i].visualMiddleMark /= 4;
                middleMiddleMark += Items[i].visualMiddleMark;
 
            }
            middleMath /= Items.Count;
            middleVisualPrograming /= Items.Count;
            middleOOP /= Items.Count;
            middlePhysicalCulture /= Items.Count;
            middleMiddleMark /= Items.Count;
        }

        public double MiddleMath
        {
            get => middleMath; 
        }
        public double MiddleVisualPrograming
        {
            get => middleVisualPrograming;
        }
        public double MiddleOOP
        {
            get => middleOOP;
        }
        public double MiddlePhysicalCulture
        {
            get => middlePhysicalCulture;
        }
        public double MiddleMiddleMark
        {
            get => middleMiddleMark;
        }
        private Student[] BuildAllStudents()
        {
            return new Student[]
            {
                new Student("Alabama", 1, 1,3,2,2),
                new Student("Alaska", 1, 1,3,2,2),
                new Student("Arizona", 1, 1,3,2,2),
                new Student("Arkansas", 1, 1,3,2,2),
                new Student("California", 1, 1,3,2,2),
                new Student("Colorado", 1, 1,3,2,2),
                new Student("Connecticut", 1, 1,3,2,2),
                new Student("Delaware", 1, 1,3,2,2),
                new Student("Florida", 1, 1,3,2,2),
                new Student("Georgia", 1, 1,3,2,2),
                new Student("Hawaii", 1, 1,3,2,2),
                new Student("Idaho", 1, 1,3,2,2),
                new Student("Illinois", 1, 1,3,2,2),
            };
        }
    }
}
