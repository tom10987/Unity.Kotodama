
using UnityEngine;
using System.Collections;

public class PlayerMove : AbstractPlayer {

  [SerializeField]
  LayerMask _moveLayer;

  NavMeshAgent agent { get { return PlayerState.instance.agent; } }

  public override IEnumerator UpdateComponent() {
    var hit = new RaycastHit();

    System.Action Move = () => {
      if (!IsRaycastHit(out hit)) { return; }

      // TIPS:
      // 最初のレイが当たった位置に向けてプレイヤーからレイを飛ばし、障害物を確認する
      // 障害物を挟んで反対側にある移動エリアに向かって移動しないようにする
      var ray = new Ray(transform.position, hit.point - transform.position);
      Physics.Raycast(ray, out hit);
      agent.SetDestination(hit.point);
    };

    while (PlayerState.instance.isPlaying) {
      if (TouchController.IsTouchMoved()) { Move(); }
      yield return null;
    }
  }

  // TIPS: 移動可能な範囲にのみ反応するレイを飛ばす
  bool IsRaycastHit(out RaycastHit hit) {
    return TouchController.IsRaycastHitWithLayer(out hit, _moveLayer);
  }
}
