
using UnityEngine;
using System.Linq;

//------------------------------------------------------------
// TIPS:
// プレハブの座標調整専用
// 調整が終了したらスクリプトを外すこと
//
//------------------------------------------------------------

public class TreeGroupSort : MonoBehaviour {

  [SerializeField]
  bool _activate = false;

  [SerializeField]
  float _offset = 3f;

  void OnValidate() {
    var children = this.GetComponentsOnlyChildren<Transform>();
    var baseOffset = Vector3.back * _offset * (children.Count() - 1) * 0.5f;

    var i = 0;
    foreach (var child in children) {
      var number = (i < 10 ? string.Format("0{0}", i) : i.ToString());
      child.name = "Trees_" + number;
      child.localPosition = Vector3.forward * (_offset * i++) + baseOffset;
    }
  }
}
