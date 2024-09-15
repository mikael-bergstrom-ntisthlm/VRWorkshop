using Unity.XR.CoreUtils;
using UnityEngine;

public class BulletController : MonoBehaviour
{
  [SerializeField]
  float InitialSpeed = 50f;

  [SerializeField]
  float maxLifetime = 10;

  void Start()
  {
    GetComponent<Rigidbody>().AddForce(transform.forward * InitialSpeed);
    Destroy(this.gameObject, maxLifetime);
  }
}
