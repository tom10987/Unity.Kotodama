
using System.Collections.Generic;


public class ItemManager : SingletonBehaviour<ItemManager> {

  public Dictionary<ItemName, ItemState> items { get; private set; }

  public void UpdateItemState(ItemName name, bool state) { items[name].UpdateState(state); }


  protected override void Awake() {
    base.Awake();
    items = new Dictionary<ItemName, ItemState>();
  }
}
