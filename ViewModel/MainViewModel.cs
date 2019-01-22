using example_8_server.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace example_8_server.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
		private ObservableCollection<ShipVm> ships;
		public ObservableCollection<ShipVm> Ships {
			get { return ships; }
			set { ships = value; RaisePropertyChanged(); }
		}

		private ShipVm selectedShip;
		public ShipVm SelectedShip {
			get { return selectedShip; }
			set { selectedShip = value; RaisePropertyChanged(); }
		}

		private RelayCommand connectBtnClicked;
		public RelayCommand ConnectBtnClicked {
			get { return connectBtnClicked; }
			set { connectBtnClicked = value; RaisePropertyChanged(); }
		}

		Server serverConn;
		public bool serverConnected { get; set; }

		public MainViewModel()
        {
			serverConnected = false;
			Ships = new ObservableCollection<ShipVm>();
			ConnectBtnClicked = new RelayCommand(
				() => {
					serverConn = new Server(GuiUpdater);
					serverConnected = true;
				}, () => {
					return !serverConnected;
				});
        }

		private void GuiUpdater(string msg) {
			App.Current.Dispatcher.Invoke(
				() => {
					// ShipId@recorder,20000,25000|DVDPlayer,10000,20000|PCs,50000,200000
					string[] entries = msg.Split('@');
					string[] recCargos = entries[1].Split('|');

					ObservableCollection<CargoVm> shipCargos = new ObservableCollection<CargoVm>();
					int weightSum = 0;

					for (int i = 0; i < recCargos.Length; i++) {
						string[] splittedCargoInf = recCargos[i].Split(',');
						weightSum += int.Parse(splittedCargoInf[2]);
						shipCargos.Add(new CargoVm() {
							Name = splittedCargoInf[0],
							Amount = int.Parse(splittedCargoInf[1]),
							Weight = int.Parse(splittedCargoInf[2])
						});
					}

					bool newID = true;
					foreach (var item in Ships) {
						if(item.ShipID == entries[0]){
							foreach (var cargo in shipCargos) {
								item.Cargos.Add(cargo);
							}
							item.WeightSum += weightSum;
							newID = false;
						}
					}

					if(newID) {
						Ships.Add(new ShipVm() {
							ShipID = entries[0],
							Cargos = shipCargos,
							WeightSum = weightSum
						});
					}

					RaisePropertyChanged("Ships");
					RaisePropertyChanged("SelectedShip");
					RaisePropertyChanged("SelectedShip.WeightSum");
					RaisePropertyChanged("Ships.WeightSum");
				});
		}
	}
}