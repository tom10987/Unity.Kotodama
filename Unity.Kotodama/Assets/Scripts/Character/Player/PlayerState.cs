
using UnityEngine;

public class PlayerState : SingletonBehaviour<PlayerState> {

  [SerializeField]
  [Range(1f, 10f)]
  float _moveSpeed = 3f;

  [SerializeField]
  [Range(0f, 2f)]
  [Tooltip("キャラクターに対するタッチ判定の大きさ")]
  float _touchRadius = 0.5f;

  Vector3 _direction = Vector3.zero;

  [SerializeField]
  Rigidbody _ownRigid = null;

  [SerializeField]
  PlayerAnimator _animator = null;

  public void Move() {
    _ownRigid.velocity = Vector3.zero;
    // if (EffectSequencer.instance.IsFadeTime()) { return; }

    var touchPos = TouchController.GetScreenToWorldPositionXZ();
    if (touchPos.magnitude < _touchRadius) { return; }

    // TIPS: 画面が横長なので、アスペクト比で割る
    touchPos.x /= Camera.main.aspect;
    _direction = touchPos.normalized * _moveSpeed;
    _ownRigid.AddForce(_direction, ForceMode.Impulse);
    _animator.UpdateDirection(_direction);
  }

  public void Stop() {
    _ownRigid.velocity = Vector3.zero;
    _animator.StopAnimation();
  }

  public void ChangeSpriteState() {
    _animator.ChangeSpriteState();
  }

  void Start() {
    if (_ownRigid == null) { _ownRigid = GetComponent<Rigidbody>(); }
    if (_animator == null) { _animator = GetComponentInChildren<PlayerAnimator>(); }
    CameraController.instance.ChaseTarget(transform);
  }

  void Update() {
    if (_ownRigid.velocity.magnitude > 0f) { _animator.UpdateAnimation(); }
  }
}
