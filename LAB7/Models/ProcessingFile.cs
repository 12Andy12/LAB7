using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace LAB7.Models
{
    internal class ProcessingFile
    {
        public static ObservableCollection<Student> ReadFile(string path)
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            Student newSrudent; 
            StreamReader file = new StreamReader(path);

            while (!file.EndOfStream)
            {
                newSrudent = new Student("none", 0, 0, 0, 0, 0);
                string ThisStudent = file.ReadLine();
                if (ThisStudent == "")
                    continue;
                string str = "";
                int flag = 0;
                for (int i = 0; i < ThisStudent.Length; i++)
                {
                    if(ThisStudent[i] != ';')
                        str+=ThisStudent[i];
                    else
                    {
                        switch (flag)
                        {
                            case 0:
                                newSrudent.visualName = str;
                                break;
                            case 1:
                                newSrudent.visualMath = Int32.Parse(str);
                                break;
                            case 2:
                                newSrudent.visualPrograming = Int32.Parse(str);
                                break;
                            case 3:
                                newSrudent.visualOOP = Int32.Parse(str);
                                break;
                            case 4:
                                newSrudent.visualPhysicalCulture = Int32.Parse(str);
                                break;
                            case 5:
                                newSrudent.visualMiddleMark = Convert.ToDouble(str);
                                break;
                            default:
                                break;
                        }
                        str = "";
                        flag++;
                    }
                }
                students.Add(newSrudent);
            }
            file.Close();
            /// WriteFile("C:\Users\Andrey\source\repos\Visual\LAB7", students);
            return students;
           
        }

        public static void WriteFile(string path, ObservableCollection<Student> content)
        {
            File.WriteAllText(path, "");

            List<string> data = new List<string>();
            string str="";
            for (int i = 0; i < content.Count; ++i)
            {
                str = content[i].visualName + ";" + content[i].visualMath.ToString() + ";" + content[i].visualPrograming.ToString() + ";" + content[i].visualOOP + ";" + content[i].visualPhysicalCulture.ToString() + ";" + content[i].visualMiddleMark.ToString() + ";";
                if(str != "")
                    data.Add(str);
            }
            File.WriteAllLines(path, data);
        }
    }
}
