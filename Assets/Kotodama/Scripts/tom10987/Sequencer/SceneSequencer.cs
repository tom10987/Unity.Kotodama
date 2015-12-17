
using UnityEngine;


public class SceneSequencer : SingletonBehaviour<SceneSequencer> {

  string nextScene { get; set; }
  EffectSequencer effect { get { return EffectSequencer.instance; } }


  /// <summary>
  /// シーンをフェードアウトさせながら終了する
  /// </summary>
  public void SceneFinish(string nextSceneName) {
    if (effect.IsFadeTime()) { return; }
    nextScene = nextSceneName;
    effect.FadeOutStart();
  }


  protected override void Awake() { base.Awake(); }

  void Update() {
    if (TouchController.IsPushedQuitKey()) { Application.Quit(); }
    if (!effect.IsFadeFinish()) { return; }
    Application.LoadLevel(nextScene);
  }
}
