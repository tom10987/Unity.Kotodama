
using UnityEngine;

public class ItemIcon : MonoBehaviour {

  [SerializeField]
  CanvasGroup _group = null;
  public CanvasGroup state { get { return _group; } }

  [SerializeField]
  ItemType _itemType = ItemType.Empty;
  public ItemType type { get { return _itemType; } }

  [SerializeField]
  [Multiline(2)]
  string _itemInfo = string.Empty;

  void Start() { transform.localScale = Vector3.one; }

  // TIPS: メニュー画面でタッチされた時の処理
  public void OnTouch() {
    var itemData = ItemText.instance;
    itemData.Activate();
    itemData.name.text = _itemType.GetName();
    itemData.info.text = _itemInfo;
  }
}
