
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary> 敵キャラに設定、プレイヤーと衝突判定を行う </summary>
public class PlayerKill : MonoBehaviour {

  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }

    other.GetComponent<Rigidbody>().velocity = Vector3.zero;

    var enemy = GetComponentInParent<NavMeshAgent>();
    enemy.SetDestination(enemy.transform.position);
    enemy.velocity = Vector3.zero;

    // TIPS: すでに演出中なら処理をスキップ
    if (SceneSequencer.instance.isSceneFinish) { return; }
    SceneSequencer.instance.SceneFinish(SceneManager.GetActiveScene().name);
  }
}
