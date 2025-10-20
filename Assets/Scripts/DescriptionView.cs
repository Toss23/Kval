using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionView : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;

    [SerializeField] private Button _addButton;
    [SerializeField] private Button _closeButton;

    [SerializeField] private Cart _cart;

    private void Awake()
    {
        _content.SetActive(false);
        _closeButton.onClick.AddListener(() => _content.SetActive(false));
    }

    public void Show(Product product)
    {
        _icon.sprite = product.Icon;
        _name.text = product.Name;
        _description.text = product.Description;
        _description.text += $"\n\nЦена: {product.Price}";

        _addButton.onClick.RemoveAllListeners();
        _addButton.onClick.AddListener(() => AddToCart(product));

        _content.SetActive(true);
    }

    public void AddToCart(Product product)
    {
        _cart.AddProduct(product);
    }
}
