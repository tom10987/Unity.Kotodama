
using UnityEngine;

public class GameOverButton : MonoBehaviour {

  public void OnRetry() {
    var game = GameManager.instance;
    System.Action Retry = () => { game.current.ChangeScene(); };
    ChangeScene(Retry);
  }

  public void OnGoTitle() {
    System.Action GoToTitle = () => { GameScene.Title.ChangeScene(); };
    ChangeScene(GoToTitle);
  }

  void ChangeScene(System.Action action) {
    var sequencer = ScreenSequencer.instance;
    sequencer.SequenceStart(action, new Fade(3f));
  }

  public void OnQuit() {
    Application.Quit();
  }
}
