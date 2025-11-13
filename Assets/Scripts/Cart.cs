using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private ProductCartView _prefab;
    [SerializeField] private TMP_Text _count;

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
        _count.text = $"ќформить ({Sum()})";
    }

    public void RemoveProduct(Product product)
    {
        ProductInCart productInCart = FindProduct(product);
        if (productInCart != null)
        {
            productInCart.Count--;
            if (productInCart.Count == 0)
            {
                Destroy(productInCart.Prefab.gameObject);
                _cartList.Remove(productInCart);
            }

            productInCart.Prefab.UpdateInfo(product, productInCart.Count);
        }

        _count.text = $"ќформить ({Sum()})";
    }

    public int Sum()
    {
        int sum = 0;
        foreach (ProductInCart item in _cartList)
        {
            sum += item.Count * item.Product.Price;
        }
        return sum;
    }

    public ProductInCart FindProduct(Product product)
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