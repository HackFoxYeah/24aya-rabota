using System;
using System.Collections.Generic;
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
             planetCoordinates;

        List<Rect> rects = new List<Rect>
        {
            new Rect(),
            new Rect(),
            new Rect(),
            new Rect(),
            new Rect()
        };

        Ellipse meteor = new Ellipse()
        {
            Height = 29,
            Width = 29,
            Fill = Brushes.Red
        };

        List<Rectangle> rectangles = new List<Rectangle>
        {
            new Rectangle { Fill = Brushes.Brown },
            new Rectangle { Fill = Brushes.Brown },
            new Rectangle { Fill = Brushes.Brown },
            new Rectangle { Fill = Brushes.Brown },
            new Rectangle { Fill = Brushes.Brown }
        };

        Rectangle planet = new Rectangle()
        {
            Height = 110,
            Width = 815
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
                if (meteorCoordinates.IntersectsWith(rects[0]) || meteorCoordinates.IntersectsWith(rects[1]) || meteorCoordinates.IntersectsWith(rects[2]) || meteorCoordinates.IntersectsWith(rects[3]) || meteorCoordinates.IntersectsWith(rects[4]))
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

            canvas1.Children.Remove(rectangles[0]);
            canvas1.Children.Remove(rectangles[1]);
            canvas1.Children.Remove(rectangles[2]);
            canvas1.Children.Remove(rectangles[3]);
            canvas1.Children.Remove(rectangles[4]);

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
                    rectangles[0].Height = 28;
                    rectangles[0].Width = 233;

                    rectangles[1].Height = 28;
                    rectangles[1].Width = 466;

                    Canvas.SetLeft(rectangles[0], 0);
                    Canvas.SetTop(rectangles[0], 270);

                    Canvas.SetLeft(rectangles[1], 331);
                    Canvas.SetTop(rectangles[1], 270);

                    rects[0] = new Rect(0, 270, rectangles[0].Width, rectangles[0].Height);

                    rects[1] = new Rect(331, 270, rectangles[1].Width, rectangles[1].Height);

                    canvas1.Children.Add(rectangles[0]);
                    canvas1.Children.Add(rectangles[1]);
                    break;

                case 2: //второй уровень
                    rectangles[0].Height = 20;
                    rectangles[0].Width = 425;

                    rectangles[1].Height = 20;
                    rectangles[1].Width = 440;

                    rectangles[2].Height = 20;
                    rectangles[2].Width = 415;

                    Canvas.SetLeft(rectangles[0], 0);
                    Canvas.SetTop(rectangles[0], 170);

                    Canvas.SetLeft(rectangles[1], 356);
                    Canvas.SetTop(rectangles[1], 313);

                    Canvas.SetLeft(rectangles[2], 0);
                    Canvas.SetTop(rectangles[2], 465);

                    rects[0] = new Rect(0, 170, rectangles[0].Width, rectangles[0].Height);

                    rects[1] = new Rect(359, 313, rectangles[1].Width, rectangles[1].Height);

                    rects[2] = new Rect(0, 465, rectangles[2].Width, rectangles[2].Height);

                    canvas1.Children.Add(rectangles[0]);
                    canvas1.Children.Add(rectangles[1]);
                    canvas1.Children.Add(rectangles[2]);
                    break;

                case 3: //третий уровень
                    rectangles[0].Height = 20;
                    rectangles[0].Width = 675;

                    rectangles[1].Height = 110;
                    rectangles[1].Width = 225;

                    rectangles[2].Height = 155;
                    rectangles[2].Width = 205;

                    rectangles[3].Height = 155;
                    rectangles[3].Width = 65;

                    rectangles[4].Height = 35;
                    rectangles[4].Width = 175;

                    Canvas.SetLeft(rectangles[0], 0);
                    Canvas.SetTop(rectangles[0], 213);

                    Canvas.SetLeft(rectangles[1], 250);
                    Canvas.SetTop(rectangles[1], 233);

                    Canvas.SetLeft(rectangles[2], 590);
                    Canvas.SetTop(rectangles[2], 345);

                    Canvas.SetLeft(rectangles[3], 250);
                    Canvas.SetTop(rectangles[3], 343);

                    Canvas.SetLeft(rectangles[4], 415);
                    Canvas.SetTop(rectangles[4], 465);

                    rects[0] = new Rect(0, 213, rectangles[0].Width, rectangles[0].Height);

                    rects[1] = new Rect(250, 235, rectangles[1].Width, rectangles[1].Height);

                    rects[2] = new Rect(590, 345, rectangles[2].Width, rectangles[2].Height);

                    rects[3] = new Rect(250, 345, rectangles[3].Width, rectangles[3].Height);

                    rects[4] = new Rect(415, 465, rectangles[4].Width, rectangles[4].Height);

                    canvas1.Children.Add(rectangles[0]);
                    canvas1.Children.Add(rectangles[1]);
                    canvas1.Children.Add(rectangles[2]);
                    canvas1.Children.Add(rectangles[3]);
                    canvas1.Children.Add(rectangles[4]);
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