using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Common.WPF.Controls
{
    public class ClosableTab : TabItem
    {
        // Constructor
        public ClosableTab()
        {
            // Create an instance of the usercontrol
            var closableTabHeader = new CloseableHeader();
            // Assign the usercontrol to the tab header
            this.Header = closableTabHeader;
            
            closableTabHeader.CloseButton.MouseEnter +=
   new MouseEventHandler(button_close_MouseEnter);
            closableTabHeader.CloseButton.MouseLeave +=
               new MouseEventHandler(button_close_MouseLeave);
            closableTabHeader.CloseButton.Click +=
               new RoutedEventHandler(button_close_Click);
            closableTabHeader.CloseButton.SizeChanged +=
               new SizeChangedEventHandler(label_TabTitle_SizeChanged);
        }
       
        public string Title
        {
            set
            {
                ((CloseableHeader)this.Header).Header.Content = value;
            }
        }

        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);
            ((CloseableHeader)this.Header).CloseButton.Visibility = Visibility.Visible;
        }

        protected override void OnUnselected(RoutedEventArgs e)
        {
            base.OnUnselected(e);
            ((CloseableHeader)this.Header).CloseButton.Visibility = Visibility.Hidden;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ((CloseableHeader)this.Header).CloseButton.Visibility = Visibility.Visible;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.IsSelected)
            {
                ((CloseableHeader)this.Header).CloseButton.Visibility = Visibility.Hidden;
            }
        }

        // Button MouseEnter - When the mouse is over the button - change color to Red
        void button_close_MouseEnter(object sender, MouseEventArgs e)
        {
            ((CloseableHeader)this.Header).CloseButton.Foreground = Brushes.Red;
        }
        // Button MouseLeave - When mouse is no longer over button - change color back to black
        void button_close_MouseLeave(object sender, MouseEventArgs e)
        {
            ((CloseableHeader)this.Header).CloseButton.Foreground = Brushes.Black;
        }
        // Button Close Click - Remove the Tab - (or raise
        // an event indicating a "CloseTab" event has occurred)
        void button_close_Click(object sender, RoutedEventArgs e)
        {
            ((TabControl)this.Parent).Items.Remove(this);
        }
        // Label SizeChanged - When the Size of the Label changes
        // (due to setting the Title) set position of button properly
        void label_TabTitle_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ((CloseableHeader)this.Header).CloseButton.Margin = new Thickness(
               ((CloseableHeader)this.Header).CloseButton.ActualWidth + 5, 3, 4, 0);
        }
    }
}
