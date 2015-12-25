
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
    //foreach (var instance in _toGimmickArea) { instance.SetActive(true); }
  }

  public void RegionRelease() {
  }
}
