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

        double runSpeed = 5,
               gravity = 1;

        int level,
            score = 0;

        Rect meteorCoordinates,
             planetCoordinates,
             rect1, rect2, rect3,
             rect4, rect5;

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
            Fill = Brushes.Brown
        };

        Rectangle rectangle2 = new Rectangle()
        {
            Fill = Brushes.Brown
        };

        Rectangle rectangle3 = new Rectangle()
        {
            Fill = Brushes.Brown
        };

        Rectangle rectangle4 = new Rectangle()
        {
            Fill = Brushes.Brown
        };

        Rectangle rectangle5 = new Rectangle()
        {
            Fill = Brushes.Brown
        };

        private void Window_Initialized(object sender, EventArgs e)
        {
            LevelTB.Focus();

            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10)
            };

            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            meteorCoordinates.Y += gravity;
            Canvas.SetTop(meteor, meteorCoordinates.Y);

            if (meteorCoordinates.IntersectsWith(planetCoordinates) && LevelTB.IsEnabled == false)
            {
                score++;
                ScoreTB.Text = $"Счёт: {score}";

                LevelTB.IsEnabled = true;
                startBTN.IsEnabled = true;

                MessageBox.Show("Победа!");
                LevelTB.Focus();
                timer.Stop();
            }
            else
            {
                if (meteorCoordinates.IntersectsWith(rect1) || meteorCoordinates.IntersectsWith(rect2) || meteorCoordinates.IntersectsWith(rect3) || meteorCoordinates.IntersectsWith(rect4) || meteorCoordinates.IntersectsWith(rect5))
                {
                    meteor.Fill = Brushes.White;
                    score = 0;
                    ScoreTB.Text = $"Счёт: {score}";

                    LevelTB.IsEnabled = true;
                    startBTN.IsEnabled = true;

                    MessageBox.Show("Поражение");
                    LevelTB.Focus();
                    timer.Stop();
                }
            }
        }

        private void StartGame()
        {
            meteor.Fill = Brushes.Red;

            timer.Start();

            try
            {
                level = Convert.ToInt32(LevelTB.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный номер уровня! (1-3)");
                return;
            }

            LevelTB.IsEnabled = false;
            startBTN.IsEnabled = false;

            canvas1.Children.Remove(meteor);
            canvas1.Children.Remove(planet);
            canvas1.Children.Remove(rectangle1);
            canvas1.Children.Remove(rectangle2);
            canvas1.Children.Remove(rectangle3);
            canvas1.Children.Remove(rectangle4);
            canvas1.Children.Remove(rectangle5);

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

                    rect1 = new Rect(0, 270, rectangle1.Width, rectangle1.Height);

                    rect2 = new Rect(331, 270, rectangle2.Width, rectangle2.Height);

                    canvas1.Children.Add(rectangle1);
                    canvas1.Children.Add(rectangle2);
                    break;

                case 2: //второй уровень
                    rectangle1.Height = 20;
                    rectangle1.Width = 425;

                    rectangle2.Height = 20;
                    rectangle2.Width = 440;

                    rectangle3.Height = 20;
                    rectangle3.Width = 415;

                    Canvas.SetLeft(rectangle1, 0);
                    Canvas.SetTop(rectangle1, 170);

                    Canvas.SetLeft(rectangle2, 356);
                    Canvas.SetTop(rectangle2, 313);

                    Canvas.SetLeft(rectangle3, 0);
                    Canvas.SetTop(rectangle3, 465);

                    rect1 = new Rect(0, 170, rectangle1.Width, rectangle1.Height);

                    rect2 = new Rect(359, 313, rectangle2.Width, rectangle2.Height);

                    rect3 = new Rect(0, 465, rectangle3.Width, rectangle3.Height);

                    canvas1.Children.Add(rectangle1);
                    canvas1.Children.Add(rectangle2);
                    canvas1.Children.Add(rectangle3);
                    break;

                case 3: //третий уровень
                    rectangle1.Height = 20;
                    rectangle1.Width = 675;

                    rectangle2.Height = 110;
                    rectangle2.Width = 225;

                    rectangle3.Height = 155;
                    rectangle3.Width = 205;

                    rectangle4.Height = 155;
                    rectangle4.Width = 65;

                    rectangle5.Height = 35;
                    rectangle5.Width = 175;

                    Canvas.SetLeft(rectangle1, 0);
                    Canvas.SetTop(rectangle1, 213);

                    Canvas.SetLeft(rectangle2, 250);
                    Canvas.SetTop(rectangle2, 233);

                    Canvas.SetLeft(rectangle3, 590);
                    Canvas.SetTop(rectangle3, 345);

                    Canvas.SetLeft(rectangle4, 250);
                    Canvas.SetTop(rectangle4, 343);

                    Canvas.SetLeft(rectangle5, 415);
                    Canvas.SetTop(rectangle5, 465);

                    rect1 = new Rect(0, 213, rectangle1.Width, rectangle1.Height);

                    rect2 = new Rect(250, 235, rectangle2.Width, rectangle2.Height);

                    rect3 = new Rect(590, 345, rectangle3.Width, rectangle3.Height);

                    rect4 = new Rect(250, 345, rectangle4.Width, rectangle4.Height);

                    rect5 = new Rect(415, 465, rectangle5.Width, rectangle5.Height);

                    canvas1.Children.Add(rectangle1);
                    canvas1.Children.Add(rectangle2);
                    canvas1.Children.Add(rectangle3);
                    canvas1.Children.Add(rectangle4);
                    canvas1.Children.Add(rectangle5);
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

            if (e.Key == Key.Down) //движение вниз
            {
                meteorCoordinates.Y += runSpeed;
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
