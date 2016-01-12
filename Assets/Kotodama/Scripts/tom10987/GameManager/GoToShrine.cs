
using UnityEngine;


public class GoToShrine : MonoBehaviour {

  EnemyManager enemy { get { return EnemyManager.instance; } }

  [SerializeField]
  [Tooltip("神社エリアの開始地点を設定")]
  Vector3 _startPosition = Vector3.zero;


  void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }

    // TIPS: プレイヤーを停止、神社エリアのスタート地点を設定
    PlayerState.instance.Stop();
    GameManager.instance.playerStartPosition = _startPosition;

    // TIPS: 敵キャラがいれば、動作を停止する
    if (enemy != null) { enemy.SwitchEnemiesState(false); }

    SceneSequencer.instance.SceneFinish(SceneTag.Shrine.ToString());
  }
}
