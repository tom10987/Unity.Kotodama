
using UnityEngine;

using State = EnemyMove.EnemyState;


public class PlayerDetect : MonoBehaviour {

  EnemyMove _enemy = null;
  EnemySensor _sensor = null;

  [SerializeField]
  float _unDetectTime = 3f;
  float _elapsedTime = 0f;


  void Start() {
    _enemy = FindObjectOfType<EnemyMove>();
    _sensor = FindObjectOfType<EnemySensor>();
  }

  void Update() {
    if (EnemyMove.state != State.Detect) { return; }

    _enemy.PlayerChase();
    _elapsedTime -= Time.deltaTime;

    // 範囲内ならカウンタを戻す
    if (IsPlayerInRange()) { TimeSetup(); }

    // 時間切れじゃなければスキップ
    if (_elapsedTime > 0f) { return; }

    _enemy.PlayerLost();
  }

  void TimeSetup() { _elapsedTime = _unDetectTime; }

  bool IsPlayerInRange() {
    var player = _enemy.GetPlayerTransform();
    var distance = transform.position - player.position;
    return distance.magnitude < _sensor.detectRange;
  }

  public void OnTriggerEnter(Collider other) {
    if (other.tag != "Player") { return; }
    _enemy.PlayerDetection();
    TimeSetup();
  }
}
