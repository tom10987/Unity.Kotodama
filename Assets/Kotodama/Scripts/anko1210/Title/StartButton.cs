
using UnityEngine;


public class StartButton : MonoBehaviour {

  SceneSequencer sequencer { get { return SceneSequencer.instance; } }
  public void TouchStart() { sequencer.SceneFinish(SceneTag.prologue); }
}
