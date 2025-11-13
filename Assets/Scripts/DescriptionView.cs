using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionView : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _count;

    [SerializeField] private Button _addButton;
    [SerializeField] private Button _removeButton;
    [SerializeField] private Button _closeButton;

    [SerializeField] private Cart _cart;

    private void Awake()
    {
        _content.SetActive(false);
        _closeButton.onClick.AddListener(() => _content.SetActive(false));
    }

    public void Show(Product product)
    {
        UpdateInfo(product);

        _addButton.onClick.RemoveAllListeners();
        _addButton.onClick.AddListener(() => Add(product));

        _removeButton.onClick.RemoveAllListeners();
        _removeButton.onClick.AddListener(() => Remove(product));

        _content.SetActive(true);
    }

    public void UpdateInfo(Product product)
    {
        _icon.sprite = product.Icon;
        _name.text = product.Name;
        _description.text = product.Description;
        _description.text += $"\n\nЦена: {product.Price}";

        ProductInCart productCart = _cart.FindProduct(product);
        _count.text = productCart != null ? productCart.Count.ToString() : "0";
    }

    public void Add(Product product)
    {
        _cart.AddProduct(product);
        UpdateInfo(product);
    }

    public void Remove(Product product)
    {
        _cart.RemoveProduct(product);
        UpdateInfo(product);
    }
}
