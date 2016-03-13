
using UnityEngine;

/// <summary> 敵キャラに設定、プレイヤーと衝突判定を行う </summary>
public class PlayerKill : MonoBehaviour {

  [SerializeField]
  GameObject _gameOver = null;

  public void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }
    GameManager.instance.Pause();
    Instantiate(_gameOver);

    //TODO:エフェクト演出
  }
}
