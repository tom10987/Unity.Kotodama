
using System.Collections.Generic;


public class ItemManager : SingletonBehaviour<ItemManager> {

  public Dictionary<ItemName, ItemState> items { get; private set; }
  
  protected override void Awake() {
    base.Awake();
    items = new Dictionary<ItemName, ItemState>();
  }
}
