
using UnityEngine;
using UnityEngine.UI;

using Sequence = System.Collections.Generic.
  Dictionary<ScreenEffect.SceneState, System.Action>;


public class ScreenEffect : MonoBehaviour {

  public enum SceneState {
    FadeIn,
    Update,
    FadeOut,
    Finish,

    None = -1,
  }

  static public SceneState sceneState { get; private set; }

  Sequence _sequence = null;

  [SerializeField]
  [Tooltip("シーンの遷移時間（単位：秒）")]
  float _fadeTime = 1f;
  float elapsedTime { get { return Time.deltaTime / _fadeTime; } }

  float _screenAlpha = 1f;
  Image _image = null;


  /// <summary>
  /// フェードアウト開始
  /// </summary>
  public void FadeOutStart() {
    if (sceneState != SceneState.Update) { return; }
    sceneState = SceneState.FadeOut;
  }

  /// <summary>
  /// フェードイン開始
  /// </summary>
  public void FadeInStart() {
    if (sceneState != SceneState.Finish) { return; }
    sceneState = SceneState.FadeOut;
  }

  /// <summary>
  /// シーン切り替え演出中なら true を返す
  /// </summary>
  public bool IsFadeTime() { return sceneState != SceneState.Update; }

  /// <summary>
  /// シーン切り替え演出が終了していたら true を返す
  /// </summary>
  public bool IsFadeFinish() { return sceneState == SceneState.Finish; }


  void Awake() {
    sceneState = SceneState.FadeIn;
    _screenAlpha = 1f;

    _sequence = new Sequence();
    _sequence.Add(SceneState.FadeIn, Fadein);
    _sequence.Add(SceneState.FadeOut, FadeOut);
  }

  void Start() {
    _image = GetComponent<Image>();
    _image.color = Color.black;
  }

  void Update() {
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
      _image.color = Color.black * _screenAlpha;
      return;
    }

    sceneState = SceneState.Update;
  }

  void FadeOut() {
    if (_screenAlpha < 1f) {
      _screenAlpha += elapsedTime;
      _image.color = Color.black * _screenAlpha;
      return;
    }

    sceneState = SceneState.Finish;
  }
}
