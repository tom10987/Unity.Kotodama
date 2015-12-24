
using UnityEngine;
using UnityEngine.UI;


// TIPS: メニュー画面生成時の初期化のみ動作する
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
      if (!itemData.Value.hasItem) { continue; }

      var newObject = Instantiate(itemBox);
      newObject.name = itemData.Key.ToString();
      newObject.transform.SetParent(transform);
      newObject.transform.localScale = Vector3.one;

      var box = newObject.GetComponent<ItemBox>();
      box.image.sprite = itemData.Value.sprite;
      box.image.type = Image.Type.Filled;
      box.image.preserveAspect = true;
      box.itemName.text = ItemData.ToString(itemData.Key);
      box.itemInfo.text = itemData.Value.itemInfo;
    }
  }
}
