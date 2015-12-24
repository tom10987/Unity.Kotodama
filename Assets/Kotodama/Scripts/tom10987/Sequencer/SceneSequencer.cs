
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSequencer : SingletonBehaviour<SceneSequencer> {

  EffectSequencer effect { get { return EffectSequencer.instance; } }

  bool _isFinish = false;
  string _nextScene = string.Empty;


  /// <summary>
  /// シーンをフェードアウトさせながら終了する
  /// </summary>
  public void SceneFinish(string nextSceneName) {
    if (effect.IsFadeTime()) { return; }
    _isFinish = true;
    _nextScene = nextSceneName;
    effect.FadeOutStart();
  }


  protected override void Awake() { base.Awake(); }

  void Update() {
    if (TouchController.IsPushedQuitKey()) { Application.Quit(); }
    if (!effect.IsFadeFinish() && !_isFinish) { return; }

    _isFinish = false;
    SceneManager.LoadScene(_nextScene);
  }
}
