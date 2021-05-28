using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sushi_shop.Annotations;

namespace Sushi_shop.viewmodel
{
    
    public class Delivery : INotifyPropertyChanged
    {
        public ObservableCollection<Orders> _orderList = loginWindow.SushiDb.Orders.Local;

        public ObservableCollection<Orders> OrderList
        {
            get => _orderList;
            set => _orderList = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}