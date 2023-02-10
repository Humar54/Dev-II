using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewCustomer : MonoBehaviour
{
    [SerializeField] private GameObject _customerList;
    [SerializeField] private CustomerInfo _customerPrefab;

    public void AddCustomer(string customerName)
    {
        CustomerInfo newCustomer =Instantiate(_customerPrefab);
        newCustomer.transform.SetParent(_customerList.transform);
        newCustomer.transform.SetAsFirstSibling();
        newCustomer.SetCustomerName(customerName);
    }
}
