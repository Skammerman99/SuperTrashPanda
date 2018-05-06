using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InventoryItem {
  string name { get;}
  Sprite Image {get;}
  void onPickup();
}

//public class InventoryEventArgs : EventArgs{
public class InventoryEventArgs : MonoBehaviour{ 
  public InventoryEventArgs(InventoryItem item){
        Item = item;
  }

  public InventoryItem Item;
}
