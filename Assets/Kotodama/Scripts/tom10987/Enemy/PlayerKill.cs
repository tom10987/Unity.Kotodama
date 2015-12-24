
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerKill : MonoBehaviour {

  SceneSequencer sequencer { get { return SceneSequencer.instance; } }

  // TIPS: プレイヤーがトリガーに触れたらステージの最初に戻す
  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.player) { return; }

    other.GetComponent<Rigidbody>().velocity = Vector3.zero;

    var enemy = GetComponentInParent<NavMeshAgent>();
    enemy.SetDestination(enemy.transform.position);
    enemy.velocity = Vector3.zero;

    sequencer.SceneFinish(SceneManager.GetActiveScene().name);
  }
}
