using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Button _button;

    private Product _product;
    private DescriptionView _descriptionView;

    public void Set(Product product, DescriptionView descriptionView)
    {
        _product = product;
        _descriptionView = descriptionView;

        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(ShowDecription);

        UpdateInfo();
    }

    public void UpdateInfo()
    {
        _icon.sprite = _product.Icon;
        _nameText.text = _product.Name;
        _priceText.text = $"Цена: {_product.Price}";
    }

    private void ShowDecription()
    {
        _descriptionView.Show(_product);
    }
}
