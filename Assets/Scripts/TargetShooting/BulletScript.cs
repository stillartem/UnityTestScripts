using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
  [SerializeField]
  private float speed = 20f;
  [SerializeField]
  private float radius = 2f;
  [SerializeField]
  private GameObject bulletHole;

  private Rigidbody rigidbody;

  void Awake()
  {
    rigidbody = GetComponent<Rigidbody>();
  }

  // Start is called before the first frame update
  void Start()
  {
    rigidbody.velocity = Vector3.right * speed;
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnCollisionEnter(Collision collision)
  {
    ContactPoint contact = collision.contacts[0];
    Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
    Vector3 position = contact.point;
    Instantiate(bulletHole, position, rotation);
    Destroy(gameObject);
  }
}
