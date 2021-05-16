using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sushi_shop.Annotations;

namespace Sushi_shop.viewmodel
{
    public class ModelMain : INotifyPropertyChanged
    {
        public ObservableCollection<Products> _productsList = loginWindow.SushiDb.Products.Local;
        public ObservableCollection<category> _categoryList = loginWindow.SushiDb.category.Local;
        private Products _products;
        public category SelectedCategory { get; set; }

        public Products SelectedProduct
        {
            get => _products;
            set
            {
                if (value != null)
                {
                    _products = value;
                    OnPropertyChanged("SelectedProduct");
                }
            }
        }
        private Commands _plus_minus;
        public ObservableCollection<Products> ProductsList
        {
            get => _productsList;
            set
            {
                _productsList = value;
                OnPropertyChanged("ProductsList");
            }
        }
        
        public ObservableCollection<category> CategoryList
        {
            get => _categoryList;
            set
            {
                _categoryList = value;
                OnPropertyChanged("CategoryList");
            }
        }

        public Commands plus_minus
        {
            get
            {
                return _plus_minus ??
                    (_plus_minus = new Commands( obj => {
                       
                        switch(obj as string)
                        {
                            case "+":
                                SelectedProduct.product_quantity++;
                                break;
                            case "-":
                                if(SelectedProduct.product_quantity > 1)
                                    SelectedProduct.product_quantity--;
                                break;
                        }

                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}