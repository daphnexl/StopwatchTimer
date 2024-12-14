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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StopwatchTimer
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;  
        private TimeSpan _timeElapsed;
        public MainWindow()
        {
            InitializeComponent();
            InitializeStopwatch();
        }
        private void InitializeStopwatch()
        {
            _timeElapsed = TimeSpan.Zero;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(10) 
            };
            _timer.Tick += Timer_Tick;  
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            _timeElapsed = _timeElapsed.Add(TimeSpan.FromMilliseconds(10)); 
            TimerDisplay.Text = _timeElapsed.ToString(@"hh\:mm\:ss\.ff");  
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
            StartButton.IsEnabled = false;  
            StopButton.IsEnabled = true;    
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            StartButton.IsEnabled = true;  
            StopButton.IsEnabled = false;  
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();     
            _timeElapsed = TimeSpan.Zero;   
            TimerDisplay.Text = "00:00:00.00"; 
            StartButton.IsEnabled = true;  
            StopButton.IsEnabled = false;  
        }
    }
}
