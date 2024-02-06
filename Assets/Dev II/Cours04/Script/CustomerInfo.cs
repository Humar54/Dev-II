using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CustomerInfo : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _customerImage;

    private void Start()
    {
        _customerImage.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.75f, 1f);
    }

    public void SetCustomerName(string newName)
    {
        _name.text = newName;
    }

    public void DeleteCustomer()
    {
        Destroy(gameObject);
    }
}
