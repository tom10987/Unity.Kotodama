
using UnityEngine;

public class GateKeeperCollider : MonoBehaviour {

  [SerializeField]
  GateKeeperAnimator _animator = null;

  [SerializeField]
  [Tooltip("対応するアイテム")]
  ItemType _keyItem = ItemType.Empty;

  [SerializeField]
  string _stay = "黒い影が通せんぼしてる";

  [SerializeField]
  string _dead = "お札が黒い影を消した";

  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }

    PlayerState.instance.Translate(other.transform.position);

    // TIPS: 消滅判定＝未使用の対応アイテムを所持している
    var find = ItemManager.instance.GetItem(_keyItem);
    var isDead = (find != null ? !find.useItem : false);

    var message = (isDead ? _dead : _stay);
    WindowManager.instance.CreateMessageWindow(message, 0.5f);

    if (!isDead) { return; }
    ItemManager.instance.UseItem(_keyItem);
    StartCoroutine(_animator.DestroyEnemy());
  }
}
