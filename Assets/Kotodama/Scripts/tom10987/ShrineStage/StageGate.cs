
using UnityEngine;


public class StageGate : MonoBehaviour {

  [SerializeField]
  SceneTag _sceneName = SceneTag.Title;

  [SerializeField]
  GameState _activeState = GameState.Start;

  [SerializeField]
  GameObject _gateObject = null;


  void Start() {
    //_gateObject.SetActive(_activeState == GameManager.instance.state);
  }

  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }
    SceneSequencer.instance.SceneFinish(_sceneName.ToString());
  }
}
