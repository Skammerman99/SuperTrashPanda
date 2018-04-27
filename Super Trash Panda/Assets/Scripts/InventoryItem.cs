using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem{
  string name { get;}
  Sprite Image {get;}
  void onPickup();
}

public class InventoryEventArgs : EventArgs{
  public InventoryEventArgs(IInventoryItem item){
    Item = item
  }

  public IInventoryItem Item;
}
