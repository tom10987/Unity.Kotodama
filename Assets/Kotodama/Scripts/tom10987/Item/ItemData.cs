
using System.Collections.Generic;


public enum ItemName {
  Empty,

  Amulet_Bill,
  Amulet_A,
  Amulet_B,
  Amulet_C,
  Amulet_D,
  ManholeKey_B,
  ManholeKey_D,

  Bone,
  Collar,
  Ball,

  Shoes,
  Papers,
  Apple,
  Doll,
}


public class ItemData {

  static Dictionary<ItemName, string> _itemName = new Dictionary<ItemName, string> {
    { ItemName.Empty, string.Empty },

    { ItemName.Amulet_Bill, "お札" },
    { ItemName.Amulet_A, "お札" },
    { ItemName.Amulet_B, "お札" },
    { ItemName.Amulet_C, "お札" },
    { ItemName.Amulet_D, "お札" },
    { ItemName.ManholeKey_B, "お札" },
    { ItemName.ManholeKey_D, "お札" },

    { ItemName.Bone,   "ホネ" },
    { ItemName.Collar, "首輪" },
    { ItemName.Ball,   "ボール" },

    { ItemName.Shoes,  "シューズ" },
    { ItemName.Papers, "作文用紙" },
    { ItemName.Apple,  "リンゴ" },
    { ItemName.Doll,   "ぬいぐるみ" },
  };

  static public string ToString(ItemName key) { return _itemName[key]; }
}
