
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {

  public bool isPause { get; private set; }
  public Vector3 playerStartPosition { get; set; }

  public void Pause() {
    isPause = true;
    PlayerState.instance.Stop();
    //if (enemy != null) { enemy.SwitchEnemiesState(); }
  }

  public void ReStart() {
    isPause = false;
    PlayerState.instance.Play();
    //if (enemy != null) { enemy.SwitchEnemiesState(); }
  }

  public void Initialize() {
    isPause = false;
    playerStartPosition = Vector3.zero;
  }

  //TODO:チャプター選択の結果ごとに初期化
  //TODO:つづきから選択時の処理と状態管理
}
