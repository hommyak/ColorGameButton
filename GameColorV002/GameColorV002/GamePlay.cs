using Android;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XLabs.Forms.Controls;
using System.Threading;


namespace GameColorV002
{
   public class GamePlay
    {
        // ChangeContext
        ChangeContext CHCont = new ChangeContext();
        // Start Menu
        private StartMenu SM;
        // EmergeTask
        private EmergeTask ET;
        // Color_scheme
        private Color_scheme CS = new Color_scheme();
        // LvLs
        private LvLs Lvl = new LvLs();
        // Context
        private Context _context;
        // Task string
        private string _task;
        // PlanePage
        PlanePage PlP = new PlanePage();
        // StartMenuPage
        StartMenuPage ST = new StartMenuPage();

        // размер поля игры
        private int _sizematrix = 0;
        // кол-во цветов
        private int _countColor;
        // сдвижка 
        private int moveByX, moveByY = 0;
        // переменная словарь
        private Dictionary<Guid, AdvancedButton> _btnDictioary = new Dictionary<Guid, AdvancedButton>();
        // переменная ID
        private int _countId = 0;

        // The main space
        private AbsoluteLayout _mainPlace = new AbsoluteLayout();
        // Place for games
        private Grids _centerPlace;
        

        public AbsoluteLayout tester(int sizeMTR, int countColors, bool tasks, string newTask)
        {
            moveByX = 0;
            moveByY = 0;
            _countColor = countColors;
            _sizematrix = sizeMTR;
            _context = StaticProperty.iAppContext;  
            _centerPlace = new Grids(_sizematrix - 1, _sizematrix - 1);

            var set = getButtonMass();

            ImageButton mainmenu = new ImageButton() {
                ImageHeightRequest = 75,
                ImageWidthRequest = 75,
                BorderRadius = -5,
                Source = "@Drawable/menu1",
                BackgroundColor = Color.White
            };
            mainmenu.Clicked += ClickedButtonSM;
            
            // для обычной игры задания есть. А для Соло игры нету.
            if (tasks == true)
            {
                _task = newTask;
                Label lbLvl = new Label() { Text=" Level 1", FontFamily = "Arial", FontSize = 25, BackgroundColor = Color.FromHex("412C84"), TextColor = Color.FromHex("FFDE40"), VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start };
                Label lbtask = new Label() { FontFamily = "Arial", FontSize = 19, BackgroundColor = Color.FromHex("415C84"), TextColor = Color.FromHex("FFDE40"), VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };
                Button AdminButton = new Button() {
                    Text = "->",
                    FontSize = 13
                };

                AdminButton.Clicked += ClickedButtonAdm;
                lbtask.Text = _task;

                _mainPlace.Children.Add(lbtask, new Rectangle(0.965, 0.35, 0.4, 0.45), AbsoluteLayoutFlags.All);
                _mainPlace.Children.Add(lbLvl, new Rectangle(0.973, 0.05, 0.2, 0.1), AbsoluteLayoutFlags.All);
                //_mainPlace.Children.Add(AdminButton, new Rectangle(0.95, 0, 0.075, 0.125), AbsoluteLayoutFlags.All);
            }

            _mainPlace.Children.Add(_centerPlace._griding, new Rectangle(0.04, 0.1, 0.55, 0.95), AbsoluteLayoutFlags.All);
           // _mainPlace.Children.Add(mainmenu, new Rectangle(0, 4, 55, 45), AbsoluteLayoutFlags.None);



            foreach (var x in set)
            {
               _centerPlace._griding.Children.Add(x, moveByX, moveByY);
                SlipForGrid(sizeMTR-1);
            }

            //SwitchButt();
            return _mainPlace;
        }

        // метод создания Switch кнопок
        private void SwitchButt()
        {
            Switch colorLight1 = new Switch() { IsToggled = StaticProperty._isToggle1 };
            Switch colorLight2 = new Switch() { IsToggled = StaticProperty._isToggle2 };
            Switch colorLight3 = new Switch() { IsToggled = StaticProperty._isToggle3 };

            colorLight1.Toggled += Switcher_Toggled1;
            colorLight2.Toggled += Switcher_Toggled2;
            colorLight3.Toggled += Switcher_Toggled3;

            //_mainPlace.Children.Add(colorLight1, new Rectangle(0.005, 0.95, 0.065, 0.065), AbsoluteLayoutFlags.All);
            //_mainPlace.Children.Add(colorLight2, new Rectangle(0.005, 0.815, 0.065, 0.065), AbsoluteLayoutFlags.All);
            //_mainPlace.Children.Add(colorLight3, new Rectangle(0.005, 0.68, 0.065, 0.065), AbsoluteLayoutFlags.All);
        }


        // метод для сдвига
        private void SlipForGrid(int sizematrix)
        {
            if (moveByX >= sizematrix)
            { moveByY++; moveByX = 0; }
            else moveByX++;
        }

        // HashSet массив кнопок
        private HashSet<Button> getButtonMass()
        {
            HashSet<Button> btn = new HashSet<Button>();
            for (int o = 0; o < _sizematrix * _sizematrix; o++)
            {
                btn.Add(getRndButton());
            }
            StaticProperty.btnDictioary = _btnDictioary;
            StaticProperty.HashSetBtn = btn;
            return btn;
        }

        // генерация кнопки с параметрами (имя, размер, цвет кнопки, )
        private Button getRndButton()
        {
            Button button = new Button()
            {
                Image = "@Drawabel//button//button_red",
                BackgroundColor = Color.Red
            };

            
            button.Clicked += delegate (object sender, System.EventArgs e)
            {
                Button dalek = (Button)sender;
                AdvancedButton dalekInSuit = StaticProperty.btnDictioary[dalek.Id];
                CS.Start_Color_scheme(_sizematrix, _countColor, dalekInSuit);

                // проверка конца уровня
                if (StaticProperty.soloVSstartgame)
                {
                    if ((new EndLvls(StaticProperty.thisLevel)).CheckLvl_Dict())
                    {
                        //_centerPlace._griding.IsVisible = false;



                        ET = new EmergeTask();
                        ET.TESTSEmergeWin(_context);
                    }
                }
            };
            
            _btnDictioary.Add(button.Id, new AdvancedButton(button, button.Text, _countId));
            _countId++;

            return button;
        }

       

        // метод "нажатие кнопки"
        private void ClickedButton(Object sender, System.EventArgs e)
        {
            Button dalek = (Button)sender;
            AdvancedButton dalekInSuit = StaticProperty.btnDictioary[dalek.Id];
            CS.Start_Color_scheme(_sizematrix, _countColor, dalekInSuit);

            // проверка конца уровня
            if (StaticProperty.soloVSstartgame)
            {
                if ((new EndLvls(StaticProperty.thisLevel)).CheckLvl_Dict())
                {
                    //_centerPlace._griding.IsVisible = false;
                    


                    ET = new EmergeTask();
                    ET.TESTSEmergeWin(_context);
                }
            }
        }

        // метод для возврата к меню
        private void ClickedButtonSM(Object sender, System.EventArgs e)
        {
            SM = new StartMenu();
            StartMenuPage SMP = new StartMenuPage
            {
                Content = CHCont.changingContextOview(SM.StartingMenu())
            };
            StaticProperty.curControllClass.MainPage = SMP;
        }

        // метод Администратора для быстрого прохождения уровня
        private void ClickedButtonAdm(Object sender, System.EventArgs e)
        {
            ET = new EmergeTask();
            ET.TESTSEmergeWin(_context);
        }

        #region Просто страдал фигней
        // метод для изменения Toggle (Switch1)
        void Switcher_Toggled1(object sender, ToggledEventArgs e)
        {
            if (StaticProperty._isToggle1) { IsToggleValue(false, StaticProperty._isToggle2, StaticProperty._isToggle3); BackGroundColorSwch(); }
            else { IsToggleValue(true, StaticProperty._isToggle2, StaticProperty._isToggle3); BackGroundColorSwch(); }
        }
        // метод для изменения Toggle (Switch2)
        void Switcher_Toggled2(object sender, ToggledEventArgs e)
        {
            if (StaticProperty._isToggle2) { IsToggleValue(StaticProperty._isToggle1, false, StaticProperty._isToggle3); BackGroundColorSwch(); }
            else { IsToggleValue(StaticProperty._isToggle1, true, StaticProperty._isToggle3); BackGroundColorSwch(); }
        }
        // метод для изменения Toggle (Switch3)
        void Switcher_Toggled3(object sender, ToggledEventArgs e)
        { 
            if (StaticProperty._isToggle3) { IsToggleValue(StaticProperty._isToggle1, StaticProperty._isToggle2, false); BackGroundColorSwch(); }
            else { IsToggleValue(StaticProperty._isToggle1, StaticProperty._isToggle2, true); BackGroundColorSwch(); }
        }

        // метод для изменения цвета фона (Switch)
        private void BackGroundColorSwch()
        {
            if (StaticProperty._isToggle1 && StaticProperty._isToggle2 && StaticProperty._isToggle3)
            {

                StaticProperty._opColor = Color.White;
                StaticProperty.curControllClass.MainPage.BackgroundColor = Color.White;
            }
            else if (StaticProperty._isToggle1 && StaticProperty._isToggle2 && !StaticProperty._isToggle3)
            {
                StaticProperty._opColor = Color.Silver;
                StaticProperty.curControllClass.MainPage.BackgroundColor = Color.Silver;
            }
            else if (StaticProperty._isToggle1 && !StaticProperty._isToggle2 && StaticProperty._isToggle3)
            {
                StaticProperty._opColor = Color.Black;
                StaticProperty.curControllClass.MainPage.BackgroundColor = Color.Black;
            }
            else if (!StaticProperty._isToggle1 && StaticProperty._isToggle2 && StaticProperty._isToggle3)
            {
                StaticProperty._opColor = Color.Lime;
                StaticProperty.curControllClass.MainPage.BackgroundColor = Color.Lime;
            }
            else if (StaticProperty._isToggle1 && !StaticProperty._isToggle2 && !StaticProperty._isToggle3)
            {
                StaticProperty._opColor = Color.Navy;
                StaticProperty.curControllClass.MainPage.BackgroundColor = Color.Navy;
            }
            else if (!StaticProperty._isToggle1 && !StaticProperty._isToggle2 && StaticProperty._isToggle3)
            {
                StaticProperty._opColor = Color.Maroon;
                StaticProperty.curControllClass.MainPage.BackgroundColor = Color.Maroon;
            }
            else if (!StaticProperty._isToggle1 && StaticProperty._isToggle2 && !StaticProperty._isToggle3)
            {
                StaticProperty._opColor = Color.Olive;
                StaticProperty.curControllClass.MainPage.BackgroundColor = Color.Olive;
            }
            else if (!StaticProperty._isToggle1 && !StaticProperty._isToggle2 && !StaticProperty._isToggle3)
            {
                StaticProperty._opColor = Color.Teal;
                StaticProperty.curControllClass.MainPage.BackgroundColor = Color.Teal;
            }
        }

        // метод для изменение _isToggle
        private void IsToggleValue(bool tmp1, bool tmp2, bool tmp3)
        {
            StaticProperty._isToggle1 = tmp1;
            StaticProperty._isToggle2 = tmp2;
            StaticProperty._isToggle3 = tmp3;
        }

        #endregion
    }
}
