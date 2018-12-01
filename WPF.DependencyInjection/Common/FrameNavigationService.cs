using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF.DependencyInjection.Common
{
    public class FrameNavigationService : IFrameNavigationService
    {
        public object Parameter { get; private set; }       

        public void GoBack()
        {
            Frame frame = GetFrame();

            frame.GoBack();
        }

        public void GoForward()
        {
            Frame frame = GetFrame();

            frame.GoForward();
        }

        public void Navigate(string page, object parameter = null)
        {
            Frame frame = GetFrame();

            var uri = new Uri($"../Views/{page}View.xaml", UriKind.Relative);

            this.Parameter = parameter;

            frame.Navigate(uri, parameter);
        }

        private static Frame GetFrame()
        {
            // return GetDescendantFromName(Application.Current.MainWindow, "MainFrame") as Frame;

            return RecurseChildren<Frame>(Application.Current.MainWindow).FirstOrDefault(f=>f.Name== "MainFrame");
        }

        // base on https://csharperimage.jeremylikness.com/2011/02/parsing-visual-tree-with-linq.html
        private static IEnumerable<T> RecurseChildren<T>(DependencyObject root) where T : UIElement
        {
            if (root is T)
            {
                yield return root as T;
            }

            if (root != null)
            {
                var count = VisualTreeHelper.GetChildrenCount(root);

                for (var idx = 0; idx < count; idx++)
                {
                    foreach (var child in RecurseChildren<T>(VisualTreeHelper.GetChild(root, idx)))
                    {
                        yield return child;
                    }
                }
            }
        }


      
    }
}
