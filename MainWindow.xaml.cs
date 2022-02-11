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

namespace Game1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }

        int points = 0;

        private void SetUpGame()
        {
            score.Text = points.ToString();

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
                        points++;
                        score.Text = points.ToString();
                        finding = false;

                        lastClicked.Visibility = Visibility.Hidden;
                        textBlock.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        lastClicked.Foreground = Brushes.Black;

                        points--;
                        score.Text = points.ToString();
                        finding = false;
                    }
                }
            }
        }
    }
}
