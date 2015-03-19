using System;
using ContextActionXamarin.Model;
using System.Collections.ObjectModel;
using ContextActionXamarin.Helpers;
using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.ServiceModel.Channels;

namespace ContextActionXamarin.ViewModels
{
	public class FoodViewModel: BaseViewModel
	{
		public ObservableCollection<Food> Foods { get; set; }
		public ObservableCollection<Grouping<string, Food>> FoodsGrouped { get; set; }
		private bool isBusy;

		public FoodViewModel ()
		{
			LoadData ();
		}

		public bool IsBusy
		{
			get { return isBusy; }
			set 
			{
				if (isBusy == value)
					return;

				isBusy = value;
				OnPropertyChanged ("IsBusy");
			}
		}
		public void LoadData()
		{
			IsBusy = true;
			Foods = new ObservableCollection<Food>();
			Foods.Add(new Food
				{
					Name = "Hamburguer",
					Image = "https://cdn2.iconfinder.com/data/icons/tasty-bites-icon-set/512/hambruger.png"
				});

			Foods.Add(new Food
				{
					Name = "Salad",
					Image = "http://icons.iconarchive.com/icons/aha-soft/desktop-buffet/256/Salad-icon.png"
				});

			Foods.Add(new Food
				{
					Name = "Salad",
					Image = "http://icons.iconarchive.com/icons/aha-soft/desktop-buffet/256/Salad-icon.png"
				});
			Foods.Add(new Food
				{
					Name = "Hasdsa",
					Image = "http://icons.iconarchive.com/icons/aha-soft/desktop-buffet/256/Salad-icon.png"
				});
			Foods.Add(new Food
				{
					Name = "Has",
					Image = "http://icons.iconarchive.com/icons/aha-soft/desktop-buffet/256/Salad-icon.png"
				});

			var sorted = from food in Foods
				orderby food.Name
				group food by food.NameSort into monkeyGroup
				select new Grouping<string, Food>(monkeyGroup.Key, monkeyGroup);

			FoodsGrouped = new ObservableCollection<Grouping<string, Food>>(sorted);
			IsBusy = false;


		}
		public ICommand LoadDataCommand
		{
			get
			{
				return new Command (async () => {
					if (IsBusy == false)
					{
						 LoadData();
					}
				});
			}
		}



	}
}

