
using UnityEngine;

/// <summary> 敵キャラに設定、プレイヤーと衝突判定を行う </summary>
public class PlayerKill : MonoBehaviour {

  public void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.Equal(other.tag)) { return; }

    var enemy = GetComponentInParent<NavMeshAgent>();
    enemy.SetDestination(enemy.transform.position);
    enemy.velocity = Vector3.zero;
  }
}
