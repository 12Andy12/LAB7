using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LAB7.Views
{
    public partial class About : Window
    {
        public About() 
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
