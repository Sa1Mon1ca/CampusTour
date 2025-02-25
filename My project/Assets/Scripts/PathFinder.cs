using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool hasReached = false;
    public CameraController cameraController;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(!hasReached && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            hasReached = true;
            UnlockCursor();
        }
    }

    public void SetNewDestination(Vector3 newTarget)
    {
        if (agent != null)
        {
            agent.SetDestination(newTarget);
            hasReached = false;
        }
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (cameraController != null)
        {
            cameraController.UnlockCursor();
        }
    }
}
