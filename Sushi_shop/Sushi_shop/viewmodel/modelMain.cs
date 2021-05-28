using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Win32;
using Sushi_shop.Annotations;

namespace Sushi_shop.viewmodel
{
    public class ModelMain : INotifyPropertyChanged
    {
        public ObservableCollection<Products> _productsList = loginWindow.SushiDb.Products.Local;
        public ObservableCollection<category> _categoryList = loginWindow.SushiDb.category.Local;
        public ObservableCollection<comments> _commentsList;
        private category _selectedCategory = new category();
        private Products _products;
        private Commands _delProduct;
        private Commands _addProduct;
        private Commands _changeImage;
        private Commands _delCategory;
        private Commands _addCategory;
        private Commands _plus_minus;
        private Commands _showComment;
        private Visibility _visibilityFrame = Visibility.Hidden;
        private Commands _addcomment;
        public string NewComment { get; set; }

        public Visibility VisibilityFrame
        {
            get => _visibilityFrame;
            set
            {
                _visibilityFrame = value;
                OnPropertyChanged("VisibilityFrame");
            }
        }

        public category SelectedCategory 
        { 
            get=> _selectedCategory;
            set
            {
                _selectedCategory = value;
                SelectingProductsToCategory();
            }
        }

        public Commands ShowComment
        {
            get
            {
                return _showComment ??
                    (_showComment = new Commands(obj =>
                    {
                        if (VisibilityFrame == Visibility.Hidden)
                        {
                            VisibilityFrame = Visibility.Visible;
                            SelectingComments();
                        }
                        else
                            VisibilityFrame = Visibility.Hidden;
                    }));
            }
        }

        public Commands addComment
        {
            get
            {
                return _addcomment ??
                    (_addcomment = new Commands(obj =>
                    {
                        comments _addcomment = new comments();
                        _addcomment.comment = NewComment;

                        if (loginWindow.SushiDb.comments.Count() != 0)
                            _addcomment.Comment_id = loginWindow.SushiDb.comments.Local.Last().Comment_id + 1;
                        else
                            _addcomment.Comment_id = 0;

                        _addcomment.Comment_product_id = SelectedProduct.id_product;
                        _addcomment.Comment_user_id = loginWindow.UserID;
                        CommentsList.Add(_addcomment);
                        loginWindow.SushiDb.comments.Add(_addcomment);
                    },
                    o=> NewComment != null && NewComment != "" ));
            }
        }


        public Commands AddCategory
        {
            get
            {
                return _addCategory ??
                    (_addCategory = new Commands(obj =>
                    {
                        category _category = new category();
                        _category.category_name = SelectedCategory.category_name;
                        CategoryList.Add(_category);
                    }
                    , o=>SelectedCategory.category_name!=null && SelectedCategory.category_name !=""));
            }
        }

        public Commands DeleteCategory
        {
            get
            {
                return _delCategory ??
                    (_delCategory = new Commands(obj =>
                    {
                        var delCategory = CategoryList.Where(u => u.category_name == SelectedCategory.category_name) ;
                        if(delCategory.Count() != 0)
                            CategoryList.Remove(delCategory.First());

                    },
                    o => CategoryList.Count() != 0 && SelectedCategory.category_name != null && SelectedCategory.category_name != ""));
            }
        }


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
        
        public ObservableCollection<Products> ProductsList
        {
            get => _productsList;
            set
            {
                _productsList = value;
                OnPropertyChanged("ProductsList");
            }
        }

        public ObservableCollection<comments> CommentsList
        {
            get => _commentsList;
            set
            {
                _commentsList = value;
                OnPropertyChanged("CommentsList");
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


        public Commands DeleteProduct
        {
            get
            {
                return _delProduct ??
                    (_delProduct = new Commands(obj =>
                    {
                        ProductsList.Remove(SelectedProduct);

                    },
                    o => SelectedProduct != null));
            }
        }

        public Commands AddProduct
        {
            get
            {
                return _addProduct ??
                    (_addProduct = new Commands(obj =>
                    {
                        Products _product = new Products();
                        _product.product_name = string.Empty;
                        _product.price = 0.0;
                        ProductsList.Add(_product);
                    }
                    ));
            }
        }

      

        public Commands ChangeImage
        {
            get
            {
                return _changeImage ??
                (_changeImage = new Commands(obj =>
                {
                    byte[] binArray = OpenImageDialog();
                    if (binArray == null) return;
                    if ((binArray.Length / 1024) > 1024)
                    {
                        MessageBox.Show("Файл больше мегабайта");
                        return;
                    }

                     SelectedProduct.product_image = binArray;
                          
                }));
            }
        }

        private byte[] OpenImageDialog()
        {
            var openFileDialog = new OpenFileDialog { Filter = @"Image files (*.jpg,*.png)|*.jpg;*.png" };
            byte[] binArray = null;
            if (openFileDialog.ShowDialog() == true)
            {
                binArray = System.IO.File.ReadAllBytes(openFileDialog.FileName);
            }
            else
            {
                return null;
            }
            return binArray;
        }

        private void SelectingComments() => CommentsList = new ObservableCollection<comments>(loginWindow.SushiDb.comments.Local.Where(o => o.Comment_product_id == SelectedProduct.id_product));
        private void SelectingProductsToCategory() => ProductsList = new ObservableCollection<Products>(loginWindow.SushiDb.Products.Local.Where(o => o.category_id == SelectedCategory.category_id));

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}