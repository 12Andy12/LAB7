using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using LAB7.Models;
using LAB7.ViewModels;

namespace LAB7.Views
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

            this.FindControl<MenuItem>("Open").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? filePath = await taskPath;

                if (filePath != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.OpenFile(string.Join(@"\", filePath));
                }
            };

            this.FindControl<MenuItem>("Save").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Search File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? filePath = await taskPath;

                if (filePath != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.SaveFile(string.Join(@"\", filePath));
                }
            };

            this.FindControl<MenuItem>("Exit").Click += delegate
            {
                Close();
            };

            this.FindControl<DataGrid>("MyDataGrid").CellEditEnded += delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                context.BuildActualMarks();
            };

            this.FindControl<Button>("AddBtn").Click += delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                Student newStudent = new Student("none", 0, 0, 0, 0, 0);
                context.Items.Add(newStudent);
                context.BuildActualMarks();
            };

            this.FindControl<Button>("DelBtn").Click += delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                for(int i=0;i < context.Items.Count; ++i)
                {
                    if(context.Items[i].IsSelected == true)
                    {
                        context.Items.RemoveAt(i);
                        --i;
                    }
                }
                context.BuildActualMarks();
            };
            this.FindControl<MenuItem>("About").Click += async delegate
            {
                await new About().ShowDialog((Window)this.VisualRoot);
            };
        }
	}
}
