
using UnityEngine;


public class ItemViewer : MonoBehaviour {

  [SerializeField]
  GameObject _itemBox = null;
  GameObject itemBox {
    get {
      if (_itemBox == null) { _itemBox = Resources.Load<GameObject>("GameUI/MenuWindow/ItemBox"); }
      return _itemBox;
    }
  }

  ItemManager manager { get { return ItemManager.instance; } }


  void Start() {
    foreach (var itemData in manager.items) {
      manager.UpdateItemState(itemData.Key, true);
      if (!itemData.Value.hasItem) { continue; }

      var newObject = Instantiate(itemBox);
      newObject.name = itemData.Key.ToString();
      newObject.transform.SetParent(transform);
      newObject.transform.localScale = Vector3.one;

      var box = newObject.GetComponent<ItemBox>();
      box.image.sprite = itemData.Value.sprite;
      box.itemName.text = ItemData.ToString(itemData.Key);
      box.itemInfo.text = itemData.Value.itemInfo;
    }
  }
}
