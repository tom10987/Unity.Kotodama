
using ItemList = System.Collections.Generic.Dictionary<ItemName, string>;


public enum ItemName {
  Empty,

  Tutorial_A,
  Tutorial_B,
  Tutorial_C,
  Tutorial_Clear,

  Phone_A,
  Phone_B,
  Phone_C,
  Phone_Clear,

  Manhole_A,
  Manhole_B,
  Manhole_C,
  Manhole_D,
  ManholeKey_1,
  ManholeKey_2,
  Manhole_Clear,

  Labyrinth_Clear,

  Shoes,
  Papers,
  Apple,
  Doll,
}


public class ItemData {

  static readonly ItemList _itemName = new ItemList {
    { ItemName.Empty, "Empty" },

    { ItemName.Shoes,  "シューズ" },
    { ItemName.Papers, "作文用紙" },
    { ItemName.Apple,  "リンゴ" },
    { ItemName.Doll,   "ぬいぐるみ" },
  };

  static public string ToString(ItemName key) {
    var existsItem = _itemName.ContainsKey(key);
    return existsItem ? _itemName[key] : "お札";
  }
}
