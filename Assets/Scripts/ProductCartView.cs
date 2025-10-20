using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductCartView : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _countText;

    [Header("Buttons")]
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _removeButton;

    public Button AddButton => _addButton;
    public Button RemoveButton => _removeButton;

    public void UpdateInfo(Product product, int count)
    {
        _icon.sprite = product.Icon;
        _nameText.text = product.Name;
        _priceText.text = $"Цена: {product.Price * count}";
        _countText.text = count.ToString();
    }
}
