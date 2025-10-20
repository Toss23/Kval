using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button _newsButton;
    [SerializeField] private Button _productsButton;
    [SerializeField] private Button _cartButton;

    [SerializeField] private GameObject _newsContent;
    [SerializeField] private GameObject _productsContent;
    [SerializeField] private GameObject _cartContent;

    private void Awake()
    {
        _newsButton.onClick.AddListener(ShowNews);
        _productsButton.onClick.AddListener(ShowProducts);
        _cartButton.onClick.AddListener(CartProducts);

        ShowNews();
    }

    private void ShowNews()
    {
        _newsContent?.SetActive(true);
        _productsContent?.SetActive(false);
        _cartContent?.SetActive(false);
    }

    private void ShowProducts()
    {
        _newsContent?.SetActive(false);
        _productsContent?.SetActive(true);
        _cartContent?.SetActive(false);
    }

    private void CartProducts()
    {
        _newsContent?.SetActive(false);
        _productsContent?.SetActive(false);
        _cartContent?.SetActive(true);
    }
}
