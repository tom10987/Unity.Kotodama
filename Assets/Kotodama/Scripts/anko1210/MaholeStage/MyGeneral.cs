using UnityEngine;
using System.Collections.Generic;

public class StartPosition
{
    /// <summary>
    /// マリちゃのすたーと位置
    /// </summary>
    public static Vector3 ManholeStage = new Vector3(11f, 0.0f, -9f);
}

public class ManholePosition
{
    public static Dictionary<string, Vector3> pos = new Dictionary<string, Vector3>
    {
        /// <summary>
        /// 触ったマンホールの名前と、ワープ先のマリちゃんのポジション
        /// </summary>
        { "ManholeDA", new Vector3(1.5f, 0f, 24f) },
        { "ManholeDB", new Vector3(-19f, 0f, 3.5f) },
        { "ManholeDC", new Vector3(22.2f, 0f, 3.2f) },
        { "ManholeDD", new Vector3(-2.2f, 0f, -13.5f) },

        { "ManholeUA",    new Vector3(-9.2f, 0f, 30.5f) },
        { "ManholeKey_B", new Vector3(-26.8f, 0f, 12.8f) },
        { "ManholeUC",    new Vector3(23.3f, 0f, -2f) },
        { "ManholeKey_D", new Vector3(1.5f, 0f, -15.5f) },
    };


}

public class GimmickObjectName
{
    /// <summary>
    /// 地下スイッチ
    /// </summary>
    public const string switchA = "SwitchA";

    /// <summary>
    /// 掲示板
    /// </summary>
    public const string board = "Board";
}

//public class MyGeneral : MonoBehaviour{}