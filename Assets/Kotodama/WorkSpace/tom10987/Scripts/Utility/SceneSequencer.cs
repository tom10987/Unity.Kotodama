
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

  [SerializeField, Tooltip("次のシーンの名前")]
  string _nextScene = null;

  [SerializeField, Tooltip("シーンの遷移時間（単位：秒）")]
  float _fadeTime = 1f;

  float elapsedTime {
    get { return Time.deltaTime / _fadeTime; }
  }

  public SceneState sceneState { get; private set; }

  float _screenAlpha = 1f;
  SpriteRenderer _renderer = null;

  Sequence _sequence = null;


  /// <summary>
  /// シーンをフェードアウトさせながら終了する
  /// </summary>
  public void SceneFinish() {
    if (sceneState != SceneState.Update) { return; }
    sceneState = SceneState.FadeOut;
  }

  /// <summary>
  /// 次のシーンを指定、シーンをフェードアウトさせながら終了する
  /// </summary>
  public void SceneFinish(string nextSceneName) {
    if (sceneState != SceneState.Update) { return; }
    _nextScene = nextSceneName;
    sceneState = SceneState.FadeOut;
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
  }

  void Update() {
    ApplicationFinish();
    Debug.Log(sceneState);

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
