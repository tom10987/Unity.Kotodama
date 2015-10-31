
using UnityEngine;

using Sequence = System.Collections.Generic.
  Dictionary<SceneSequencer.SceneState, System.Action>;


public class SceneSequencer : MonoBehaviour {

  public enum SceneState {
    FadeIn,
    Update,
    FadeOut,
    Finish,

    None = -1,
  }

  public SceneState sceneState { get; private set; }

  Sequence _sequence = null;

  [SerializeField]
  [Tooltip("次のシーンの名前")]
  string _nextScene = null;

  [SerializeField]
  [Tooltip("シーンの遷移時間（単位：秒）")]
  float _fadeTime = 1f;
  float elapsedTime { get { return Time.deltaTime / _fadeTime; } }

  float _screenAlpha = 1f;
  SpriteRenderer _renderer = null;


  /// <summary>
  /// シーンをフェードアウトさせながら終了する
  /// </summary>
  public void SceneFinish(string nextSceneName = null) {
    if (sceneState != SceneState.Update) { return; }
    if (nextSceneName != null) { _nextScene = nextSceneName; }
    sceneState = SceneState.FadeOut;
  }

  /// <summary>
  /// シーン切り替え演出中なら true を返す
  /// </summary>
  public bool IsFadeTime() {
    return sceneState != SceneState.Update;
  }


  void Awake() {
    sceneState = SceneState.FadeIn;
    _screenAlpha = 1f;

    _sequence = new Sequence();
    _sequence.Add(SceneState.FadeIn, Fadein);
    _sequence.Add(SceneState.FadeOut, FadeOut);
    _sequence.Add(SceneState.Finish, Finish);
  }

  void Start() {
    _renderer = GetComponent<SpriteRenderer>();
    transform.localScale = ScreenInfo.orthoAspect * 2f;
  }

  void Update() {
    Debug.Log(sceneState);
    ApplicationFinish();
    transform.position = Camera.main.transform.position;

    var enableAct = _sequence.ContainsKey(sceneState);
    if (enableAct) { _sequence[sceneState](); }
  }

  void ApplicationFinish() {
    var isQuit_ = TouchController.IsPushedQuitKey();
    if (isQuit_) { Application.Quit(); }
  }


  void Fadein() {
    if (_screenAlpha > 0f) {
      _screenAlpha -= elapsedTime;
      _renderer.color = new Color(0f, 0f, 0f, _screenAlpha);
      return;
    }

    sceneState = SceneState.Update;
  }

  void FadeOut() {
    if (_screenAlpha < 1f) {
      _screenAlpha += elapsedTime;
      _renderer.color = new Color(0f, 0f, 0f, _screenAlpha);
      return;
    }

    sceneState = SceneState.Finish;
  }

  void Finish() {
    Application.LoadLevel(_nextScene);
  }
}
