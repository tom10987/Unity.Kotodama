
using System.Collections.Generic;

public enum ItemType {
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

  Doll,
  Shoes,
  Papers,
  Apple,

  Max,
}

public static class ItemTypeExtension {
  static ItemTypeExtension() {
    _itemName = new Dictionary<ItemType, string>();
    _itemName.Add(ItemType.Empty, "Empty");
    _itemName.Add(ItemType.Doll, "汚れたぬいぐるみ");
    _itemName.Add(ItemType.Shoes, "汚れたスニーカー");
    _itemName.Add(ItemType.Papers, "ボロボロの作文用紙");
    _itemName.Add(ItemType.Apple, "リンゴ");
  }

  static readonly Dictionary<ItemType, string> _itemName = null;

  public static string GetName(this ItemType item) {
    var existName = _itemName.ContainsKey(item);
    return existName ? _itemName[item] : "お札";
  }
}
