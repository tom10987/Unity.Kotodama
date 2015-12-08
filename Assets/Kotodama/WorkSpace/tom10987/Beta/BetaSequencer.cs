
using UnityEngine;


public class BetaSequencer : MonoBehaviour {

  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.player) { return; }

    other.GetComponent<Rigidbody>().velocity = Vector3.zero;
    SceneSequencer.instance.SceneFinish(SceneTag.epilogue);
  }
}
