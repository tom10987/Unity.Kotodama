
using System.Collections.Generic;


public class ItemManager : SingletonBehaviour<ItemManager> {

  Dictionary<ItemName, ItemState> _items = null;
  public Dictionary<ItemName, ItemState> items { get { return _items; } }


  protected override void Awake() {
    base.Awake();
    _items = new Dictionary<ItemName, ItemState>();
  }
}
