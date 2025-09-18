using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNewWindows : MonoBehaviour
{
   [SerializeField] private GameObject _shop;
   [SerializeField] private GameObject _collection;

   public void OpenMenu()
   {
      _shop.SetActive(false);
      _collection.SetActive(false);
   }
   public void OpenShop()
   {
      _shop.SetActive(true);
      _collection.SetActive(false);
   }
   public void OpenCollection()
   {
      _shop.SetActive(false);
      _collection.SetActive(true);
   }
}
