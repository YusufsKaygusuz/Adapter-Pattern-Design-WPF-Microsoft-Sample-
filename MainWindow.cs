// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Windows;
using System.Windows.Controls;

namespace WidthProperties
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        interface IMain
        {
            object li { get; set; }
            object sz { get; set; }
        }



        public class ChangeWidth : IMain
        {
            private object _li;
            private object _sz;


            public ChangeWidth(object sender, SelectionChangedEventArgs args)
            {
                var li_ = ((sender as ListBox).SelectedItem as ListBoxItem);
                var sz1 = double.Parse(li_.Content.ToString());

                _li = li_;
                _sz = sz1;
            }

            public object li
            {
                get { return _li; }
                set { }
            }

            public object sz
            {
                get { return _sz; }
                set { }
            }

        }

        public class ChangeMinWidth : IMain
        {

            private object _li;
            private object _sz;


            public ChangeMinWidth(object sender, SelectionChangedEventArgs args)
            {
                var li_ = ((sender as ListBox).SelectedItem as ListBoxItem);
                var sz1 = double.Parse(li_.Content.ToString());

                _li = li_;
                _sz = sz1;
            }


            public object li
            {
                get { return _li; }
                set { }
            }

            public object sz
            {
                get { return _sz; }
                set { }
            }

        }

        public class ChangeMaxWidth
        {
            public object li_ { get; set; }
            public object sz_ { get; set; }

        }

        public class ChangeMaxWidthAdapter : IMain
        {

            private ChangeMaxWidth changeMaxWidth_;

            public ChangeMaxWidthAdapter(ChangeMaxWidth chng)
            {
                changeMaxWidth_ = chng;
            }


            public void ChangeMaxWidth(object sender, SelectionChangedEventArgs args)
            {
                var li = ((sender as ListBox).SelectedItem as ListBoxItem);
                var sz1 = double.Parse(li.Content.ToString());

                changeMaxWidth_.li_ = li;
                changeMaxWidth_.sz_ = sz1;

            }

            public object li
            {
                get { return changeMaxWidth_.li_; }
                set { }
            }

            public object sz
            {
                get { return changeMaxWidth_.sz_; }
                set { }
            }

        }

        public void changeWidth(object sender, SelectionChangedEventArgs args)
        {
            ChangeWidth chng = new ChangeWidth(sender, args);

            var li = chng.li;
            var sz1 = chng.sz;

            rect1.Width = (double)sz1;
            rect1.UpdateLayout();
            txt1.Text = "ActualWidth is set to " + rect1.ActualWidth;
            txt2.Text = "Width is set to " + rect1.Width;
            txt3.Text = "MinWidth is set to " + rect1.MinWidth;
            txt4.Text = "MaxWidth is set to " + rect1.MaxWidth;
        }

        private void changeMinWidth(object sender, SelectionChangedEventArgs args)
        {
            ChangeMinWidth chng = new ChangeMinWidth(sender, args);

            var li = chng.li;
            var sz1 = chng.sz;

            rect1.MinWidth = (double)sz1;
            rect1.UpdateLayout();
            txt1.Text = "ActualWidth is set to " + rect1.ActualWidth;
            txt2.Text = "Width is set to " + rect1.Width;
            txt3.Text = "MinWidth is set to " + rect1.MinWidth;
            txt4.Text = "MaxWidth is set to " + rect1.MaxWidth;
        }

        private void changeMaxWidth(object sender, SelectionChangedEventArgs args)
        {
            ChangeMaxWidth chng = new ChangeMaxWidth();

            var li = chng.li_;
            var sz1 = chng.sz_;

            rect1.MaxWidth = (double)sz1;
            rect1.UpdateLayout();
            txt1.Text = "ActualWidth is set to " + rect1.ActualWidth;
            txt2.Text = "Width is set to " + rect1.Width;
            txt3.Text = "MinWidth is set to " + rect1.MinWidth;
            txt4.Text = "MaxWidth is set to " + rect1.MaxWidth;

        }
        #region Old Codes
        /*
        private void changeMaxWidth(object sender, SelectionChangedEventArgs args)
        {

            var li = ((sender as ListBox).SelectedItem as ListBoxItem);
            var sz1 = double.Parse(li.Content.ToString());
            rect1.MaxWidth = sz1;
            rect1.UpdateLayout();
            txt1.Text = "ActualWidth is set to " + rect1.ActualWidth;
            txt2.Text = "Width is set to " + rect1.Width;
            txt3.Text = "MinWidth is set to " + rect1.MinWidth;
            txt4.Text = "MaxWidth is set to " + rect1.MaxWidth;

        }
        */

        /*
        private void ChangeWidth(object sender, SelectionChangedEventArgs args)
        {
            var li = ((sender as ListBox).SelectedItem as ListBoxItem);
            var sz1 = double.Parse(li.Content.ToString());
            rect1.Width = sz1;
            rect1.UpdateLayout();
            txt1.Text = "ActualWidth is set to " + rect1.ActualWidth;
            txt2.Text = "Width is set to " + rect1.Width;
            txt3.Text = "MinWidth is set to " + rect1.MinWidth;
            txt4.Text = "MaxWidth is set to " + rect1.MaxWidth;
        }

        private void ChangeMinWidth(object sender, SelectionChangedEventArgs args)
        {
            var li = ((sender as ListBox).SelectedItem as ListBoxItem);
            var sz1 = double.Parse(li.Content.ToString());
            rect1.MinWidth = sz1;
            rect1.UpdateLayout();
            txt1.Text = "ActualWidth is set to " + rect1.ActualWidth;
            txt2.Text = "Width is set to " + rect1.Width;
            txt3.Text = "MinWidth is set to " + rect1.MinWidth;
            txt4.Text = "MaxWidth is set to " + rect1.MaxWidth;
        }

        private void ChangeMaxWidth(object sender, SelectionChangedEventArgs args)
        {
            var li = ((sender as ListBox).SelectedItem as ListBoxItem);
            var sz1 = double.Parse(li.Content.ToString());
            rect1.MaxWidth = sz1;
            rect1.UpdateLayout();
            txt1.Text = "ActualWidth is set to " + rect1.ActualWidth;
            txt2.Text = "Width is set to " + rect1.Width;
            txt3.Text = "MinWidth is set to " + rect1.MinWidth;
            txt4.Text = "MaxWidth is set to " + rect1.MaxWidth;
      
        }*/
        #endregion
        private void ClipRect(object sender, RoutedEventArgs args)
        {
            myCanvas.ClipToBounds = true;
            txt5.Text = "Canvas.ClipToBounds is set to " + myCanvas.ClipToBounds;
        }

        private void UnclipRect(object sender, RoutedEventArgs args)
        {
            myCanvas.ClipToBounds = false;
            txt5.Text = "Canvas.ClipToBounds is set to " + myCanvas.ClipToBounds;
        }
    }
}