
using UnityEngine;
using System;
using System.Collections;

//------------------------------------------------------------
// TIPS:
// Renderer クラスの material プロパティのパラメータについて
//
// 1. mainTextureOffset
// Material の Offset パラメータを指す。
// 画像の左下を座標の基準にする。
//
// 2. mainTextureScale
// Material の Tiling パラメータを指す。
// Offset の位置からの切り取りサイズを示す。
// Texture が設定されたオブジェクトの面に収まるようにサイズが変わる。
//
//------------------------------------------------------------

public class PlayerAnimator : AbstractPlayer {

  bool hasLantern { get { return PlayerState.instance.hasLantern; } }

  NavMeshAgent agent { get { return PlayerState.instance.agent; } }
  bool isMoving { get { return agent.velocity.magnitude > 0f; } }
  float agentSpeed { get { return agent.velocity.magnitude / agent.speed; } }

  [SerializeField]
  MeshRenderer _renderer = null;

  [SerializeField]
  [Range(0f, 180f)]
  float _angle = 120f;
  Quaternion cameraLook { get { return Quaternion.Euler(Vector3.right * _angle); } }

  [SerializeField]
  [Range(0.1f, 0.5f)]
  float _scale = 0.15f;
  Vector3 baseScale { get { return (Vector3.one - Vector3.up) * _scale; } }
  
  static readonly float tile = 0.25f;
  Vector2 textureScale { get { return Vector2.one * tile; } }

  void Start() {
    transform.localScale = baseScale + Vector3.down;
    _renderer.material.mainTextureScale = textureScale;
  }

  public override IEnumerator UpdateComponent() {
    var previous = transform.position;
    var material = _renderer.material;
    var time = 0f;

    Action Animation = () => {
      time += DeltaSpeed();
      var direction = GetDirection(previous);
      material.mainTextureOffset = TextureOffsetY(IsDirectionBack(direction));
      material.mainTextureOffset += AnimationX(time);
      SetDirectionX(IsDirectionLeft(direction));
      previous += direction;
    };

    while (PlayerState.instance.isPlaying) {
      transform.rotation = cameraLook;
      if (isMoving) { Animation(); }
      yield return null;
    }
  }

  Vector3 GetDirection(Vector3 previous) { return transform.position - previous; }
  bool IsDirectionLeft(Vector3 direction) { return direction.x < 0f; }
  bool IsDirectionBack(Vector3 direction) { return direction.z < 0f; }

  // TIPS: ランプを持ってるか、手前と奥のどちらに向いているかで画像を切り替える
  Vector2 TextureOffsetY(bool isBack) {
    var lantern = hasLantern ? 0.0f : 0.5f;
    var back = isBack ? 0.25f : 0.0f;
    return Vector2.up * (lantern + back);
  }

  float DeltaSpeed() { return isMoving ? agentSpeed / Mathf.Pow(Mathf.PI, 2f) : 0f; }

  // TIPS: 移動速度が早いほど早くアニメーションする
  Vector2 AnimationX(float time) {
    var angle = Mathf.RoundToInt(Mathf.Sin(time));
    return Vector2.right * (angle * tile + tile);
  }

  // TIPS: 左右どちらに向いているかで画像の向きを決定する
  void SetDirectionX(bool isLeft) {
    var scale = baseScale + Vector3.down;
    if (!isLeft) { scale.x *= -1f; }
    transform.localScale = scale;
  }
}
