using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using OView = Xamarin.Forms.View;
using XLabs.Forms.Controls;

namespace GameColorV002
{
    // Контекст
    public static class StaticProperty
    {
        public static Context iAppContext
        {
            get; set;
        }

        public static Page mp
        {
            get; set;
        }

        public static App curControllClass
        {
            get; set;
        }

        public static string FullPath
        {
            get; set;
        }

        public static Dictionary<Guid, AdvancedButton> btnDictioary
        {
            get; set;
        }

        public static HashSet<Button> HashSetBtn
        {
            get; set;
        }

        public static HashSet<ImageButton> HashSetImBtn
        {
            get; set;
        }

        public static string ingo = "lvl=1=false;lvl=2=false;lvl=3=false;lvl=4=false;lvl=5=false;lvl=6=false;lvl=7=false;lvl=8=false;lvl=9=false;lvl=10=false;lvl=11=false;lvl=12=false;lvl=13=false;lvl=14=false;lvl=15=false;lvl=16=false;lvl=17=false;lvl=18=false;lvl=19=false;lvl=20=false;lvl=21=false;lvl=22=false;lvl=23=false;lvl=24=false;lvl=25=false;";

        public static int thisLvl
        {
            get; set;
        }
        
        public static Level thisLevel
        {
            get; set;
        }

        public static bool soloVSstartgame
        {
            get; set;
        }

        public enum CheckType
        {
            simpleEquals, more1Equals, more2Equals
        }

        public static Color _opColor = Color.White;

        public static bool _isToggle1 = true;
        public static bool _isToggle2 = true;
        public static bool _isToggle3 = true;

    }

    // класс "вида" уровня
    public class Level
    {
        public int size { get; set; }
        public int color { get; set; }
        public string text { get; set; }
        public Checking checks { get; set; }
        public StaticProperty.CheckType checksType { get; set; }

        public Level(int siz, int col, String inp, Checking ch, StaticProperty.CheckType cT)
        {
            size = siz; color = col;  text = inp; checks = ch; checksType = cT;
        }
    }

    // класс для для чека цветов на поле
    public class Checking
    {
        private int red;
        private int orange;
        private int yellow;
        private int green;
        private int aqua;
        private int blue;
        private int purple;
        private int black;

        // Конструктор
        public Checking(int Tred, int Torange, int Tyellow, int Tgreen, int Taqua, int Tblue, int Tpurple, int Tblack)
        {
            this.red = Tred;
            this.orange = Torange;
            this.yellow = Tyellow;
            this.green = Tgreen;
            this.aqua = Taqua;
            this.purple = Tpurple;
            this.black = Tblack;
        }

        public int Red
        {
            get { return red; }
            set { red = value; }
        }

        public int Orange
        {
            get { return orange; }
            set { orange = value; }
        }

        public int Yellow
        {
            get { return yellow; }
            set { yellow = value; }
        }

        public int Green
        {
            get { return green; }
            set { green = value; }
        }

        public int Aqua
        {
            get { return aqua; }
            set { aqua = value; }
        }

        public int Blue
        {
            get { return blue; }
            set { blue = value; }
        }

        public int Purple
        {
            get { return purple; }
            set { purple = value; }
        }

        public int Black
        {
            get { return black; }
            set { black = value; }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Перегрузка метода Equals
        public override bool Equals(object obj)
        {
            Checking t1 = (Checking)obj;
            return (t1.red == red && t1.orange == orange &&
                    t1.yellow == yellow && t1.green == green &&
                    t1.aqua == aqua && t1.blue == blue &&
                    t1.purple == purple && t1.black == black);
        }

        // Перегрузка метода Equals
        public  bool MoreEquals(object obj)
        {
            Checking current = (Checking)obj;
            const int eqOrMany = -1;

            return (((current.red == red) || (red == eqOrMany && current.red > 0)) &&
               ((current.orange == orange) || (orange == eqOrMany && current.orange > 0)) &&
               ((current.yellow == yellow) || (yellow == eqOrMany && current.yellow > 0)) &&
               ((current.green == green) || (green == eqOrMany && current.green > 0)) &&
               ((current.aqua == aqua) || (aqua == eqOrMany && current.aqua > 0)) &&
               ((current.blue == blue) || (blue == eqOrMany && current.blue > 0)) &&
               ((current.purple == purple) || (purple == eqOrMany && current.purple > 0)) &&
               ((current.black == black) || (black == eqOrMany && current.black > 0)));
        }

        // Перегрузка метода Equals
        public bool MoreEquals1(object obj)
        {
            Checking current = (Checking)obj;
            const int eqOrMany = -1;
            const int eqOrMany1 = -2;


            return (((current.red == red) || (red == eqOrMany && current.red > 0) || (red == eqOrMany1 && current.red >= 0)) &&
               ((current.orange == orange) || (orange == eqOrMany && current.orange > 0) || (orange == eqOrMany1 && current.orange >= 0)) &&
               ((current.yellow == yellow) || (yellow == eqOrMany && current.yellow > 0) || (yellow == eqOrMany1 && current.yellow >= 0)) &&
               ((current.green == green) || (green == eqOrMany && current.green > 0) || (green == eqOrMany1 && current.green >= 0)) &&
               ((current.aqua == aqua) || (aqua == eqOrMany && current.aqua > 0) || (aqua == eqOrMany1 && current.aqua >= 0)) &&
               ((current.blue == blue) || (blue == eqOrMany && current.blue > 0) || (blue == eqOrMany1 && current.blue >= 0)) &&
               ((current.purple == purple) || (purple == eqOrMany && current.purple > 0) || (purple == eqOrMany1 && current.purple >= 0)) &&
               ((current.black == black) || (black == eqOrMany && current.black > 0) || (black == eqOrMany1 && current.black >= 0)));
        }

        // Проверка уовня.
        public bool check(Checking goal, Checking current, StaticProperty.CheckType ch)
        {
            switch (ch)
            {
                case StaticProperty.CheckType.simpleEquals: { return goal.Equals(current); }
                case StaticProperty.CheckType.more1Equals: { return goal.MoreEquals(current); }
                case StaticProperty.CheckType.more2Equals: { return goal.MoreEquals1(current); }
            }
            return false;
        }

    }

    // Класс кнопка
    public class AdvancedButton
    {
        public AdvancedButton(Button but, string sname, int ids)
        {
            btn = but;
            name = sname;
            count = 0;
            id = ids;
        }
        public Button btn { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public int id { get; set; }
    }

    // Класс Grid
    public class Grids
    {
        public RowDefinitionCollection rw = new RowDefinitionCollection();
        public ColumnDefinitionCollection cw = new ColumnDefinitionCollection();
        public Grid _griding = new Grid();

        public Grids(int row, int col)
        {
            BuildGrid(row, col);
        }

        private void BuildGrid(int row, int col)
        {
            while (true)
            {
                if (rw.Count < row) { rw.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); }
                if (cw.Count < col) { cw.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); }
                if ((rw.Count == row) && (cw.Count == col)) { break; }
            }

            _griding.RowDefinitions = rw;
            _griding.ColumnDefinitions = cw;
            _griding.ColumnSpacing = -3;
            _griding.RowSpacing = -7;
        }
    }

    // Класс для получения view и Oview для Page
    public class ChangeContext
    {
        public OView changingContextOview(OView _view)
        {
            return _view;
        }

        public  View changingContextView(View _view)
        {
            return _view;
        }
    }
}