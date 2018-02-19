using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameColorV002
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            L.run();
            this.Content = SM.StartingMenu();
        }
        private StartMenu SM = new StartMenu();
        private LvLs L = new LvLs();
	}
}
