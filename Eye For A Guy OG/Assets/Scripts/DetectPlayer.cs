using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    public float minDistance = 10f;
    public float fovAngle = 30f;

    public float range;
    public RaycastHit hitInfo;
    public float angle;


    public void FixedUpdate() {
        range = Vector3.Distance(transform.position, player.position);

        Vector3 targetDir = player.position - transform.position;
        angle = Vector3.Angle(targetDir, transform.forward);

        if (CanPlayerBeSeen())
        {
            Debug.Log("Player Visible");
        }
        else
        { 
            Debug.Log("Player Not Seen");
        }
    }

    public bool CanPlayerBeSeen() {
        if (range < minDistance && !Physics.Linecast(transform.position, player.position)) {
            if (PlayerInBeam()) {
                return true;
            }
            return false;
        }
        return false;
    }

    public bool PlayerInBeam() {
        if (angle < fovAngle) {
            return true;
        } else {
            return false;
        }
    }
}
