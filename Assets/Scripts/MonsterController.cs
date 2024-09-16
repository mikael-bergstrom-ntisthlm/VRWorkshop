using UnityEngine;

public class MonsterController : MonoBehaviour
{
  [SerializeField]
  GameObject explosionPrefab;

  GameManager gameManager;

  private void Awake()
  {
    GameObject.FindGameObjectWithTag("GameManager").TryGetComponent<GameManager>(out gameManager);
  }

  void Update()
  {
    GameObject lookTarget = Camera.main.gameObject;
    gameObject.transform.LookAt(lookTarget.transform);
  }

  private void OnCollisionEnter(Collision other)
  {
    Kill(true);
  }

  public void Kill(bool givePoints = false)
  {
    GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    Destroy(explosion, 1);
    Destroy(this.gameObject);

    if (givePoints)
    {
      gameManager.AddPoints(50);
    }
  }
}
