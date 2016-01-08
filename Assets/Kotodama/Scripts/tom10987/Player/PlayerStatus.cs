
using UnityEngine;


// TODO: 名前がおかしいのでリネーム
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


  //------------------------------------------------------------
  // public method

  // TODO: Move() にリネーム
  public void MoveStart() {
    _ownRigid.velocity = Vector3.zero;
    if (EffectSequencer.instance.IsFadeTime()) { return; }

    var touchPos = TouchController.GetTouchWorldPositionXZ();
    if (touchPos.magnitude < _touchRadius) { return; }

    // TIPS: 画面が横長なので、アスペクト比で割る
    touchPos.x /= Camera.main.aspect;
    _direction = touchPos.normalized * _moveSpeed;
    _ownRigid.AddForce(_direction, ForceMode.Impulse);
  }

  // TODO: Stop() にリネーム
  public void MoveStop() {
    _ownRigid.velocity = Vector3.zero;
  }

  public void SpriteState(PlayerAnimationState newState) {
    _animator.SetSpriteState(newState);
  }


  //------------------------------------------------------------
  // Behaviour

  protected override void Awake() { base.Awake(); }

  void Start() {
    _ownRigid = GetComponent<Rigidbody>();
    _animator = FindObjectOfType<PlayerAnimator>();

    CameraMove.target = transform;
  }
}
