
using UnityEngine;

public class PlayerState : SingletonBehaviour<PlayerState> {

  [SerializeField]
  NavMeshAgent _agent = null;
  public NavMeshAgent agent { get { return _agent; } }

  [SerializeField]
  PlayerComponent[] _components = null;

  /// <summary> プレイヤーが動作中なら true を返す </summary>
  public bool isPlaying { get; private set; }

  /// <summary> ランプを持ってるかどうかを指定する </summary>
  public bool hasLantern { get; set; }

  /// <summary> プレイヤー動作開始 </summary>
  public void Play() {
    isPlaying = true;
    foreach (var component in _components) { component.Activate(); }
    Translate(transform.position);
  }

  /// <summary> プレイヤーの動作を停止する </summary>
  public void Stop() {
    isPlaying = false;
    Translate(transform.position);
  }

  /// <summary> プレイヤーを指定した座標に向けて移動させる </summary>
  public void Translate(Vector3 position) { _agent.SetDestination(position); }

  void Start() {
    CameraController.instance.target = transform;
    hasLantern = false;
    Play();
  }
}
