using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleCollisionDetection : MonoBehaviour
{
    private void OnParticleCollision(GameObject particle)
    {
        Debug.Log("HAND COLLISION PARTICLE");
    }

}
