
using UnityEngine;
using System.Linq;

//------------------------------------------------------------
// TIPS:
// プレハブの座標調整専用
// 調整が終了したらスクリプトを外すこと
//
//------------------------------------------------------------

public class GroundSort : MonoBehaviour {

  [SerializeField, Range(3, 6)]
  int _rows = 4;

  static readonly string planeName = "Plane_";
  static readonly int planeSize = 10;

  void OnValidate() {
    var children = this.GetComponentsOnlyChildren<Transform>();
    var xOffset = (_rows - 1) * planeSize * -0.5f;
    var zOffset = (children.Count() / _rows - 1) * planeSize * -0.5f;

    var rowCount = 0;
    foreach (var child in children) {
      var currentRow = rowCount % _rows;
      var currentColumn = rowCount / _rows;

      var x = xOffset + currentRow * planeSize;
      var z = zOffset + currentColumn * planeSize;
      child.localPosition = new Vector3(x, 0f, z);
      child.name = planeName + Row(currentRow) + currentColumn.ToString();

      ++rowCount;
    }
  }

  char Row(int count) { return (char)('a' + count); }
}
