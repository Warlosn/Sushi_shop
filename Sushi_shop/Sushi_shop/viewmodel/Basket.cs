using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections;
using Microsoft.Win32;
using Sushi_shop.Annotations;
using System.Collections.Generic;

namespace Sushi_shop.viewmodel
{
    public partial class ModelMain
    {
        private Commands _delProductBasket;
        private Commands _addProductBasket;
        private Commands _showBasket;
        private double _fullPrice = 0;
        private Visibility _visibilityFrameBasket = Visibility.Hidden;
        private ObservableCollection<Products> _basketProduct = new ObservableCollection<Products> { };
        private Commands _acceptOrder;
        private Commands _clearBasket;

        public Commands AcceptOrder
        {
            get
            {
                return _acceptOrder ??
                    (_acceptOrder = new Commands(obj =>
                    {
                        int index;
                        Orders order = new Orders();
                        order.all_price = FullPrice;
                        order.order_client_id = loginWindow.UserID;
                        
                        if (loginWindow.SushiDb.Orders.Count() != 0)
                            order.id_order = loginWindow.SushiDb.Orders.Local.Last().id_order + 1;
                        else
                            order.id_order = 0;

                        if (loginWindow.SushiDb.order_details.Local.Count() != 0)
                            index = loginWindow.SushiDb.order_details.Local.Last().details_id + 1;
                        else
                            index = 0;

                        foreach (var product in _basketProduct)
                        {
                            var orderDetails = new order_details();
                            orderDetails.details_product_id = product.id_product;
                            orderDetails.detail_order_id = order.id_order;
                            orderDetails.details_id = index++;

                            order.order_details.Add(orderDetails);
                        }


                        loginWindow.SushiDb.Orders.Add(order);
                        loginWindow.SushiDb.SaveChanges();
                    }));
            }
        }

        public Commands ClearBasket
        {
            get
            {
                return _clearBasket ??
                    (_clearBasket = new Commands(obj =>
                    {
                        if (_basketProduct.Count != 0)
                            _basketProduct.Clear();
                    }));
            }
        }

        public double FullPrice
        {
            get => _fullPrice;
            set
            {
                _fullPrice = value;
                OnPropertyChanged("FullPrice");
            }

        }
        public Visibility VisibilityFrameBasket
        {
            get => _visibilityFrameBasket;
            set
            {
                _visibilityFrameBasket = value;
                OnPropertyChanged("VisibilityFrameBasket");
            }
        }

        public ObservableCollection<Products> BasketProduct
        {
            get => _basketProduct;
            set
            {
                _basketProduct = value;
                OnPropertyChanged("BasketProduct");
            }
        }

        public Commands AddBasket
        {
            get
            {
                return _addProductBasket ??
                    (_addProductBasket = new Commands(obj =>
                    {
                        for (int i = 0; i < SelectedProduct.product_quantity; i++)
                        {
                            BasketProduct.Add(SelectedProduct);
                        }
                       
                        FullPrice = BasketProduct.Sum(o=>o.price);
                    }));
            }
        }

        public Commands DelBasket
        {
            get
            {
                return _delProductBasket ??
                    (_delProductBasket = new Commands(obj =>
                    {
                        BasketProduct.Remove(SelectedProduct);
                    }));
            }
        }
        public Commands ShowBasket
        {
            get
            {
                return _showBasket ??
                    (_showBasket = new Commands(obj =>
                    {
                        if (VisibilityFrameBasket == Visibility.Hidden)
                        {
                            VisibilityFrameBasket = Visibility.Visible;

                        }
                        else
                            VisibilityFrameBasket = Visibility.Hidden;
                    }));
            }
        }
    }
}