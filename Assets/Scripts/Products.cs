using System.Collections.Generic;
using UnityEngine;

public class Products : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private ProductView _prefab;
    [SerializeField] private DescriptionView _descriptionView;

    private List<Product> _products = new List<Product>();

    private void Awake()
    {
        InitProducts();
        AddProductsToView();
    }

    private void InitProducts()
    {
        Product potato = new Product();
        potato.Name = "Картофель";
        potato.Description = "Свежий картофель, идеален для жарки, варки и запекания.";
        potato.Icon = Resources.Load<Sprite>("Potato");
        potato.Price = 150;

        Product tomato = new Product();
        tomato.Name = "Помидор";
        tomato.Description = "Сочные и ароматные, подходят для салатов, соусов и свежих закусок.";
        tomato.Icon = Resources.Load<Sprite>("Tomato");
        tomato.Price = 130;

        _products.Add(potato);
        _products.Add(tomato);
    }

    private void AddProductsToView()
    {
        foreach (Product product in _products)
        {
            ProductView productView = Instantiate(_prefab, _content);
            productView.Set(product, _descriptionView);
        }
    }
}