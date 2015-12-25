
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSequencer : SingletonBehaviour<SceneSequencer> {

  EffectSequencer effect { get { return EffectSequencer.instance; } }

  [SerializeField]
  [Tooltip("シーン切り替えの演出時間（単位：秒）")]
  float _fadeSpeed = 1f;

  string _nextScene = string.Empty;
  public bool isSceneFinish { get; private set; }


  /// <summary> シーンをフェードアウトさせながら終了する </summary>
  public void SceneFinish(string nextSceneName) {
    if (effect.IsFadeTime()) { return; }
    _nextScene = nextSceneName;
    isSceneFinish = true;
    effect.FadeStart(LoadNextScene, _fadeSpeed);
  }

  void LoadNextScene() {
    isSceneFinish = false;
    SceneManager.LoadScene(_nextScene);
  }


  //------------------------------------------------------------
  // Behaviour

  protected override void Awake() {
    base.Awake();
    isSceneFinish = false;
  }

  void Update() {
    if (TouchController.IsPushedQuitKey()) { Application.Quit(); }
  }
}
