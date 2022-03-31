using ReactiveUI;
using System.Reactive;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB7.Models;
using System.IO;

namespace LAB7.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        Middle middle = new Middle();

        public ObservableCollection<Student> Items { get; set; }
        public List<Student> I { get; set; }
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Student>(BuildAllStudents());
            BuildActualMarks();
        }

        public void BuildActualMarks()
        {
            MiddleMath = 0;
            MiddleVisualPrograming = 0;
            MiddleOOP = 0;
            MiddlePhysicalCulture = 0;
            MiddleMiddleMark = 0;
            for (int i=0;i<Items.Count;i++)
            {
                MiddleMath += Items[i].visualMath;
                MiddleVisualPrograming += Items[i].visualPrograming;
                MiddleOOP += Items[i].visualOOP;
                MiddlePhysicalCulture += Items[i].visualPhysicalCulture;
                Items[i].visualMiddleMark = 0;
                Items[i].visualMiddleMark += Items[i].visualMath;
                Items[i].visualMiddleMark += Items[i].visualPrograming;
                Items[i].visualMiddleMark += Items[i].visualOOP;
                Items[i].visualMiddleMark += Items[i].visualPhysicalCulture;
                Items[i].visualMiddleMark /= 4;
                MiddleMiddleMark += Items[i].visualMiddleMark;
            }
            MiddleMath /= Items.Count;
            MiddleVisualPrograming /= Items.Count;
            MiddleOOP /= Items.Count;
            MiddlePhysicalCulture /= Items.Count;
            MiddleMiddleMark /= Items.Count;
        }

        public double MiddleMath
        {
            get => middle.math; 
            set
            {
                this.RaiseAndSetIfChanged(ref middle.math, value);
            }
        }
        public double MiddleVisualPrograming
        {
            get => middle.visualPrograming;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.visualPrograming, value);
            }
        }
        public double MiddleOOP
        {
            get => middle.oop;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.oop, value);
            }
        }
        public double MiddlePhysicalCulture
        {
            get => middle.physicalCulture;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.physicalCulture, value);
            }
        }
        public double MiddleMiddleMark
        {
            get => middle.middleMark;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.middleMark, value);
            }
        }

        public void SaveFile(string path)
        {
            ProcessingFile.WriteFile(path, Items);
        }

        public void OpenFile(string path)
        {
            I = ProcessingFile.ReadFile(path);
            for(int i = 0; i < Items.Count; i++)
                Items[i] = I[i];

            BuildActualMarks();
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
