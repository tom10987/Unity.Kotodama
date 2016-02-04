

using UnityEngine;
using System.Collections.Generic;


public class BoradGimmick : MonoBehaviour
{

    [SerializeField]
    GameObject _moveHouseTrue;

    [SerializeField]
    GameObject _moveHouseFalse;

    private int _maxGimmickCanvas = 4;
    private string _gimmickCanvas;
    private List<string> _hitBorads;
    public bool _isClear = false;
    private bool _isBad = false;
    private int _trueMoveTime = 0;
    private int _badMoveTime = 0;

    private bool[] _canvasClearFlag;

    void Start()
    {
        _gimmickCanvas = "GimmickCanvas";
        _hitBorads = new List<string>();
        _canvasClearFlag = new bool[_maxGimmickCanvas];

        for (int i = 0; i < _maxGimmickCanvas; i++)
        {
            _canvasClearFlag[i] = false;
        }
    }

    void OnTriggerEnter(Collider board)
    {
        var canvasName_ = board.gameObject.transform.parent.name;
        // 掲示板のトリガーに当たったら、その掲示板の名前を格納
        if (!_isClear)
        {
            if (board.gameObject.tag.Equals(ObjectTag.Gimmick))
            {
                if (_hitBorads.Count < _maxGimmickCanvas)
                {
                    // 謎解きに関係のない５番の掲示板は格納しない
                    if (canvasName_ != (string)(_gimmickCanvas + 5))
                    {
                        _hitBorads.Add(canvasName_);
                    }
                }
            }
        }

        // おしおき掲示板を見たら
        if (canvasName_ == (string)(_gimmickCanvas + 6))
        {
            _isBad = true;
        }
    }

    void CheckBoards()
    {
        // リストに格納された掲示板の番号が順番通りならtrue
        for (int i = 0; i < _hitBorads.Count; ++i)
        {
            if (_hitBorads[i] == (string)(_gimmickCanvas + (i + 1)))
            {
                _canvasClearFlag[i] = true;
            }
            // 順番が違ったら、falseに戻しリストを消去
            else
            {
                for (int j = 0; j < _maxGimmickCanvas; j++)
                {
                    _canvasClearFlag[j] = false;
                }
                _hitBorads.Clear();
            }

            if (_canvasClearFlag[0] &&
                _canvasClearFlag[1] &&
                _canvasClearFlag[2] &&
                _canvasClearFlag[3])
            {
                _isClear = true;
            }
        }
    }

    void MoveHouse()
    {
        if (_isClear)
        {
            if (_trueMoveTime <= 60 * 3)
            {
                _trueMoveTime++;
                _moveHouseTrue.transform.Translate((1.0f / 60.0f), 0, 0);
            }
        }

        if (_isBad)
        {
            if (_badMoveTime <= 60 * 3)
            {
                _badMoveTime++;
                _moveHouseFalse.transform.Translate((2.0f / 60.0f), 0, 0);
            }
        }
    }

    void Update()
    {
        CheckBoards();
        MoveHouse();
    }
}

