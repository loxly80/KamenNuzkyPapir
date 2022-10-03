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

namespace KamenNuzkyPapir
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game(10);
            game.FightFinished += Game_FightFinished;
            game.Start();
        }

        private void Game_FightFinished()
        {
            txtBox.Text += $"Player1 {game.Player1.Money} - Player2 {game.Player2.Money}\n";
        }
    }
}
