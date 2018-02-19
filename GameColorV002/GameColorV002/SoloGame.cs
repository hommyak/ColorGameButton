using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameColorV002
{
    class SoloGame
    {
        // Start Menu
        private StartMenu ST;
        // Change Context
        private ChangeContext CHCont = new ChangeContext();
        // Grid Class
        private GridClass GrC;

        // основной Grids (3,1)
        private Grids _grid;
        // верхний Grids (1,2)
        private Grids _topGridL;
        private Grids _topGridR;
        // центральный Grids (3,4)
        private Grids _midGridL;
        private Grids _midGridR;
        // нижний Grids (1,3)
        private Grids _botGrid;
        

        // HashSet Button Size
        private HashSet<Button> btnS;
        // HashSet Button Color
        private HashSet<Button> btnC;
        // HashSet Button
        private HashSet<Button> btn = new HashSet<Button>();
        // сдвижка по х и по у
        private int moveByX, moveByY = 0;

        // отдаваемый размер
        private int _size;
        // отдаваемый цвет (кол-во цветов)
        private int _color;



        // метод для запуска СГ
        public Grid StartingSG()
        {
            _grid = new Grids(3,0);
            _topGridL = new Grids(3, 1);
            _topGridR = new Grids(3, 1);
            _midGridL = new Grids(1, 1);
            _midGridR = new Grids(1, 1);
            _botGrid = new Grids(3, 1);

           // создание таблицы
            _grid._griding.Children.Add(_topGridL._griding, 0, 0);
            _grid._griding.Children.Add(_topGridR._griding, 1, 0);
            _grid._griding.Children.Add(_midGridL._griding, 0, 1);
            _grid._griding.Children.Add(_midGridR._griding, 1, 1);
            _grid._griding.Children.Add(_botGrid._griding, 1, 2);

            // вызов метода для создания кнопок
            But();

            //заполнение таблицы кнопками
            #region верх
            double fontSizeLebel = 19.5;
            Label Left_text = new Label
            {
                Text = "Выберете размер поля",
                FontSize = fontSizeLebel,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
                
            };

            Label Right_text = new Label
            {
                Text = "Выберете количество цветов",
                FontSize = fontSizeLebel,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            _topGridL._griding.Children.Add(Left_text,0,1);
            _topGridR._griding.Children.Add(Right_text,0,1);
            #endregion

            #region ценр
            moveByX = 0;
            int tmpMoveByX = moveByX;
            foreach (var x in btnS)
            {
                x.Clicked += ClickedButton;
                _midGridL._griding.Children.Add(x, moveByY, moveByX);
                SlipForGrid(tmpMoveByX);
            }
            
            moveByY = 0;
            foreach (var x in btnC)
            {
                x.Clicked += ClickedButton;
                _midGridR._griding.Children.Add(x, moveByY, moveByX);
                SlipForGrid(tmpMoveByX);
            }
#endregion

            #region Низ
            moveByX = 1;
            foreach (var x in btn)
            {
                x.Clicked += ClickedButton;
                _botGrid._griding.Children.Add(x, moveByX, 1);
                moveByX--;
            }
            #endregion
            
            return _grid._griding;
        }

        // метод кнопок 
        public void But()
        {
            int fontSizeBut = 16;
            #region BS
            Button bs3 = new Button()
            {
                Text = "3*3",
                FontSize = fontSizeBut,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Button bs4 = new Button()
            {
                Text = "4*4",
                FontSize = fontSizeBut,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Button bs5 = new Button()
            {
                Text = "5*5",
                FontSize = fontSizeBut,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Button bs6 = new Button()
            {
                Text = "6*6",
                FontSize = fontSizeBut,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Button bs7 = new Button()
            {
                Text = "7*7",
                FontSize = fontSizeBut,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Button bs8 = new Button()
            {
                Text = "8*8",
                FontSize = fontSizeBut,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            #endregion
            btnS = new HashSet<Button>() { bs3, bs4, bs5, bs6, bs7, bs8 };

            #region BC
            Button bc3 = new Button()
            {
                Text = "3",
                FontSize = fontSizeBut,
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.Center
            };
            Button bc4 = new Button()
            {
                Text = "4",
                FontSize = fontSizeBut,
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.Center
            };
            Button bc5 = new Button()
            {
                Text = "5",
                FontSize = fontSizeBut,
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.Center
            };
            Button bc6 = new Button()
            {
                Text = "6",
                FontSize = fontSizeBut,
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.Center
            };
            Button bc7 = new Button()
            {
                Text = "7",
                FontSize = fontSizeBut,
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.Center
            };
            Button bc8 = new Button()
            {
                Text = "8",
                FontSize = fontSizeBut,
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.Center
            };
            #endregion
            btnC = new HashSet<Button>() { bc3, bc4, bc5, bc6, bc7, bc8 };

            #region BTNmenu
            Button Back = new Button()
            {
                Text = "Назад",
                FontSize = fontSizeBut
            };

            Button Start = new Button()
            {
                Text = "Начать",
                FontSize = fontSizeBut
            };
            #endregion
            btn = new HashSet<Button>() { Start, Back };
            
        }

        // метод сдвига 
        private void SlipForGrid(int tmpMoveByX)
        {
            if (moveByX >= tmpMoveByX + 2) { moveByY++; moveByX = tmpMoveByX; } else moveByX++;
        }

        // мтод клик 
        private void ClickedButton(Object sender, System.EventArgs e)
        {
            PlanePage PlP = new PlanePage();
            Button tmp = (Button)sender;

            // кнопки управления
            if (tmp.Text.Equals("Начать"))
            {
                if ((_color == 0) || (_size == 0)) { }
                else
                {
                    GrC = new GridClass();
                    PlP.Content = CHCont.changingContextOview(GrC.StartingGRC(_size, _color, false, ""));
                    StaticProperty.curControllClass.MainPage = PlP;
                }
            }
            else if (tmp.Text.Equals("Назад"))
            {
                ST = new StartMenu();
                PlP.Content = CHCont.changingContextOview(ST.StartingMenu());
                StaticProperty.curControllClass.MainPage = PlP;
            }

            // выбор размера или кол-ва цветов и убирание остальных
            if ((tmp.Text.Length > 2) && (tmp.Text.Length < 4)) { CheckedButtonChoos((Button)sender, true); }
            if ((tmp.Text.Length < 2)) { CheckedButtonChoos((Button)sender, false); }
        }

        //метод для выбора размера и цвета
        private void CheckedButtonChoos(Button tmpClick, bool s_c)
        {
            if (s_c == true)
            {
                foreach (var x in btnS)
                {
                    if (x.IsVisible == true)
                    {
                        if (x.Text.Equals(tmpClick.Text)) { _size = Convert.ToInt32(x.Text.Split('*')[0]); continue; }
                        x.IsVisible = false;
                    }
                    else { x.IsVisible = true; _size = 0; }
                }
            }
            else
            {
                foreach (var x in btnC)
                {
                    if (x.IsVisible == true)
                    {
                        if (x.Text.Equals(tmpClick.Text)) { _color = Convert.ToInt32(x.Text); continue; }
                        x.IsVisible = false;
                    }
                    else { x.IsVisible = true; _color = 0; }
                }
            }
        }

    }
}
