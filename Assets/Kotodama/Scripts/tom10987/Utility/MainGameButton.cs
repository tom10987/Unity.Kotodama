
using UnityEngine;


public interface MenuAction : GoTitleAction {
  void Back(GameObject instance);
}


public interface OpenAction {
  void MenuOpen(GameObject instance);
}


public interface GameOverAction : GoTitleAction {
  void Retry(GameObject instance);
  void Quit(GameObject instance);
}


public interface GoTitleAction {
  void GoTitle(GameObject instance);
}


public class MainGameButton : SingletonBehaviour<MainGameButton>,
  MenuAction, OpenAction, GameOverAction {

  SceneSequencer sequencer { get { return SceneSequencer.instance; } }
  PlayerStatus player { get { return PlayerStatus.instance; } }


  //------------------------------------------------------------
  // button action

  public void Back(GameObject instance) {
    Destroy(instance);
    //TODO: ポーズ状態を解除する処理
  }

  public void Retry(GameObject instance) {
    Destroy(instance);
    Debug.Log("push retry button");
    //TODO: リトライ処理
  }

  public void Quit(GameObject instance) {
    Destroy(instance);
    Application.Quit();
  }

  public void GoTitle(GameObject instance) {
    Destroy(instance);
    sequencer.SceneFinish(SceneTag.title);
  }

  public void MenuOpen(GameObject instance) {
    Instantiate(instance);
    player.MoveStop();
    //TODO: ポーズ状態にする処理
  }


  //------------------------------------------------------------
  // Behaviour

  protected override void Awake() { base.Awake(); }
}
