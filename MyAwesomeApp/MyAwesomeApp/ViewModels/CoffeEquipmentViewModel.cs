using MvvmHelpers;
using MvvmHelpers.Commands;
using MyAwesomeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyAwesomeApp.ViewModels  
{
    public class CoffeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public CoffeEquipmentViewModel()
        {
           Title = "Coffee Equipment";

            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";

            Coffee.Add(new Coffee { Roaster = "Yes PLZ", Name = "Sip of SunShine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes PLZ", Name = "Pontent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes PLZ", Name = "Kenya Kiambu", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes PLZ", Name = "Kenya Kiambu", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes PLZ", Name = "Kenya Kiambu", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes PLZ", Name = "Kenya Kiambu", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle ", new[] {Coffee[2]}));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Take(2)));

            RefreshCommand = new AsyncCommand(Refresh);
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
         
        }

       
    }
}
