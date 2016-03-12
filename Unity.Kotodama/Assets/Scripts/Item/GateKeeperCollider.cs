
using UnityEngine;
using System.Collections;

public class GateKeeperCollider : MonoBehaviour {

  [SerializeField]
  SpriteRenderer _renderer = null;

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

    // TIPS: 対応アイテムを所持していれば、自身を消滅させる
    var find = ItemManager.instance.GetItem(_keyItem);
    var success = (find != null ? !find.useItem : false);
    StartCoroutine(success ? DestroyEnemy() : AliveEnemy());
  }

  IEnumerator AliveEnemy() {
    //TODO:メッセージ表示
    yield return null;
  }

  IEnumerator DestroyEnemy() {
    ItemManager.instance.UseItem(_keyItem);

    //TODO:メッセージ表示

    var alpha = 0f;
    while (alpha < 1f) {
      alpha += Time.deltaTime;
      _renderer.color *= (1f - alpha);
      yield return null;
    }

    Destroy(gameObject);
  }
}
