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
        public ObservableCollection<Student> I { get; set; }
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
                if (Items[i].visualMath > 2)
                    Items[i].visualMath = 2;
                if (Items[i].visualPrograming > 2)
                    Items[i].visualPrograming = 2;
                if (Items[i].visualOOP > 2)
                    Items[i].visualOOP = 2;
                if (Items[i].visualPhysicalCulture > 2)
                    Items[i].visualPhysicalCulture = 2;
                if (Items[i].visualMath < 0)
                    Items[i].visualMath = 0;
                if (Items[i].visualPrograming < 0)
                    Items[i].visualPrograming = 0;
                if (Items[i].visualOOP < 0)
                    Items[i].visualOOP = 0;
                if (Items[i].visualPhysicalCulture < 0)
                    Items[i].visualPhysicalCulture = 0;
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
                if (Items[i].visualMiddleMark < 1)
                    Items[i].colorMiddleMark = "Red";
                else if (Items[i].visualMiddleMark < 1.5)
                    Items[i].colorMiddleMark = "Yellow";
                else
                    Items[i].colorMiddleMark = "Green";
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
                if (value < 1)
                    MiddleMathC = "red";
                else if (value < 1.5)
                    MiddleMathC = "yellow";
                else
                    MiddleMathC = "green";
                this.RaiseAndSetIfChanged(ref middle.math, value);
            }
        }
        public double MiddleVisualPrograming
        {
            get => middle.visualPrograming;
            set
            {
                if (value < 1)
                    MiddleVisualProgramingC = "red";
                else if (value < 1.5)
                    MiddleVisualProgramingC = "yellow";
                else
                    MiddleVisualProgramingC = "green";
                this.RaiseAndSetIfChanged(ref middle.visualPrograming, value);
            }
        }
        public double MiddleOOP
        {
            get => middle.oop;
            set
            {
                if (value < 1)
                    MiddleOOPC = "red";
                else if (value < 1.5)
                    MiddleOOPC = "yellow";
                else
                    MiddleOOPC = "green";
                this.RaiseAndSetIfChanged(ref middle.oop, value);
            }
        }
        public double MiddlePhysicalCulture
        {
            get => middle.physicalCulture;
            set
            {
                if (value < 1)
                    MiddlePhysicalCultureC = "red";
                else if (value < 1.5)
                    MiddlePhysicalCultureC = "yellow";
                else
                    MiddlePhysicalCultureC = "green";
                this.RaiseAndSetIfChanged(ref middle.physicalCulture, value);
            }
        }
        public double MiddleMiddleMark
        {
            get => middle.middleMark;
            set
            {
                if (value < 1)
                    MiddleMiddleMarkC = "red";
                else if (value <1.5)
                    MiddleMiddleMarkC = "yellow";
                else
                    MiddleMiddleMarkC = "green";
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
            for (int i = 0; i < Math.Max(I.Count, Items.Count); i++)
            {
                if (i < Items.Count && i < I.Count)
                    Items[i] = I[i];
                else if (i >= Items.Count)
                    Items.Add(I[i]);
                else if (i >= I.Count)
                {
                    Items.RemoveAt(i);
                    --i;
                }
            }
            BuildActualMarks();
        }

        public string MiddleMathC
        {
            get => middle.mathC;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.mathC, value);
            }
        }
        public string MiddleVisualProgramingC
        {
            get => middle.visualProgramingC;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.visualProgramingC, value);
            }
        }
        public string MiddleOOPC
        {
            get => middle.oopC;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.oopC, value);
            }
        }
        public string MiddlePhysicalCultureC
        {
            get => middle.physicalCultureC;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.physicalCultureC, value);
            }
        }
        public string MiddleMiddleMarkC
        {
            get => middle.middleMarkC;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.middleMarkC, value);
            }
        }
        private Student[] BuildAllStudents()
        {
            return new Student[]
            {
                new Student("Kostin Andrey", 1, 1,0,2,0)
            };
        }
    }
}
