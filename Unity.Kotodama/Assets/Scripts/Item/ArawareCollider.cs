
using UnityEngine;
using System.Collections;


//------------------------------------------------------------
// TIPS:
// アイテムの設定さえ出来ていれば、条件を満たした時に勝手に消滅する

public class ArawareCollider : MonoBehaviour {

  WindowManager window { get { return WindowManager.instance; } }

  [SerializeField]
  ItemName _itemName = ItemName.Empty;
  ItemState _item = null;

  [SerializeField]
  SpriteRenderer _sprite = null;

  [SerializeField]
  string _dead = "どこか消えちゃった…";

  [SerializeField]
  string _stay = "近付かないほうがいいかも";

  bool _isDestroy = false;

  void Start() {
    StartCoroutine(ItemLoad());
  }

  void OnTriggerEnter(Collider other) {
    if (_isDestroy) { return; }
    if (other.tag != ObjectTag.Player.ToString()) { return; }

    PlayerState.instance.Stop();

    var message = _item.hasItem ? _dead : _stay;
    window.CreateMessageWindow(message);

    if (_item.hasItem) {
      _item.useItem = true;
      StartCoroutine(DestroyAraware());
    }
  }

  IEnumerator DestroyAraware() {
    _isDestroy = true;

    var enemyColor = _sprite.color;
    float alpha = 1f;

    while (alpha > 0f) {
      alpha -= Time.deltaTime;
      _sprite.color = enemyColor * alpha;
      yield return null;
    }

    Destroy(gameObject);
  }

  IEnumerator ItemLoad() {
    var items = ItemManager.instance.items;

    while (_item == null) {
      if (items.ContainsKey(_itemName)) { _item = items[_itemName]; }
      yield return null;
    }
  }
}
