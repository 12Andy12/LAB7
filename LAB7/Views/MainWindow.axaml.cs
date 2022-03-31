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

            //this.FindControl<DataGrid>("MyDataGrid").SelectionChanged += delegate
            //{
            //    var context = this.DataContext as MainWindowViewModel;
            //    context.BuildActualMarks();
            //};
            //this.FindControl<DataGrid>("MyDataGrid").BeginningEdit += delegate
            //{
            //    var context = this.DataContext as MainWindowViewModel;
            //    context.BuildActualMarks();
            //};
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
