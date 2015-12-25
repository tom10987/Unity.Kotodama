
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections.Generic;


public class EffectSequencer : SingletonBehaviour<EffectSequencer> {

  enum EffectState {
    FadeIn,
    Update,
    FadeOut,

    None = -1,
  }

  EffectState state { get; set; }
  Dictionary<EffectState, Action> _sequence = null;

  float _fadeTime = 1f;
  UnityAction _sequenceAction = null;

  float _screenAlpha = 1f;
  Image _image = null;


  //------------------------------------------------------------
  // public method

  /// <summary> 自動シーケンスによるフェードアウト開始 </summary>
  public void FadeStart(UnityAction action, float time) {
    if (IsFadeTime()) { return; }
    state = EffectState.FadeOut;
    _fadeTime = time;
    _sequenceAction = action;
  }

  /// <summary> シーン切り替え演出中なら true を返す </summary>
  public bool IsFadeTime() { return state != EffectState.Update; }


  //------------------------------------------------------------
  // Effect Action

  void Fadein() {
    FilterUpdate(-ElapsedTime());
    if (_screenAlpha <= 0f) { state = EffectState.Update; }
  }

  void FadeOut() {
    FilterUpdate(ElapsedTime());
    if (_screenAlpha < 1f) { return; }

    state = EffectState.FadeIn;
    _sequenceAction();
    _sequenceAction = null;
  }

  void FilterUpdate(float value) {
    _screenAlpha += value;
    _image.color = Color.black * _screenAlpha;
  }

  float ElapsedTime() { return Time.deltaTime / _fadeTime; }


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

  // FIXME: コルーチン化できる
  void Update() {
    var enableState = _sequence.ContainsKey(state);
    if (enableState) { _sequence[state](); }
  }
}
