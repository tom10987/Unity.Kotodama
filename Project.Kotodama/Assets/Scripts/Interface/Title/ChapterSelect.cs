
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ChapterSelect : MonoBehaviour {

  static readonly string assetPath = "GameUI/Item/";
  static readonly ItemType[] keyItems = {
    ItemType.Doll,
    ItemType.Shoes,
    ItemType.Papers,
    ItemType.Apple,
  };

  public void Chapter1() {
    var keyItemList = new string[] {
      "Tutorial_CLEAR",
      "Key_Doll",
    };
    RegisterItem(keyItemList);
    Initialize();
  }

  public void Chapter2() {
    var keyItemList = new string[] {
      "Tutorial_CLEAR",
      "Key_Doll",
      "PhoneBooth_CLEAR",
      "Key_Shoes",
    };
    RegisterItem(keyItemList);
    Initialize();
  }

  public void Chapter3() {
    var keyItemList = new string[] {
      "Tutorial_CLEAR",
      "Key_Doll",
      "PhoneBooth_CLEAR",
      "Key_Shoes",
      "Manhole_CLEAR",
      "Key_Paper",
    };
    RegisterItem(keyItemList);
    Initialize();
  }

  // TIPS: アイテムデータ読み込み
  ItemIcon Load(string path) {
    return Resources.Load<ItemIcon>(assetPath + path);
  }

  // TIPS: アイテムをまとめて登録
  void RegisterItem(IEnumerable<string> itemList) {
    foreach (var path in itemList) { ItemManager.instance.Add(Load(path)); }
    Debug.Log(ItemManager.instance.items.Count());
  }

  // TIPS: アイテム初期化
  void Initialize() {
    foreach (var item in ItemManager.instance.items) {
      // TIPS: キーアイテムでなければ使用済みにする
      var find = keyItems.Any(type => item.data.type == type);
      if (!find) { ItemManager.instance.UseItem(item.data.type); }
    }
  }
}
