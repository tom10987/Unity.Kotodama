
using UnityEngine;

using State = EnemyMove.EnemyState;


public class PlayerAlert : MonoBehaviour {

  EnemyMove _enemy = null;
  EnemySensor _sensor = null;

  [SerializeField]
  float _unAlertTime = 3f;
  float _elapsedTime = 0f;


  void Start() {
    _enemy = FindObjectOfType<EnemyMove>();
    _sensor = FindObjectOfType<EnemySensor>();
  }

  void Update() {
    if (EnemyMove.state != State.Alert) { return; }

    if (_enemy.IsArrived()) { _enemy.PlayerChase(); }
    _elapsedTime -= Time.deltaTime;

    // 範囲内ならカウンタを戻してやり直す
    if (IsPlayerInRange()) { TimeSetup(); return; }

    // 範囲外かつ時間切れならプレイヤーを見失う
    if (_elapsedTime <= 0f) { _enemy.PlayerLost(); }
  }

  void TimeSetup() {
    _elapsedTime = _unAlertTime;
  }

  bool IsPlayerInRange() {
    var player = _enemy.GetPlayerTransform();
    var distance = transform.position - player.position;
    return distance.magnitude < _sensor.alertRange;
  }

  public void OnTriggerEnter(Collider other) {
    if (other.tag != "Player") { return; }
    _enemy.PlayerAlert();
    TimeSetup();
  }
}
