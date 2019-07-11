
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private CharController _player;


    //public Transform explosionPrefab;
    void OnCollisionEnter(Collision collision)
    {
        //ContactPoint contact = collision.contacts[0];

        if (collision.gameObject.name == "VR_Player")
        {
            Debug.Log("Hit the Enemy: " + collision.gameObject.name + ", with: " + gameObject);

            _player.ApplyDamage(100);
        }

        // Rotate the object so that the y-axis faces along the normal of the surface
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;
        ////Instantiate(explosionPrefab, pos, rot);
        //Destroy(gameObject);
    }
}
