using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private ProductCartView _prefab;

    private List<ProductInCart> _cartList = new List<ProductInCart>();

    public void AddProduct(Product product)
    {
        ProductInCart productInCart = FindProduct(product);

        if (productInCart == null)
        {
            productInCart = new ProductInCart();

            productInCart.Product = product;
            productInCart.Prefab = Instantiate(_prefab, _content);
            productInCart.Count = 1;

            productInCart.Prefab.AddButton.onClick.AddListener(() => AddProduct(product));
            productInCart.Prefab.RemoveButton.onClick.AddListener(() => RemoveProduct(product));

            _cartList.Add(productInCart);
        }
        else
        {
            productInCart.Count++;
        }

        productInCart.Prefab.UpdateInfo(product, productInCart.Count);
    }

    public void RemoveProduct(Product product)
    {

    }

    private ProductInCart FindProduct(Product product)
    {
        foreach (ProductInCart item in _cartList)
        {
            if (item.Product == product)
            {
                return item;
            }
        }

        return null;
    }
}

[System.Serializable]
public class ProductInCart
{
    public Product Product;
    public ProductCartView Prefab;
    public int Count;
}