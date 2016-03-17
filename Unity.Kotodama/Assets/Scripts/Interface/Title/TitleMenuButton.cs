
using UnityEngine;

public class TitleMenuButton : MonoBehaviour {

  [SerializeField]
  [Range(0.1f, 10f)]
  float _speed = 1f;

  [SerializeField]
  GameScene _tag = GameScene.None;

  public void OnChangeScene() {
    var sequencer = ScreenSequencer.instance;
    System.Action ChangeScene = () => { _tag.ChangeScene(); };
    sequencer.SequenceStart(ChangeScene, new Fade(_speed));
  }
}
