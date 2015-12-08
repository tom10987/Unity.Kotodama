
using UnityEngine;


public class TitleManager : MonoBehaviour {

  static public bool isSelect { get; private set; }
  static public float buttonAlpha { get; private set; }

  public bool effectPlaying { get { return buttonAlpha > 0f; } }

  SceneSequencer sequencer { get { return SceneSequencer.instance; } }


  void Awake() {
    isSelect = false;
    buttonAlpha = 1f;
  }

  void Update() {
    //if (!isSelect) { return; }
    if (buttonAlpha > 0f) { buttonAlpha -= Time.deltaTime; }
  }


  public void TouchStart() {
    //isSelect = true;
    //if (effectPlaying) { return; }
    sequencer.SceneFinish(SceneTag.prologue);
  }

  /////
  /// 以下演出
  ///
  /////

}
