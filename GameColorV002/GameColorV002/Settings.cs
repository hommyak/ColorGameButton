using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GameColorV002
{
    class Settings
    {
        private Grids _grid;
        private HashSet<Button> btn = new HashSet<Button>();

        public Grid StartSettings()
        {

            int tmp = 0, tmp1 = 0;
            _grid = new Grids(0,0);
            But();
            foreach (var x in btn)
            {
                x.Clicked += ClickedButton;
                _grid._griding.Children.Add(x, tmp, tmp1);
                tmp1++;
            }
            return _grid._griding;
        }

        private void But()
        {
            Button whiteBackGround = new Button()
            {
                Text = "Белый",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            Button blackBackGround = new Button()
            {
                Text = "Черный",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            Button silverBackGround = new Button()
            {
                Text = "Серебрянный",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            Button Back = new Button()
            {
                Text = "Назад",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            btn.Add(whiteBackGround);
            btn.Add(blackBackGround);
            btn.Add(silverBackGround);
            btn.Add(Back);
        }

        private void ClickedButton(Object sender, System.EventArgs e)
        {
            ChangeContext CHCont = new ChangeContext();
            PlanePage PlP = new PlanePage();

            Button b = (Button)sender;
            if ((b.Text).Equals("Белый"))
            {
                StaticProperty._opColor = Color.White;
            }
            else if ((b.Text).Equals("Черный"))
            {
                StaticProperty._opColor = Color.Black;
            }
            else if ((b.Text).Equals("Серебрянный"))
            {
                StaticProperty._opColor = Color.Silver;
            }
            else if (b.Text.Equals("Назад"))
            {
                StartMenu ST = new StartMenu();
                PlP.Content = CHCont.changingContextOview(ST.StartingMenu());
                StaticProperty.curControllClass.MainPage = PlP;
            }
        }
    }
}
