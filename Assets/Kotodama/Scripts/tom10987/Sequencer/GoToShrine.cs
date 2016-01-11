
using UnityEngine;


public class GoToShrine : MonoBehaviour {

  [SerializeField]
  Vector3 _startPosition = Vector3.zero;


  void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }
    GameManager.instance.playerStartPosition = _startPosition;
    PlayerState.instance.Stop();
    SceneSequencer.instance.SceneFinish(SceneTag.Shrine.ToString());
  }
}
