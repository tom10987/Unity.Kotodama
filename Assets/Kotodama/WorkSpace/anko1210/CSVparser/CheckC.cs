using UnityEngine;

public class CheckC : MonoBehaviour {

    static public bool _isCheck;// { get; set; }
    public bool _check;

    void Strat()
    {
    }

    void Update()
    {
        _isCheck = _check;
        Debug.Log(_isCheck);
    }

}
