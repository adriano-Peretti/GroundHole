using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class Magnet : MonoBehaviour
{
    #region Singleton class: Magnet

    public static Magnet Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] float magnetForce;

    List<Rigidbody> affectedRigidBodies = new List<Rigidbody>();
    Transform magnet;


    void Start()
    {
        magnet = transform;
        affectedRigidBodies.Clear();
    }

    private void FixedUpdate()
    {
        if (!Game.isGameover && Game.isMoving)
        {
            foreach (Rigidbody rb in affectedRigidBodies)
            {
                rb.AddForce((magnet.position - rb.position) * magnetForce * Time.fixedDeltaTime);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if (!Game.isGameover && (tag.Equals("Obstacle") || tag.Equals("Object")))
        {
            AddToMagnetField(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string tag = other.tag;

        if (!Game.isGameover && (tag.Equals("Obstacle") || tag.Equals("Object")))
        {
            RemoveFromMagnetField(other.attachedRigidbody);
        }
    }

    public void AddToMagnetField(Rigidbody rb)
    {
        affectedRigidBodies.Add(rb);
    }

    public void RemoveFromMagnetField(Rigidbody rb)
    {
        affectedRigidBodies.Remove(rb);
    }
}
