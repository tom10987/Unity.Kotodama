
using UnityEngine;


public class MGoal : MonoBehaviour {

  SceneSequencer sequencer { get { return SceneSequencer.instance; } }
  PlayerState state { get { return PlayerState.instance; } }
  PopUpCanvas pop { get { return PopUpCanvas.instance; } }

  void OnCollisionEnter() {
    state.Stop();
    pop.CreatePopUpWindowVerGimmick("神社へ戻りますか？", IsEnd);
  }

  public void IsEnd() {
    pop._isChoice = true;
    sequencer.SceneFinish(SceneTag.shrine);
  }
}
