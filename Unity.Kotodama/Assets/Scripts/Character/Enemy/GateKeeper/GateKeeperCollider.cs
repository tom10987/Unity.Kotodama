
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

  [SerializeField]
  [Range(0.5f, 2.0f)]
  float _messageTime = 1.0f;

  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }

    // TIPS: プレイヤーの移動停止
    PlayerState.instance.Translate(other.transform.position);

    // TIPS: 消滅判定＝プレイヤーが、未使用の対応アイテムを所持している
    var find = ItemManager.instance.GetItem(_keyItem);
    var isDead = (find != null ? !find.useItem : false);

    var message = (isDead ? _dead : _stay);
    WindowManager.instance.CreateMessageWindow(message, _messageTime);

    if (!isDead) { return; }
    ItemManager.instance.UseItem(_keyItem);
    StartCoroutine(_animator.DestroyEnemy());
  }
}
