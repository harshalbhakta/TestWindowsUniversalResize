using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestResize
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.SizeChanged += pageSizeChanged;
        }

        private void pageSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height != e.PreviousSize.Height && e.NewSize.Width == e.PreviousSize.Width)
            {
                // Height changed. Width same.
                var view = ApplicationView.GetForCurrentView();
                var height = view.VisibleBounds.Height;
                var width = (double)height * ((double)16 / ((double)9));
                ApplicationView.GetForCurrentView().TryResizeView(new Size { Width = width, Height = height });
            }
            else
            {
                // Width changed, height same. Or both changed.
                var view = ApplicationView.GetForCurrentView();
                var width = view.VisibleBounds.Width;
                var height = (double)width / ((double)16 / ((double)9));
                ApplicationView.GetForCurrentView().TryResizeView(new Size { Width = width, Height = height });
            }
        }
    }
}
