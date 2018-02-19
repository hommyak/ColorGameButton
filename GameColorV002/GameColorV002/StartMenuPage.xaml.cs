using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameColorV002
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartMenuPage : ContentPage
	{
		public StartMenuPage ()
		{
			InitializeComponent ();
            BackgroundColor = StaticProperty._opColor;
		}
	}
}
