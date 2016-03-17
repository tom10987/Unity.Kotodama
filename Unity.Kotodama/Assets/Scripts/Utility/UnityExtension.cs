
using UnityEngine;

public static class UnityExtension {

  /// <summary> マイナスの値を全てプラスに変換する </summary>
  public static Vector3 Absolute(this Vector3 vector) {
    var value = vector;
    if (value.x < 0f) { value.x *= -1f; }
    if (value.y < 0f) { value.y *= -1f; }
    if (value.z < 0f) { value.z *= -1f; }
    return value;
  }
}
