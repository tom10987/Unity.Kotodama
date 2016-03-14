
using UnityEngine;

public class GameOverButton : MonoBehaviour {

  public void OnRetry() {
    OnGoTitle();
  }

  public void OnGoTitle() {
    var sequencer = ScreenSequencer.instance;
    System.Action ChangeScene = () => { SceneTag.Title.ChangeScene(); };
    sequencer.SequenceStart(ChangeScene, new Fade(3f));
  }

  public void OnQuit() {
    Application.Quit();
  }
}
