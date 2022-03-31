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

            this.FindControl<DataGrid>("MyDataGrid").CellEditEnded += delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                context.BuildActualMarks();
            };
        }
		//private void CellEdited(object sender, DataGridCellEditEndingEventArgs e)
		//{
		//	var context = this.DataContext as MainWindowViewModel;
		//	context.BuildActualMarks();
		//}
	}
}
