using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameColorV002
{
    public class StartMenu
    {
        private LvLs Lvls;
        private ChangeContext CHCont = new ChangeContext();
        private GridClass GrC;
        private Grids _grid;
        private SoloGame SG;
        private HashSet<Button> btn = new HashSet<Button>();

        
        public Grid StartingMenu()
        {
            
            int tmp = 1, tmp1 = 1;
            _grid = new Grids(9,3);
            But();
            foreach (var x in btn)
            {
                x.Clicked += ClickedButton;
                _grid._griding.Children.Add(x,tmp, tmp1);
                tmp1++;
            }
            return _grid._griding;
        }

        public void But()
        {
            Button startGame = new Button()
            {
                Text = "Начать игру",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
           
            Button startSolo = new Button()
            {
                Text = "Одиночная игра",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            
            Button options = new Button()
            {
                Text = "Настройки",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Center
            };
            // возможно закинуть в настройки
            Button reWrite = new Button()
            {
                Text = "Начать заново",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            Button exite = new Button()
            {
                Text = "Выход",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            Button Testi = new Button()
            {
                Text = "Тест",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                BackgroundColor = Color.Aqua,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            btn.Add(startGame);
            //btn.Add(startSolo);
            btn.Add(options);
            btn.Add(reWrite);
            btn.Add(exite);
            btn.Add(Testi);

        }

        private void ClickedButton(Object sender, System.EventArgs e)
        {
            var tests = new GamePlay();
            Lvls = new LvLs();
            PlanePage PlP = new PlanePage();
            SG = new SoloGame();
            GrC = new GridClass();
            Button b = (Button)sender;
            if ((b.Text).Equals("Начать игру")) {

                StaticProperty.soloVSstartgame = true;
                StaticProperty.thisLvl = Lvls.GetLvl();
                StaticProperty.thisLevel = new InfoLvls(StaticProperty.thisLvl).GetInfLvl_Dict;

                var tmp = CHCont.changingContextView(GrC.StartingGRC(Convert.ToInt32(StaticProperty.thisLevel.size), StaticProperty.thisLevel.color, true, StaticProperty.thisLevel.text));
                PlP.Content = tmp;
                StaticProperty.curControllClass.MainPage = PlP;
            }
            else if ((b.Text).Equals("Одиночная игра")) {
                StaticProperty.soloVSstartgame = false;
                PlP.Content = CHCont.changingContextOview(SG.StartingSG());
                StaticProperty.curControllClass.MainPage = PlP;
            }
            else if ((b.Text).Equals("Настройки")) {
                PlP.Content = (new Settings()).StartSettings();
                StaticProperty.curControllClass.MainPage = PlP;
            }

            else if ((b.Text).Equals("Начать заново")) { (new EmergeTask()).Сonfirmation(StaticProperty.iAppContext); }

            else if ((b.Text).Equals("Выход")) { Environment.Exit(0);  }

            else if ((b.Text).Equals("Тест")) {

                StaticProperty.soloVSstartgame = true;
                StaticProperty.thisLvl = Lvls.GetLvl();
                StaticProperty.thisLevel = new InfoLvls(StaticProperty.thisLvl).GetInfLvl_Dict;

                var tmp =  CHCont.changingContextView(tests.tester(Convert.ToInt32(StaticProperty.thisLevel.size), StaticProperty.thisLevel.color, true, StaticProperty.thisLevel.text));
                PlP.Content = tmp;
                StaticProperty.curControllClass.MainPage = PlP;


            }
        }
    }
}
