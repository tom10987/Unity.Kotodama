
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;


public class ScreenEffect : MonoBehaviour {

  public enum SceneState {
    FadeIn,
    Update,
    FadeOut,
    Finish,

    None = -1,
  }

  static public SceneState sceneState { get; private set; }

  Dictionary<SceneState, Action> _sequence = null;

  [SerializeField]
  [Tooltip("シーンの遷移時間（単位：秒）")]
  float _fadeTime = 1f;
  float elapsedTime { get { return Time.deltaTime / _fadeTime; } }

  float _screenAlpha = 1f;
  Image _image = null;


  /// <summary>
  /// フェードアウト開始
  /// </summary>
  static public void FadeOutStart() {
    if (IsFadeTime()) { return; }
    sceneState = SceneState.FadeOut;
  }

  /// <summary>
  /// フェードイン開始
  /// </summary>
  static public void FadeInStart() {
    if (!IsFadeFinish()) { return; }
    sceneState = SceneState.FadeIn;
  }

  /// <summary>
  /// シーン切り替え演出中なら true を返す
  /// </summary>
  static public bool IsFadeTime() { return sceneState != SceneState.Update; }

  /// <summary>
  /// シーン切り替え演出が終了していたら true を返す
  /// </summary>
  static public bool IsFadeFinish() { return sceneState == SceneState.Finish; }


  void Awake() {
    sceneState = SceneState.FadeIn;
    _screenAlpha = 1f;

    _sequence = new Dictionary<SceneState, Action>();
    _sequence.Add(SceneState.FadeIn, Fadein);
    _sequence.Add(SceneState.FadeOut, FadeOut);
  }

  void Start() {
    _image = GetComponent<Image>();
    _image.color = Color.black;
  }

  void Update() {
    var enableAct_ = _sequence.ContainsKey(sceneState);
    if (enableAct_) { _sequence[sceneState](); }
  }

  void ApplicationFinish() {
    var isQuit_ = TouchController.IsPushedQuitKey();
    if (isQuit_) { Application.Quit(); }
  }


  void Fadein() {
    FilterUpdate(-elapsedTime);
    if (_screenAlpha <= 0f) { sceneState = SceneState.Update; }
  }

  void FadeOut() {
    FilterUpdate(elapsedTime);
    if (_screenAlpha >= 1f) { sceneState = SceneState.Finish; }
  }

  void FilterUpdate(float value) {
    _screenAlpha += value;
    _image.color = Color.black * _screenAlpha;
  }
}
