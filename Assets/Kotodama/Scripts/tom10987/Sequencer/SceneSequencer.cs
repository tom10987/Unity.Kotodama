
using UnityEngine;


public class SceneSequencer : SingletonBehaviour<SceneSequencer> {

  [SerializeField]
  [Tooltip("次のシーンの名前")]
  string _nextScene = null;

  EffectSequencer effect { get { return EffectSequencer.instance; } }


  /// <summary>
  /// シーンをフェードアウトさせながら終了する
  /// </summary>
  public void SceneFinish(string nextSceneName = null) {
    if (effect.IsFadeTime()) { return; }
    if (nextSceneName != null) { _nextScene = nextSceneName; }
    effect.FadeOutStart();
  }


  protected override void Awake() { base.Awake(); }

  void Update() {
    if (TouchController.IsPushedQuitKey()) { Application.Quit(); }
    if (!effect.IsFadeFinish()) { return; }
    Application.LoadLevel(_nextScene);
  }
}
