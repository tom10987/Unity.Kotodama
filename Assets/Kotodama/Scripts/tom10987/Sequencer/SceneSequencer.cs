
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

  protected override void Awake() {
    base.Awake();
    isSceneFinish = false;
    DontDestroyOnLoad(gameObject);
  }

  void Update() {
    // TODO: 戻るボタンを押した時に、ゲーム終了するか確認するようにする
    if (TouchController.IsPushedQuitKey()) { Application.Quit(); }
  }
}
