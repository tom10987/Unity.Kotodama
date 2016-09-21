
using System;
using System.Collections;

//------------------------------------------------------------
// TIPS:
// 画面遷移の演出処理を行う抽象クラス
//
// bool IsPlaying()
// 現在、演出の実行中かどうかを返す処理を実装します
//
// IEnumerator Sequence(Action)
// 演出中の任意のタイミングで action を実行する遷移処理を実装します
//
//------------------------------------------------------------

public abstract class Effect {
  protected static ScreenSequencer sequencer { get { return ScreenSequencer.instance; } }

  public abstract bool IsPlaying();
  public abstract IEnumerator Sequence(Action action);
}
