
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ItemManager : SingletonBehaviour<ItemManager> {

  public class ItemState {
    public ItemState(ItemIcon item) {
      data = item;
      useItem = false;
    }
    public ItemIcon data { get; set; }
    public bool useItem { get; set; }
  }
  
  readonly List<ItemState> _items = new List<ItemState>();
  public IEnumerable<ItemState> items { get { return _items; } }

  /// <summary> アイテムを登録できれば、登録したうえで true を返す </summary>
  public bool Add(ItemIcon @new) {
    var existItem = _items.Any(item => item.data.type == @new.type);
    if (!existItem) { _items.Add(new ItemState(@new)); }
    return !existItem;
  }

  /// <summary> 指定したアイテムの状態を取得 </summary>
  public ItemState GetItem(ItemType type) {
    return _items.Find(item => item.data.type == type);
  }

  /// <summary> アイテムを使用した状態にする </summary>
  public void UseItem(ItemType type) {
    var find = _items.Find(item => item.data.type == type);
    if (find != null) { find.useItem = true; }
  }
}
