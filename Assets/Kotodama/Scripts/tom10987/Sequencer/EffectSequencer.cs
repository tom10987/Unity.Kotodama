
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;


public class EffectSequencer : SingletonBehaviour<EffectSequencer> {

  enum EffectState {
    FadeIn,
    Update,
    FadeOut,
    Finish,

    None = -1,
  }

  EffectState state { get; set; }
  Dictionary<EffectState, Action> _sequence = null;

  [SerializeField]
  [Tooltip("シーンの遷移時間（単位：秒）")]
  float _fadeTime = 1f;
  float elapsedTime { get { return Time.deltaTime / _fadeTime; } }

  float _screenAlpha = 1f;
  Image _image = null;


  //------------------------------------------------------------
  // public method

  /// <summary>
  /// フェードアウト開始
  /// </summary>
  public void FadeOutStart() {
    if (IsFadeTime()) { return; }
    state = EffectState.FadeOut;
  }

  /// <summary>
  /// フェードイン開始
  /// </summary>
  public void FadeInStart() {
    if (!IsFadeFinish()) { return; }
    state = EffectState.FadeIn;
  }

  /// <summary>
  /// シーン切り替え演出中なら true を返す
  /// </summary>
  public bool IsFadeTime() { return state != EffectState.Update; }

  /// <summary>
  /// シーン切り替え演出が終了していたら true を返す
  /// </summary>
  public bool IsFadeFinish() { return state == EffectState.Finish; }


  //------------------------------------------------------------
  // Effect Action

  void Fadein() {
    FilterUpdate(-elapsedTime);
    if (_screenAlpha <= 0f) { state = EffectState.Update; }
  }

  void FadeOut() {
    FilterUpdate(elapsedTime);
    if (_screenAlpha >= 1f) { state = EffectState.Finish; }
  }

  void FilterUpdate(float value) {
    _screenAlpha += value;
    _image.color = Color.black * _screenAlpha;
  }


  //------------------------------------------------------------
  // Behaviour

  protected override void Awake() {
    base.Awake();

    state = EffectState.FadeIn;
    _screenAlpha = 1f;

    _sequence = new Dictionary<EffectState, Action>();
    _sequence.Add(EffectState.FadeIn, Fadein);
    _sequence.Add(EffectState.FadeOut, FadeOut);
  }

  void Start() {
    _image = GetComponent<Image>();
    _image.color = Color.black;
  }

  void Update() {
    var enableState = _sequence.ContainsKey(state);
    if (enableState) { _sequence[state](); }
  }
}
