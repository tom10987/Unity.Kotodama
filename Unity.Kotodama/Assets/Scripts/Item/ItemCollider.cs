
using UnityEngine;

public class ItemCollider : MonoBehaviour {

  [SerializeField]
  [Tooltip("触れると取得できる、アイテムのプレハブを指定")]
  ItemIcon _item = null;

  [SerializeField]
  [Range(0.5f, 2.0f)]
  float _messageTime = 1.0f;

  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }

    // TIPS: アイテムが登録済みなら、未使用の状態に戻す
    var success = ItemManager.instance.Add(_item);
    if (!success) { ItemManager.instance.GetItem(_item.type).useItem = false; }
    Destroy(gameObject);
    WindowManager.instance.CreateMessageWindow(GetItemMessage(), _messageTime);
  }

  string GetItemMessage() { return _item.type.GetName() + "を拾った"; }
}
