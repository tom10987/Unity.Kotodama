using UnityEngine;

public class StageSetup : MonoBehaviour
{
    void Start()
    {
        var rootObjects_ = FindObjectsOfType<RootManager>();

        Vector3 enemyPosA = new Vector3(-8, 0, 20);
        Vector3 enemyPosB = new Vector3(-8.5f, 0, -20);
        Vector3 enemyPosC = new Vector3(8.5f, 0, 40);

        foreach (var rootObject_ in rootObjects_)
        {
            if (rootObject_.name == "RootBaseA")
            {
                EnemyManager.instance.CreateEnemy(rootObject_.spots, "EnemyA");
            }
            if (rootObject_.name == "RootBaseB")
            {
                EnemyManager.instance.CreateEnemy(rootObject_.spots, "EnemyB");
            }
            if(rootObject_.name == "RootBaseC")
            {
                EnemyManager.instance.CreateEnemy(rootObject_.spots, "EnemyC");
            }
        }

        EnemyManager.instance.StartEnemies();
    }
}
