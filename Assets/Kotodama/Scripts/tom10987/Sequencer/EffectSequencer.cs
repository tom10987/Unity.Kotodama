
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
    Finish,

    None = -1,
  }

  EffectState state { get; set; }
  Dictionary<EffectState, Action> _sequence = null;

  [SerializeField]
  [Tooltip("シーンの遷移時間（単位：秒）")]
  float _fadeTime = 1f;

  /// <summary> シーンの遷移時間 </summary>
  public float fadeTime {
    get { return _fadeTime; }
    set {
      // TIPS: 内部で除算を利用、かつプラスマイナス反転があるので、0 以下を無視
      if (value <= 0f) { return; }
      _fadeTime = value;
    }
  }

  float _screenAlpha = 1f;
  Image _image = null;

  UnityAction _sequenceAction = null;


  //------------------------------------------------------------
  // public method

  /// <summary> フェードアウト開始 </summary>
  public bool FadeOutStart() {
    if (IsFadeTime()) { return false; }
    state = EffectState.FadeOut;
    return true;
  }

  /// <summary> フェードイン開始 </summary>
  public bool FadeInStart() {
    if (!IsFadeFinish()) { return false; }
    state = EffectState.FadeIn;
    return true;
  }

  /// <summary> 自動シーケンスによるフェードアウト開始 </summary>
  public void AutoFadeStart(UnityAction sequence) {
    // TIPS: フェードアウト開始に成功したらシーケンスを登録する
    if (FadeOutStart()) { _sequenceAction = sequence; }
  }

  /// <summary> シーン切り替え演出中なら true を返す </summary>
  public bool IsFadeTime() { return state != EffectState.Update; }

  /// <summary> シーン切り替え演出が終了していたら true を返す </summary>
  public bool IsFadeFinish() { return state == EffectState.Finish; }


  //------------------------------------------------------------
  // Effect Action

  void Fadein() {
    FilterUpdate(-ElapsedTime());
    if (_screenAlpha <= 0f) { state = EffectState.Update; }
  }

  void FadeOut() {
    FilterUpdate(ElapsedTime());
    if (_screenAlpha < 1f) { return; }

    state = EffectState.Finish;

    // TIPS: AutoFadeStart() でシーケンス登録されていれば、自動的にフェードイン開始
    if (_sequenceAction != null) {
      FadeInStart();
      _sequenceAction();
      _sequenceAction = null;
    }
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

  void Update() {
    var enableState = _sequence.ContainsKey(state);
    if (enableState) { _sequence[state](); }
  }
}
