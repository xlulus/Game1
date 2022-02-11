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

namespace Game1
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;


        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;

            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timer_textbox.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

            if(matchesFound == 8)
            {
                timer.Stop();
            }
        }

        private void SetUpGame()
        {
            List<string> Emoji = new List<string>()
            {

                "❤", "❤",
                "✨", "✨",
                "🎁", "🎁",
                "🍕", "🍕",
                "🎃", "🎃",
                "👻", "👻",
                "🚗", "🚗",
                "⚽", "⚽",
            };

            Random random = new Random();

            foreach(TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(Emoji.Count);
                string nextEmoji = Emoji[index];
                textBlock.Text = nextEmoji;
                Emoji.RemoveAt(index);
            }
        }


        TextBlock lastClicked;
        bool finding = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                timer.Start();
            }

            TextBlock textBlock = sender as TextBlock;
            if(finding == false)
            {
                lastClicked = textBlock;
                textBlock.Foreground = Brushes.Red;
                finding = true;
            }
            else
            {
                if(lastClicked != textBlock)
                {
                    if (lastClicked.Text == textBlock.Text)
                    {
                        matchesFound++;
                        finding = false;

                        lastClicked.Visibility = Visibility.Hidden;
                        textBlock.Visibility = Visibility.Hidden;


                    }
                    else
                    {
                        lastClicked.Foreground = Brushes.Black;

                        finding = false;
                    }
                }
            }
        }
    }
}
