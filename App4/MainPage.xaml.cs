using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;

            canvas.PointerCanceled += (s, a) =>
            {
                var t = a.Handled;
            };
            //canvas.PointerExited += (s, a) =>
            //{
            //    var t = a.Handled;
            ////};
            //canvas.pointer
        }

        Polyline fg;
        bool dibujar = false;
        double StrokeThickness = 5;
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            fg = new Polyline();
            fg.Stroke = new SolidColorBrush(Colors.Purple);
            fg.StrokeThickness = StrokeThickness;
        }

        private void canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Point pt = new Point();
            pt = e.GetCurrentPoint(canvas).Position;

            fg = new Polyline();
            fg.Stroke = new SolidColorBrush(Colors.Purple);
            fg.StrokeThickness = StrokeThickness;
            LayoutRoot.Children.Add(fg);
            dibujar = true;
        }

        private void canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (dibujar)
            {
                Point pt = new Point();
                pt = e.GetCurrentPoint(canvas).Position;
                fg.Points.Add(pt);
                
            }
        }

        private void canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dibujar = false;
        }
    }
}
