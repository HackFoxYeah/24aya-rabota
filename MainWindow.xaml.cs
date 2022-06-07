using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _24ayaRabota
{
    /// <summary>
    ///     Игра, в которой нужно передвигаться с помощью стрелочек, 
    ///     обходить препятствия. Концом её будет попадание метеорита на планету.
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DispatcherTimer timer;

        double runSpeed = 5;

        int level;

        Rect meteorCoordinates,
             planetCoordinates;        

        Ellipse meteor = new Ellipse()
        {
            Height = 29,
            Width = 29,
            Fill = Brushes.Red
        };

        Rectangle planet = new Rectangle()
        {
            Height = 110,
            Width = 815            
        };

        Rectangle rectangle1 = new Rectangle()
        {            
            Fill = Brushes.Red
        };

        Rectangle rectangle2 = new Rectangle()
        {            
            Fill = Brushes.Red
        };

        Rectangle rectangle3 = new Rectangle()
        {            
            Fill = Brushes.Red
        };

        Rectangle rectangle4 = new Rectangle()
        {
            Fill = Brushes.Red
        };       

        private void Window_Initialized(object sender, EventArgs e)
        {
            LevelTB.Focus();

            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10)
            };

            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (meteorCoordinates.IntersectsWith(planetCoordinates) && LevelTB.IsEnabled == false)
            {                
                MessageBox.Show("Victory"); 
                Close();
            }
        }

        private void StartGame()
        {       
            level = Convert.ToInt32(LevelTB.Text);

            LevelTB.IsEnabled = false;

            canvas1.Children.Remove(meteor);
            canvas1.Children.Remove(planet);
            
            meteorCoordinates = new Rect(400, 20, meteor.Width, meteor.Width);
            planetCoordinates = new Rect(-5, 510, planet.Width, planet.Width);

            Canvas.SetLeft(meteor, meteorCoordinates.X);
            Canvas.SetTop(meteor, meteorCoordinates.Y);

            Canvas.SetLeft(planet, planetCoordinates.X);
            Canvas.SetTop(planet, planetCoordinates.Y);

            canvas1.Children.Add(meteor);
            canvas1.Children.Add(planet);

            switch (level)
            {
                case 1: //первый уровень
                    rectangle1.Height = 28;
                    rectangle1.Width = 233;

                    rectangle2.Height = 28;
                    rectangle2.Width = 466;

                    Canvas.SetLeft(rectangle1, 0);
                    Canvas.SetTop(rectangle1, 270);

                    Canvas.SetLeft(rectangle2, 331);
                    Canvas.SetTop(rectangle2, 270);

                    canvas1.Children.Add(rectangle1);
                    canvas1.Children.Add(rectangle2);
                    break;

                case 2: //второй уровень
                    rectangle1.Height = 28;
                    rectangle1.Width = 233;

                    rectangle2.Height = 28;
                    rectangle2.Width = 466;

                    rectangle3.Height = 28;
                    rectangle3.Width = 233;

                    rectangle4.Height = 28;
                    rectangle4.Width = 466;

                    Canvas.SetLeft(rectangle1, 0);
                    Canvas.SetTop(rectangle1, 270);

                    Canvas.SetLeft(rectangle2, 331);
                    Canvas.SetTop(rectangle2, 270);

                    Canvas.SetLeft(rectangle3, 0);
                    Canvas.SetTop(rectangle3, 270);

                    Canvas.SetLeft(rectangle4, 331);
                    Canvas.SetTop(rectangle4, 270);

                    canvas1.Children.Add(rectangle1);
                    canvas1.Children.Add(rectangle2);
                    canvas1.Children.Add(rectangle3);
                    canvas1.Children.Add(rectangle4);
                    break;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) //движение влево
            {
                meteorCoordinates.X -= runSpeed;
                Canvas.SetLeft(meteor, meteorCoordinates.X);
            }

            if (e.Key == Key.Right) //движение вправо 
            {
                meteorCoordinates.X += runSpeed;
                Canvas.SetLeft(meteor, meteorCoordinates.X);
            }

            if (e.Key == Key.Up) //движение вверх
            {
                meteorCoordinates.Y -= runSpeed;
                Canvas.SetTop(meteor, meteorCoordinates.Y);
            }

            if (e.Key == Key.Down) //движение вниз
            {
                meteorCoordinates.Y += runSpeed;
                Canvas.SetTop(meteor, meteorCoordinates.Y);
            }

            if (e.Key == Key.Left && e.Key == Key.Up) //движение влево-вверх
            {
                meteorCoordinates.Y -= runSpeed;
                meteorCoordinates.X -= runSpeed;
                Canvas.SetTop(meteor, meteorCoordinates.Y);
            }

            if (e.Key == Key.Right && e.Key == Key.Up) //движение вправо-вверх
            {
                meteorCoordinates.Y -= runSpeed;
                meteorCoordinates.X -= runSpeed;
                Canvas.SetTop(meteor, meteorCoordinates.Y);
            }

            if (e.Key == Key.Right && e.Key == Key.Down) //движение вправо-вниз
            {
                meteorCoordinates.Y += runSpeed;
                meteorCoordinates.Y += runSpeed;
                Canvas.SetTop(meteor, meteorCoordinates.Y);
            }

            if (e.Key == Key.Left && e.Key == Key.Down) //движение влево-вниз
            {
                meteorCoordinates.Y += runSpeed;
                meteorCoordinates.X -= runSpeed;
                Canvas.SetTop(meteor, meteorCoordinates.Y);
            }
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void AboutBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Работа №24. Сделано Капустиным Максимом, учеником ИСП-21");
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
