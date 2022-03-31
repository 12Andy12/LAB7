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
        Middle middle =new Middle();

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
                middle.math += Items[i].visualMath;
                middle.visualPrograming += Items[i].visualPrograming;
                middle.oop += Items[i].visualOOP;
                middle.physicalCulture += Items[i].visualPhysicalCulture;
                Items[i].visualMiddleMark = 0;
                Items[i].visualMiddleMark += Items[i].visualMath;
                Items[i].visualMiddleMark += Items[i].visualPrograming;
                Items[i].visualMiddleMark += Items[i].visualOOP;
                Items[i].visualMiddleMark += Items[i].visualPhysicalCulture;
                Items[i].visualMiddleMark /= 4;
                middle.middleMark += Items[i].visualMiddleMark;
 
            }
            middle.math /= Items.Count;
            middle.visualPrograming /= Items.Count;
            middle.oop /= Items.Count;
            middle.physicalCulture /= Items.Count;
            middle.middleMark /= Items.Count;
        }

        public double MiddleMath
        {
            get => middle.math; 
            set
            {
                middle.math = value;
            }
        }
        public double MiddleVisualPrograming
        {
            get => middle.visualPrograming;
            set => middle.visualPrograming = value; 
        }
        public double MiddleOOP
        {
            get => middle.oop;
            set => middle.oop = value;
        }
        public double MiddlePhysicalCulture
        {
            get => middle.physicalCulture;
            set => middle.physicalCulture = value;
        }
        public double MiddleMiddleMark
        {
            get => middle.middleMark;
            set => middle.middleMark = value;
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
