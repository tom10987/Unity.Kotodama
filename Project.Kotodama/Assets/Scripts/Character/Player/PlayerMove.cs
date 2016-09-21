
using UnityEngine;
using System.Collections;

public class PlayerMove : PlayerComponent {

  [SerializeField]
  [Tooltip("レイキャスト判定の対象レイヤー")]
  LayerMask _targetLayer;

  [SerializeField, Range(0f, 1f)]
  [Tooltip("移動速度がこの値以下の時、タッチ終了した場所に自動で移動する")]
  float _autoMove = 0.5f;

  NavMeshAgent agent { get { return PlayerState.instance.agent; } }

  protected override IEnumerator UpdateComponent() {
    var hit = new RaycastHit();

    System.Action Moved = () => {
      if (!IsRaycastHit(out hit)) { return; }

      // TIPS:
      // 最初のレイが当たった位置に向けてプレイヤーからレイを飛ばし、障害物を確認する
      // 障害物を挟んで反対側にある移動エリアに向かって移動しないようにする
      var ray = new Ray(transform.position, hit.point - transform.position);
      Physics.Raycast(ray, out hit);
      agent.SetDestination(hit.point);
    };

    System.Action Point = () => {
      if (!IsRaycastHit(out hit)) { return; }
      agent.SetDestination(hit.point);
    };

    while (PlayerState.instance.isPlaying) {
      if (TouchController.IsTouchMoved()) { Moved(); }
      if (IsAutoMove()) { Point(); }
      yield return null;
    }
  }

  // TIPS: 一定以下の移動速度 かつ 壁にぶつかってなければ true を返す
  bool IsAutoMove() {
    var isTouchEnded = TouchController.IsTouchEnded();
    var enableAutoMove = agent.velocity.magnitude < _autoMove;
    return isTouchEnded && enableAutoMove;
  }

  // TIPS: 移動可能な範囲にのみ反応するレイを飛ばす
  bool IsRaycastHit(out RaycastHit hit) {
    var result = TouchController.IsRaycastHitWithLayer(out hit, _targetLayer);
    return result && !IsHitPlayer(hit);
  }

  // TIPS: レイ判定の結果、プレイヤーだったら移動停止
  bool IsHitPlayer(RaycastHit hit) {
    var result = ObjectTag.Player.EqualTo(hit.transform.tag);
    if (result) { agent.SetDestination(transform.position); }
    return result;
  }
}
