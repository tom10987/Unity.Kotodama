
using UnityEngine;

public class PlayerState : SingletonBehaviour<PlayerState> {

  [SerializeField]
  Rigidbody _rigid = null;
  public Rigidbody rigidBody { get { return _rigid; } }

  [SerializeField]
  NavMeshAgent _agent = null;
  public NavMeshAgent agent { get { return _agent; } }

  [SerializeField]
  AbstractPlayer[] _components = null;

  /// <summary> プレイヤーが動作中なら true を返す </summary>
  public bool isPlaying { get; private set; }

  /// <summary> ランプを持ってるかどうかを指定する </summary>
  public bool hasLantern { get; set; }

  /// <summary> プレイヤー動作開始 </summary>
  public void Play() {
    isPlaying = true;
    foreach (var component in _components) { component.Activate(); }
  }

  /// <summary> プレイヤーの動作を停止する </summary>
  public void Stop() { isPlaying = false; }

  /// <summary> プレイヤーを指定した座標に向けて移動させる </summary>
  public void Translate(Vector3 position) { _agent.SetDestination(position); }

  void Start() {
    CameraController.instance.ChaseTarget(transform);
    hasLantern = false;
    Play();
  }
}
