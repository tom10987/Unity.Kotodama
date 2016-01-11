
using UnityEngine;


public class StartButton : MonoBehaviour {

  public void TouchStart() {
    SceneSequencer.instance.SceneFinish(SceneTag.Tutorial.ToString());
    AudioManager.instance.bgm.Stop();
  }

  void Start() { AudioManager.instance.bgm.Play(0); }
}
