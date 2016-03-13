
public class GameManager : SingletonBehaviour<GameManager> {

  public void Pause() {
    PlayerState.instance.Stop();
    EnemyManager.instance.ActivateActors();
  }

  public void ReStart() {
    PlayerState.instance.Play();
    EnemyManager.instance.Pause();
  }

  //TODO:チャプター選択の結果ごとに初期化
  //TODO:つづきから選択時の処理と状態管理
}
