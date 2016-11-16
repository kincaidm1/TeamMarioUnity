using UnityEngine;
using System.Collections;

public class EnemyNavAgent : MonoBehaviour {

	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;

	[SerializeField]
    public Transform player;
    public float minDistance = 10f;
    public float fovAngle = 30f;

    public float range;
    public RaycastHit hitInfo;
    public float angle;
	
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();

		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;

		GotoNextPoint();
	}

	void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0)
			return;

		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
    }

	
	// Update is called once per frame
	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		DetectPlayer();
		if (agent.remainingDistance < 0.5f)
			GotoNextPoint();
	}

	void DetectPlayer () {
		range = Vector3.Distance(transform.position, player.position);

        Vector3 targetDir = player.position - transform.position;
        angle = Vector3.Angle(targetDir, transform.forward);

        if (CanPlayerBeSeen())
        {
            Debug.Log("Player Visible");
            
            while ((player.position - transform.position).magnitude < 10f) {
            agent.SetDestination(player.position);
            break;
            }
        }
        agent.speed = 3.5f;
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
