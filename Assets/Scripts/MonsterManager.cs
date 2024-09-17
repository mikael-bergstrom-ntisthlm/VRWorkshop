using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class MonsterManager : MonoBehaviour
{
  [SerializeField]
  List<GameObject> monsterPrefabs;

  [SerializeField]
  int maxMonsters = 15;

  [SerializeField]
  float timeBetweenSpawns = 1;

  [SerializeField]
  GameObject monsterContainer;

  [Header("Spawn distance from player")]

  [SerializeField]
  float minDistance = 5;

  [SerializeField]
  float maxDistance = 10;

  [Header("Spawn height")]

  [SerializeField]
  float minHeight = 2;

  [SerializeField]
  float maxHeight = 5;

  private void OnStart()
  {
    InvokeRepeating("SpawnMonster", 1f, timeBetweenSpawns);
  }

  private void OnStop()
  {
    CancelInvoke("SpawnMonster");
    
    foreach (MonsterController monster in monsterContainer.GetComponentsInChildren<MonsterController>())
    {
      monster.Kill();
    }

  }

  private void SpawnMonster()
  {
    if (monsterContainer.transform.childCount >= maxMonsters) return;

    Vector3 randomPosition = new Vector3(
            Random.Range(-1f, +1f),
            0,
            Random.Range(-1f, +1f)
          ).normalized * Random.Range(minDistance, maxDistance);

    randomPosition.y = Random.Range(minHeight, maxHeight);

    GameObject monster = Instantiate(
      monsterPrefabs[Random.Range(0, (int)monsterPrefabs.Count)],
      randomPosition,
      Quaternion.identity
    );

    monster.transform.parent = monsterContainer.transform;
  }
}
