using UnityEngine;
using System.Collections.Generic;

public class StartPosition
{
    /// <summary>
    /// マリちゃのすたーと位置
    /// </summary>
    public static Vector3 ManholeStage = new Vector3(-40f, 0.0f, -60f);
}

public class ManholePosition
{
    public static Dictionary<string, Vector3> pos = new Dictionary<string, Vector3>
    {
        /// <summary>
        /// 触ったマンホールの名前と、ワープ先のマリちゃんのポジション
        /// </summary>
        { "ManholeDA", new Vector3(-48.5f, 0f, -26f) },
        { "ManholeDB", new Vector3(-69f, 0f, -46.5f) },
        { "ManholeDC", new Vector3(-27.5f, 0f, -47f) },
        { "ManholeDD", new Vector3(-52f, 0f, -63.5f) },

        { "ManholeUA",    new Vector3(41f, 0f, 80f) },
        { "ManholeKey_B", new Vector3(23f, 0f, 63f) },
        { "ManholeUC",    new Vector3(73.3f, 0f, 48f) },
        { "ManholeKey_D", new Vector3(51.5f, 0f, 34.5f) },
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