using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.OS;
using Android.Runtime;
using Android.Content;
using System.Threading;

namespace GameColorV002
{


    class EmergeTask
    {
        // TEST
        private GamePlay TGame = new GamePlay();
        // GridClass
        private GridClass Grc = new GridClass();
        // LvLs
        private LvLs Lvl = new LvLs();
        // PlanePage
        PlanePage PlP = new PlanePage();

        public void EmergeTasks(Context cont, string task)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(cont);
            builder.SetTitle("Задание!");
            builder.SetMessage(task);
            builder.SetCancelable(false);
            builder.SetPositiveButton("oк", (object sender, DialogClickEventArgs e) =>
             {
                 builder.Dispose();
             });

            AlertDialog alert = builder.Create();
            alert.Show();
        }

        public void EmergeWin(Context cont)
        {
            //ImageView image = new ImageView(cont);

            AlertDialog.Builder builder = new AlertDialog.Builder(cont);
            builder.SetTitle("Поздравляем, уровень пройден!");
            builder.SetCancelable(false);
            builder.SetPositiveButton("Далее", (object sender, DialogClickEventArgs e) =>
            {
                builder.Dispose();
                (new LvLs()).WriteFile(StaticProperty.thisLvl);
                StaticProperty.thisLvl = Lvl.GetLvl();
                StaticProperty.thisLevel = new InfoLvls(StaticProperty.thisLvl).GetInfLvl_Dict;
                PlP.Content = Grc.StartingGRC(Convert.ToInt32(StaticProperty.thisLevel.size), StaticProperty.thisLevel.color, true, StaticProperty.thisLevel.text);
                StaticProperty.curControllClass.MainPage = PlP;
            });

            AlertDialog alert = builder.Create();
            alert.Show();
        }

        // ТЕСТОВЫЙ
        public void TESTSEmergeWin(Context cont)
        {
            //Thread.Sleep(1000);
            //ImageView image = new ImageView(cont);

            AlertDialog.Builder builder = new AlertDialog.Builder(cont);
            builder.SetTitle("Поздравляем, уровень пройден!");
            builder.SetCancelable(false);
            builder.SetPositiveButton("Далее", (object sender, DialogClickEventArgs e) =>
            {
                builder.Dispose();
                (new LvLs()).WriteFile(StaticProperty.thisLvl);
                StaticProperty.thisLvl = Lvl.GetLvl();
                StaticProperty.thisLevel = new InfoLvls(StaticProperty.thisLvl).GetInfLvl_Dict;
                PlP.Content = TGame.tester(Convert.ToInt32(StaticProperty.thisLevel.size), StaticProperty.thisLevel.color, true, StaticProperty.thisLevel.text);
                StaticProperty.curControllClass.MainPage = PlP;
            });

            AlertDialog alert = builder.Create();
            alert.Show();
        }

        public void Сonfirmation(Context cont)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(cont);
            builder.SetTitle("Уверены? Это не поправимо. Может одумаетесь?");
            builder.SetCancelable(false);
            builder.SetPositiveButton("ДА", (object sender, DialogClickEventArgs e) =>
            {
                Lvl.Rewrite();
            });
            builder.SetNegativeButton("не уверен", (object sender, DialogClickEventArgs e) =>
            {
                builder.Dispose();
            });

            AlertDialog alert = builder.Create();
            alert.Show();
        }
    }
}
