using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity.Attributes;
using WPF.DependencyInjection.ViewModels;

namespace WPF.DependencyInjection.Views
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : Page
    {
        [Dependency]
        public CustomersViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public CustomersView()
        {
            InitializeComponent();
        }
    }
}
