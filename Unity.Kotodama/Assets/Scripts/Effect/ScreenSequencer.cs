
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary> 実行したい処理を与えて画面遷移を行う </summary>
public class ScreenSequencer : SingletonBehaviour<ScreenSequencer> {

  [SerializeField]
  Image _image = null;
  public Image image { get { return _image; } }

  /// <summary> 再生したい <see cref="Effect"/> クラスを new で設定 </summary>
  public Effect effect { private get; set; }
  public bool isEffectPlaying { get { return effect.IsPlaying(); } }

  /// <summary> 画面遷移を開始 </summary>
  public void SequenceStart(Action action) {
    if (effect.IsPlaying()) { return; }
    StartCoroutine(effect.Sequence(action));
  }

  /// <summary> 実行したい <see cref="Effect"/> を指定、画面遷移を開始 </summary>
  public void SequenceStart(Action action, Effect effect) {
    this.effect = effect;
    SequenceStart(action);
  }
}
