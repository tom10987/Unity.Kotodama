
using UnityEngine;


public class ShrineStage : MonoBehaviour {

  ItemManager itemManager { get { return ItemManager.instance; } }

  [SerializeField]
  GameObject[] _toGimmickArea = null;

  readonly ItemName[] _keyItems = new ItemName[] {
    ItemName.Doll,
    ItemName.Apple,
    ItemName.Papers,
  };

  bool ExistsItem(ItemName item) {
    return itemManager.items.ContainsKey(item);
  }

  void Start() {
    for (uint index = 0; index < _toGimmickArea.Length; ++index) {
      // TIPS: まだステージに入ったことがなければアイテムが存在しない
      var existsItem = ExistsItem(_keyItems[index]);
      _toGimmickArea[index].SetActive(!existsItem);
      if (!existsItem) { continue; }

      // TIPS: ステージに入ったことがあり、アイテムは持ってないとき
      var hasItem = itemManager.items[_keyItems[index]].hasItem;
      _toGimmickArea[index].SetActive(hasItem);
    }
  }

  public void RegionRelease() {
  }
}
