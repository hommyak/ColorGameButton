using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameColorV002
{
    /* полная раскраска карты
        // relation = 0 - поменять цвет только у этой клетки
        // relation = 1 - поменять цвет у этой клетки и у соседей на 1
        // relation = 2 - поменять цвет у этой клетке на 1, а у соседей на 2
        // relation = 3 - поменять цвет у этой клетке на 2, а у соседей на 3
        // relation = 4 - поменять цвет у этой клетке на 2, а у соседей на 3
        // relation = 5 - поменять цвет у этой клетке на 1, а у соседей на 2
        // relation = 6 - поменять цвет у этой клетки и у соседей на 1
        // relation = 7 - поменять цвет только у этой клетки
        */
    class Color_scheme
    {
        // размер поля
        private int _sizematrix;
        // кол-во цветов
        private int _countColor;
        // нажатая кнопка
        private AdvancedButton _but;

        public void Start_Color_scheme(int sizeMatrix, int countColors, AdvancedButton but)
        {
            _sizematrix = sizeMatrix;
            _countColor = countColors;
            _but = but;
            Colorito();
        }
        
        // раскраска по зависимостям
        private void Colorito()
        {

            int relation = Relation();

            // relation = 0 - поменять цвет только у этой клетки
            if (relation == 0) {
                if (_but.btn != null)
                {
                    if (_but.btn.Image != null)
                    {
                        _but.btn.BackgroundColor = Color.Orange;
                        _but.btn.Image = new FileImageSource() { File = "@Drawable/button_orange.jpg" };
                    }
                }
            }

            // relation = 1 - поменять цвет у этой клетки на 1, а у соседей на 1
            else if (relation == 1)
            {
                _but.btn.Image = "@Drawable/button_yellow.jpg";
                _but.btn.BackgroundColor = Color.Yellow;
                // соседа на 1
                ColoritoNeighbors(1);
            }

            // relation = 2 - поменять цвет у этой клетке на 1, а у соседей на 2
            else if ((_countColor == 3) && (relation == 2))
            {
                _but.btn.Image = "@Drawable/button_red.jpg";
                _but.btn.BackgroundColor = Color.Red;
                // соседа на 2
                ColoritoNeighbors(2);
            }
            else if (!(_countColor == 3) && (relation == 2))
            {
                _but.btn.Image = "@Drawable/button_green.jpg";
                _but.btn.BackgroundColor = Color.Green;
                // соседа на 2
                ColoritoNeighbors(2);
            }

            // relation = 3 - поменять цвет у этой клетке на 2, а у соседей на 3
            else if ((_countColor == 4) && (relation == 3))
            {
                _but.btn.Image = "@Drawable/button_orange.jpg";
                _but.btn.BackgroundColor = Color.Orange;
                // соседа на 3
                ColoritoNeighbors(3);
            }
            else if ((_countColor == 5) && (relation == 3))
            {
                _but.btn.Image = "@Drawable/button_blue.jpg";
                _but.btn.BackgroundColor = Color.Aqua;
                // соседа на 3
                ColoritoNeighbors(3);
            }
            else if (!(_countColor == 5) && (relation == 3))
            {
                _but.btn.Image = "@Drawable/button_blue.jpg";
                _but.btn.BackgroundColor = Color.Aqua;
                // соседа на 3
                ColoritoNeighbors(3);
            }

            // relation = 4 - поменять цвет у этой клетке на 2, а у соседей на 3
            else if ((_countColor == 5) && (relation == 4))
            {
                _but.btn.Image = "@Drawable/button_orange.jpg";
                _but.btn.BackgroundColor = Color.Orange;
                // соседа на 3
                ColoritoNeighbors(3);
            }
            else if ((_countColor == 6) && (relation == 4))
            {
                _but.btn.Image = "@Drawabl/button_red.jpg";
                _but.btn.BackgroundColor = Color.Red;
                // соседа на 3
                ColoritoNeighbors(3);
            }
            else if (!(_countColor == 6) && (relation == 4))
            {
                _but.btn.Image = "@Drawable/button_purple.jpg";
                _but.btn.BackgroundColor = Color.Purple;
                // соседа на 3
                ColoritoNeighbors(3);
            }

            // relation = 5 - поменять цвет у этой клетке на 1, а у соседей на 2
            else if ((_countColor == 6) && (relation == 5))
            {
                _but.btn.Image = "@Drawable/button_red.jpg";
                _but.btn.BackgroundColor = Color.Red;
                // соседа на 2
                ColoritoNeighbors(2);
            }
            else if (!(_countColor == 6) && (relation == 5))
            {
                _but.btn.Image = "@Drawable/button_purple.jpg";
                _but.btn.BackgroundColor = Color.Purple;
                // соседа на 2
                ColoritoNeighbors(2);
            }

            // relation = 6 - поменять цвет у этой клетки и у соседей на 1
            else if ((_countColor == 7) && (relation == 6))
            {
                _but.btn.Image = "@Drawable/button_red.jpg";
                _but.btn.BackgroundColor = Color.Red;
                // соседа на 1
                ColoritoNeighbors(1);
            }
            else if (!(_countColor == 7) && (relation == 6))
            {
                _but.btn.Image = "@Drawable/Icon.jpg";
                _but.btn.BackgroundColor = Color.Black;
                // соседа на 1
                ColoritoNeighbors(1);
            }

            // relation = 7 - поменять цвет только у этой клетки
            else if (relation == 7)
            {
                _but.btn.Image = "@Drawable/button_red.jpg";
                _but.btn.BackgroundColor = Color.Red;
            }
        }

        // вычисление зависимости
        public int Relation()
        {
            if (_but.btn.BackgroundColor == Color.Red) { return 0; }
            else if (_but.btn.BackgroundColor == Color.Orange) { return 1; }
            else if (_but.btn.BackgroundColor == Color.Yellow) { return 2; }
            else if (_but.btn.BackgroundColor == Color.Green) { return 3; }
            else if (_but.btn.BackgroundColor == Color.Aqua) { return 4; }
            else if (_but.btn.BackgroundColor == Color.Blue) { return 5; }
            else if (_but.btn.BackgroundColor == Color.Purple) { return 6; }
            else if (_but.btn.BackgroundColor == Color.Black) { return 7; }

            return 0;
        }

        // раскраска соседей
        private void ColoritoNeighbors(int countColorNeighbor)
        {
            HashSet<int> butt;
            butt = Neighbors();
            
            for (int i = 0; i < countColorNeighbor; i++)
            {
                foreach (var x in butt)
                {
                    try { ButtonColorCLick(StaticProperty.btnDictioary.Values.FirstOrDefault(r => r.id == x)); }
                    catch { Console.WriteLine("Раскрасска соседей"); }
                }
            }
        }

        // соседи
        private HashSet<int> Neighbors()
        {
            // 0 size
            int shift = 1;
            double index = _but.id + shift; // тут сдвижка на 1 так как нумерация начинается с 0, а не с 1
            HashSet<int> indexSet = new HashSet<int>();
            // левая грань, не добавляем индекс слева, не +1
            if (!(index % _sizematrix == 0)) { indexSet.Add((int)index + 1 - shift); }
            // правая грань, не добавляем индекс справа, не -1
            if (!((index - 1) % _sizematrix == 0)) { indexSet.Add((int)index - 1 - shift); }
            // нижняя грань, не добавляем индекс снизу, не +size
            if (!(index <= _sizematrix)) { indexSet.Add((int)index - _sizematrix - shift); }
            // верхняя грань, не добавляем индекс сверху, не -size
            if (!(index + _sizematrix > _sizematrix * _sizematrix)) { indexSet.Add((int)index + _sizematrix - shift); }
            return indexSet;
        }

        // для перекраски 
        private void ButtonColorCLick(AdvancedButton but)
        {
            if (but.btn.BackgroundColor == Color.Red) { but.btn.BackgroundColor = Color.Orange; but.btn.Image = "@Drawable/button_orange.jpg"; }
            else if (but.btn.BackgroundColor == Color.Orange) { but.btn.BackgroundColor = Color.Yellow; but.btn.Image = "@Drawable/button_yellow.jpg"; }
            else if ((_countColor == 3) && (but.btn.BackgroundColor == Color.Yellow)) { but.btn.BackgroundColor = Color.Red; but.btn.Image = "@Drawable/button_red.jpg"; }
                else if (!(_countColor == 3) && (but.btn.BackgroundColor == Color.Yellow)) { but.btn.BackgroundColor = Color.Green; but.btn.Image = "@Drawable/button_green.jpg"; }
            else if ((_countColor == 4) && (but.btn.BackgroundColor == Color.Green)) { but.btn.BackgroundColor = Color.Red; but.btn.Image = "@Drawable/button_red.jpg"; }
                else if (!(_countColor == 4) && (but.btn.BackgroundColor == Color.Green)) { but.btn.BackgroundColor = Color.Aqua; but.btn.Image = "@DrawableDrawable/button_blue.jpg"; }
            else if ((_countColor == 5) && (but.btn.BackgroundColor == Color.Aqua)) { but.btn.BackgroundColor = Color.Red; but.btn.Image = "@Drawable/button_red.jpg"; }
                else if (!(_countColor == 5) && (but.btn.BackgroundColor == Color.Aqua)) { but.btn.BackgroundColor = Color.Blue; but.btn.Image = "@Drawable/button_darkblue.jpg"; }
            else if ((_countColor == 6) && (but.btn.BackgroundColor == Color.Blue)) { but.btn.BackgroundColor = Color.Red; but.btn.Image = "@Drawable/button_red.jpg"; }
                else if (!(_countColor == 6) && (but.btn.BackgroundColor == Color.Blue)) { but.btn.BackgroundColor = Color.Purple; but.btn.Image = "@Drawable/button_purple.jpg"; }
            else if ((_countColor == 7) && (but.btn.BackgroundColor == Color.Purple)) { but.btn.BackgroundColor = Color.Red; but.btn.Image = "@Drawable/button_red.jpg"; }
                else if (!(_countColor == 7) && (but.btn.BackgroundColor == Color.Purple)) { but.btn.BackgroundColor = Color.Black; but.btn.Image = "@Drawable/Icon.jpg"; }
            else if (but.btn.BackgroundColor == Color.Black) { but.btn.BackgroundColor = Color.Red; but.btn.Image = "@Drawable/button_red.jpg"; }
        }

    }
}
