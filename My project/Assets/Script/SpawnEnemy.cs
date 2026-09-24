using UnityEngine;
using System.Collections; // Required for non-generic IEnumerator


public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject spawnPos;
    [SerializeField] float timeSpawn;


    private void Start()
    {
        StartCoroutine(SpawnEnemyIenumrator(timeSpawn));
    }

    private IEnumerator SpawnEnemyIenumrator(float t)
    {
        yield return new WaitForSeconds(t);
        CriarEnemy();
        StartCoroutine(SpawnEnemyIenumrator(t));
    }

    void CriarEnemy()
    {
        Instantiate(Enemy, new Vector3(spawnPos.transform.position.x,
    spawnPos.transform.position.y, spawnPos.transform.position.z), Quaternion.identity);
    }
}
