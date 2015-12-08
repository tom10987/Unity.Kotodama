
using UnityEngine;


public class PlayerStatus : SingletonBehaviour<PlayerStatus> {

  [SerializeField]
  [Range(1f, 10f)]
  float _moveSpeed = 3f;

  [SerializeField]
  [Range(0f, 2f)]
  [Tooltip("キャラクターに対するタッチ判定の大きさ")]
  float _touchRadius = 0.5f;

  Vector3 _direction = Vector3.zero;
  Rigidbody _ownRigid = null;

  PlayerAnimator _animator = null;


  public void MoveStart() {
    _ownRigid.velocity = Vector3.zero;

    var touchPos = TouchController.GetTouchWorldPositionXZ();
    if (touchPos.magnitude < _touchRadius) { return; }

    _direction = touchPos.normalized * _moveSpeed;
    _ownRigid.AddForce(_direction, ForceMode.Impulse);
  }

  public void MoveStop() {
    _ownRigid.velocity = Vector3.zero;
  }

  public void SpriteState(PlayerSpriteState newState) {
    _animator.SetSpriteState(newState);
  }


  void Start() {
    _ownRigid = GetComponent<Rigidbody>();
    _animator = FindObjectOfType<PlayerAnimator>();
    
    CameraMove.target = transform;
  }
}
