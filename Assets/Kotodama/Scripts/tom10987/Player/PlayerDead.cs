
using UnityEngine;


public class PlayerDead : MonoBehaviour {

  public void OnTriggerEnter(Collider collision) {
    if (collision.gameObject.tag != "Player") { return; }

    FindObjectOfType<SceneSequencer>().SceneFinish("Epilogue");
    collision.GetComponent<Rigidbody>().velocity = Vector3.zero;

    var enemy = GetComponentInParent<NavMeshAgent>();
    enemy.SetDestination(enemy.transform.position);
    enemy.velocity = Vector3.zero;
  }
}
