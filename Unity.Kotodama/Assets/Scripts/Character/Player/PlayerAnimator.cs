
using UnityEngine;
using System.Collections;

//------------------------------------------------------------
// TIPS:
// Renderer クラスの material プロパティのパラメータについて
//
// 1. mainTextureOffset
// Material の Offset パラメータを指す。
// 画像の左下が UV 座標の基準。
//
// 2. mainTextureScale
// Material の Tiling パラメータを指す。
// Offset の位置からの切り取りサイズを示す。
//
// 切り取られたサイズをもとに、
// Material が設定されたオブジェクトの面に収まるように拡大・縮小される。
//
//------------------------------------------------------------

public class PlayerAnimator : PlayerComponent {

  bool hasLantern { get { return PlayerState.instance.hasLantern; } }
  NavMeshAgent agent { get { return PlayerState.instance.agent; } }

  [SerializeField]
  MeshRenderer _renderer = null;

  [SerializeField, Range(0f, 180f)]
  float _angle = 120f;
  Quaternion cameraLook { get { return Quaternion.Euler(Vector3.right * _angle); } }

  [SerializeField, Range(0.1f, 0.5f)]
  float _scale = 0.15f;
  Vector3 baseScale { get { return (Vector3.one - Vector3.up) * _scale; } }

  [SerializeField, Range(1f, 5f)]
  float _velocityRate = 2.5f;

  static readonly float tile = 0.25f;
  Vector2 textureScale { get { return Vector2.one * tile; } }

  void Start() {
    transform.localScale = baseScale + Vector3.down;
    _renderer.material.mainTextureScale = textureScale;
  }

  protected override IEnumerator UpdateComponent() {
    var previous = transform.position;
    var material = _renderer.material;
    var time = 0f;

    System.Action Animation = () => {
      time += DeltaSpeed();
      var direction = GetDirection(previous);
      material.mainTextureOffset = TextureOffsetY(IsDirectionBack(direction));
      material.mainTextureOffset += AnimationX(time);
      SetDirectionX(IsDirectionLeft(direction));
      previous += direction;
    };

    while (PlayerState.instance.isPlaying) {
      transform.rotation = cameraLook;
      if (agent.velocity.magnitude > 0f) { Animation(); }
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

  float DeltaSpeed() {
    var velocity = Mathf.Clamp(agent.velocity.magnitude, 0f, _velocityRate);
    return Mathf.Pow(velocity + 1f, 2f) * Time.deltaTime;
  }

  // TIPS: 移動速度が早いほど早くアニメーションする
  Vector2 AnimationX(float time) {
    var angle = Mathf.RoundToInt(Mathf.Sin(time));
    var rate = Mathf.Clamp01((angle * tile) + tile);
    return Vector2.right * rate;
  }

  // TIPS: 左右どちらに向いているかで画像の向きを決定する
  void SetDirectionX(bool isLeft) {
    var scale = baseScale + Vector3.down;
    if (!isLeft) { scale.x *= -1f; }
    transform.localScale = scale;
  }
}
