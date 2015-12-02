
using UnityEngine;


public class PlayerKill : MonoBehaviour {

  // TODO: ゲームオーバー演出が始まるようにする
  public void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag != ObjectTag.player) { return; }

    FindObjectOfType<SceneSequencer>().SceneFinish(SceneTag.epilogue);
    other.GetComponent<Rigidbody>().velocity = Vector3.zero;

    var enemy = GetComponentInParent<NavMeshAgent>();
    enemy.SetDestination(enemy.transform.position);
    enemy.velocity = Vector3.zero;
  }
}
