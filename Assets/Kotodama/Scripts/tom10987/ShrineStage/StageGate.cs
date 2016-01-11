
using UnityEngine;


public class StageGate : MonoBehaviour {

  [SerializeField]
  SceneTag _sceneName = SceneTag.Title;

  [SerializeField]
  GameState _activateState = GameState.None;

  [SerializeField]
  GameObject _gateObject = null;


  void Start() {
    //var isActivate_ = (_activateState == GameManager.instance.state);
    //_gateObject.SetActive(!isActivate_);
  }

  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }
    SceneSequencer.instance.SceneFinish(_sceneName.ToString());
  }
}
