using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using System.Reflection;
[assembly: Dependency(typeof(GameColorV002.LvLs))]

namespace GameColorV002
{
    // класс LvLs
    public class LvLs
    {
        // начальное выполнение
        public void run()
        {
            FullPath();
            StartGameWrite();
        }

        // Генерирование пути
        public void FullPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            StaticProperty.FullPath = Path.Combine(path, "myfile.txt");
        }

        // Первая запись
        private void StartGameWrite()
        {
            string fileData = "";
            if (!File.Exists(StaticProperty.FullPath))
            {
                fileData = StaticProperty.ingo;

                using (StreamWriter sw = new StreamWriter(StaticProperty.FullPath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(fileData);
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(StaticProperty.FullPath, System.Text.Encoding.Default))
                {
                    fileData = sr.ReadToEnd();
                }
                if (fileData.Length <= StaticProperty.ingo.Length * 0.75)
                    using (StreamWriter sw = new StreamWriter(StaticProperty.FullPath, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(StaticProperty.ingo);
                    }
            }
        }

        // Rewrite
        public void Rewrite()
        {
            using (StreamWriter sw = new StreamWriter(StaticProperty.FullPath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(StaticProperty.ingo);
            }
        }
    
        // Создание файла и получение данных с файла
        public string DataFile()
        {

            FileInfo fi1 = new FileInfo(StaticProperty.FullPath);

            string fileData = "";

            if (!File.Exists(StaticProperty.FullPath))
            {
                fileData = StaticProperty.ingo;

                using (StreamWriter sw = new StreamWriter(StaticProperty.FullPath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(fileData);
                }
             }
            else
            {
                using (StreamReader sr = new StreamReader(StaticProperty.FullPath, System.Text.Encoding.Default))
                {
                    fileData = sr.ReadToEnd();
                }
            }

            return Convert.ToString(fileData);
        }

        // Запись в файл
        public void WriteFile(int lvl)
        {
            string tmpData = DataFile();
            tmpData = LvlComplited(tmpData, lvl);

            using (StreamWriter sw = new StreamWriter(StaticProperty.FullPath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(tmpData);
            }
        }

        // метод для изменения значения уровня. (пройден/не пройден)
        private string LvlComplited(string tmpData, int lvl)
        {
            var firstsplTmp = tmpData.Split(';');
            string retData = "";

            for (int i = 0; i < firstsplTmp.Length - 1; i++)
            {
                var secondsplTmp = firstsplTmp[i].Split('=');
                if (Convert.ToInt32(secondsplTmp[1]).Equals(lvl)) { secondsplTmp[2] = "true"; }
                retData = retData + secondsplTmp[0] + "=" + secondsplTmp[1] + "=" + secondsplTmp[2] + ";";
            }

            return retData;
        }

        // метод для получени первого не пройденного уровня
        public int GetLvl()
        {
            string tmpData = DataFile();
            var firstsplTmp = tmpData.Split(';');
            int retData = 1;

            for (int i = 0; i < firstsplTmp.Length - 1; i++)
            {
                var secondsplTmp = firstsplTmp[i].Split('=');
                if (Convert.ToBoolean(secondsplTmp[2]).Equals(false)) { return Convert.ToInt32(secondsplTmp[1]); }
            }

            Rewrite();
            return retData;
        }
    }

    // класс Информация уровней
    public class InfoLvls
    {
        private int _idLvl;
        private Dictionary<int, Level> dict = new Dictionary<int, Level>();
      
        // конструктор
        public InfoLvls(int idLvl)
        {
            this._idLvl = idLvl;
        }
        
        // Добавление уровней
        private void AddDict()
        {
            dict.Add(1, new Level(3, 3, "Закрасьте поле так, чтобы 1 клетка была оранжевого цвета, а остальные - красного.", new Checking(8, 1, 0, 0, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(2, new Level(3, 3, "Закрасьте поле в оранжевый цвет.", new Checking(0, 9, 0, 0, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(3, new Level(3, 3, "Закрасьте поле так, чтобы присутствовали 3 цвета (красный, оранжевый, желтый).", new Checking(-1, -1, -1, 0, 0, 0, 0, 0), StaticProperty.CheckType.more1Equals));
            dict.Add(4, new Level(3, 3, "Закрасьте поле так, чтобы 1 клетка была желтого цвета, а остальные оранжевого.", new Checking(0, 8, 1, 0, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(5, new Level(3, 3, "Закрасьте поле в желтый цвет.", new Checking(0, 0, 9, 0, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));

            dict.Add(6, new Level(3, 4, "Закрасьте поле так, чтобы присутствовала хотя бы 1 клетка зеленого цвета.", new Checking(-2, -2, -2, -1, 0, 0, 0, 0), StaticProperty.CheckType.more2Equals));
            dict.Add(7, new Level(3, 4, "Закрасьте поле так, чтобы 1 клетка была зеленого цвета, а остальные - красного.", new Checking(8, 0, 0, 1, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(8, new Level(3, 4, "Закрасьте пело так, чтобы 1 клетка была зеленого цвета, 1 клетка - желтого, 1 клетка - оранжевого, а остальные - красного.", new Checking(-1, 1, 1, 1, 0, 0, 0, 0), StaticProperty.CheckType.more1Equals));
            dict.Add(9, new Level(3, 4, "Закрасьте поле так, чтобы 3 клетки были зеленого цвета, 3 клетки - желтого, 3 клетки - оранжевого.", new Checking(0, 3, 3, 3, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(10, new Level(3, 4, "Закрасьте поле в желтый цвет.", new Checking(0, 0, 9, 0, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));

            dict.Add(11, new Level(3, 4, "Закрасьте поле так, чтобы 1 клетка была красного цвета, а остальные - зеленого.", new Checking(1, 0, 0, -1, 0, 0, 0, 0), StaticProperty.CheckType.more1Equals));
            dict.Add(12, new Level(3, 4, "Закрасьте поле так, чтобы 2 клетки были оранжевого цвета, а остальные - зеленого..", new Checking(0, 2, 0, -1, 0, 0, 0, 0), StaticProperty.CheckType.more1Equals));
            dict.Add(13, new Level(3, 4, "Закрасьте поле так, чтобы 4 клетки были желтого цета, а остальные - зеленого.", new Checking(0, 0, 4, -1, 0, 0, 0, 0), StaticProperty.CheckType.more1Equals));
            dict.Add(14, new Level(3, 4, "Закрасьте поле в зеленый цвет.", new Checking(0, 0, 0, 9, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(15, new Level(3, 4, "Закрасьте поле в желтый цвет.", new Checking(0, 0, 9, 0, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));

            dict.Add(16, new Level(4, 4, "Закрасьте поле так, чтобы 2 клетки были красного цвета, а остальные - желтого.", new Checking(2, 0, -1, 0, 0, 0, 0, 0), StaticProperty.CheckType.more1Equals));
            dict.Add(17, new Level(4, 4, "Закрасьте поле так, чтобы 8 клеток были оранжевого цвета, а остальные - желтого.", new Checking(0, 8, 8, 0, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(18, new Level(4, 4, "Закрасьте поле так, чтобы 4 клетки были красного цвета, 4 клетки - оранжевого, 4 клетки - желтого, 4 клетки - зеленого.", new Checking(4, 4, 4, 4, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(19, new Level(4, 4, "Закрасьте поле так, чтобы 8 клеток были желтого цвета, а остальные - зеленого.", new Checking(0, 0, 8, -1, 0, 0, 0, 0), StaticProperty.CheckType.more1Equals));
            dict.Add(20, new Level(4, 4, "Закрасьте поле в зеленный цвет.", new Checking(0, 0, 0, 16, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));

            dict.Add(21, new Level(3, 5, "Закрасьте поле в желтый цвет.", new Checking(0, 0, 9, 0, 0, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(22, new Level(4, 5, "Закрасьте поле так, чтобы  хотя бы 1 клетка была синего цвета.", new Checking(-2, -2, -2, -2, 1, 0, 0, 0), StaticProperty.CheckType.more2Equals));
            dict.Add(23, new Level(4, 5, "Закрасьте поле так, чтобы  1 клетка была синего цвета.", new Checking(0, 0, 0, 0, 1, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(24, new Level(4, 5, "Закрасьте поле так, чтобы 3 клетки были желтого цвета, 3 - зеленого, 1 - синяя.", new Checking(0, 0, 3, 3, 1, 0, 0, 0), StaticProperty.CheckType.simpleEquals));
            dict.Add(25, new Level(4, 5, "Закрасьте поле так, чтобы 2 клетки были оранжевого цвета, 6 - желтого цвета, 3 - зеленого, 5 - синяя.", new Checking(0, 2, 6, 3, 5, 0, 0, 0), StaticProperty.CheckType.simpleEquals));

        }

        // Уровень (размер поля, кол-во цветов, задание, проверка уровня, метод проверки)
        private Level EqualsTaskDict()
        {
           if (dict.Count <= 1 ) { AddDict(); }
            return dict[_idLvl];
        }

        // получение InfoLvl_Dict
        public Level GetInfLvl_Dict
        {
            get
            {
                return EqualsTaskDict();
            }
        }
    }
    
    // класс конца уровня
    public class EndLvls
    {
        private Level lev;

        public EndLvls(Level L)
        {
            this.lev = L;
        }

        // метод для проверки прохождения
        public bool CheckLvl_Dict ()
        {
            Checking TmpCheck = CheckLvls();
            return TmpCheck.check(lev.checks, TmpCheck, lev.checksType);
        }

        // возвращает переменную типа Checking
        private Checking CheckLvls ()
        {
            Checking Tchecking = new Checking(0, 0, 0, 0, 0, 0, 0, 0);
            foreach (var button in StaticProperty.HashSetBtn)
            {
                if (button.BackgroundColor == Color.Red) { Tchecking.Red++; }
                else if (button.BackgroundColor == Color.Orange) { Tchecking.Orange++; }
                else if (button.BackgroundColor == Color.Yellow) { Tchecking.Yellow++; }
                else if (button.BackgroundColor == Color.Green) { Tchecking.Green++; }
                else if (button.BackgroundColor == Color.Aqua) { Tchecking.Aqua++; }
                else if (button.BackgroundColor == Color.Blue) { Tchecking.Blue++; }
                else if (button.BackgroundColor == Color.Purple) { Tchecking.Purple++; }
                else if (button.BackgroundColor == Color.Black) { Tchecking.Black++; }
            }
            return Tchecking;
        }


    }
}
