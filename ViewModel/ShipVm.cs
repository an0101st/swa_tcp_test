using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_8_server.ViewModel {
	public class ShipVm {
		public string ShipID { get; set; }
		public ObservableCollection<CargoVm> Cargos { get; set; }
		public int WeightSum { get; set; }
	}
}
