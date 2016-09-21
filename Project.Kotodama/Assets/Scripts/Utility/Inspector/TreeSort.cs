
using UnityEngine;
using System.Linq;

//------------------------------------------------------------
// TIPS:
// プレハブの座標調整専用
// 調整が終了したらスクリプトを外すこと
//
//------------------------------------------------------------

public class TreeSort : MonoBehaviour {

  [SerializeField, Range(0f, 10f)]
  float _treeScale = 1f;
  Vector3 treeScale { get { return Vector3.one * _treeScale; } }

  [SerializeField]
  Vector3 _treeOffset = Vector3.zero;

  [SerializeField]
  Vector3 _polygonOffset = Vector3.zero;

  static readonly string _treeName = "Tree_";
  static readonly float _colliderScale = 4f;

  void OnValidate() {
    var children = this.GetComponentsOnlyChildren<TreeComponent>();
    var rowCount = children.Count() - 1;
    var baseOffset = Vector3.left * rowCount * 0.5f * _colliderScale;

    var i = 0;
    foreach (var child in children) {
      child.transform.localScale = treeScale;
      child.polygon.localPosition = _polygonOffset;

      var number = (i < 10 ? string.Format("0{0}", i) : i.ToString());
      child.name = _treeName + number;

      var translate = Vector3.right * (_colliderScale * i) + baseOffset;
      var offset = _treeOffset;
      offset.x = _treeOffset.x * (i - rowCount * 0.5f);
      child.transform.localPosition = translate + offset;
      ++i;
    }

    name = string.Format("Trees({0})", children.Count());
  }
}
