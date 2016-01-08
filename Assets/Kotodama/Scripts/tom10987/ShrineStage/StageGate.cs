
using UnityEngine;


public class StageGate : MonoBehaviour {

  // TODO: SceneTag 仕様変更に対応させる
  enum Stage {
    PublicPhone,
    ManHole,
    Labyrinth,

    Max,
    None = -1,
  }

  [SerializeField]
  Stage _stage = Stage.None;

  [SerializeField]
  GameState _activateState = GameState.None;

  [SerializeField]
  GameObject _gateObject = null;


  void Start() {
    //var isActivate_ = (_activateState == GameManager.instance.state);
    //_gateObject.SetActive(!isActivate_);
  }

  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.player) { return; }
    SceneSequencer.instance.SceneFinish(_stage.ToString());
  }
}
