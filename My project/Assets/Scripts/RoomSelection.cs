using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class RoomSelection : MonoBehaviour
{
    public Dropdown dropdown;
    public Transform[] roomTargets;
    public PathFinder AIPathFinder;
    public CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        OpenDropdown(); // Fill dropdown with room names
    }

    void OpenDropdown()
    {
        dropdown.ClearOptions();
        List<string> roomNames = new List<string>();

        foreach (Transform room in roomTargets)
        {
            roomNames.Add(room.name); // Add room names to dropdown
        }

        dropdown.AddOptions(roomNames);
    }
    public void SetDestination()
    {
        if (AIPathFinder != null && roomTargets.Length > 0)
        {
            int selectedRoom = dropdown.value;
            AIPathFinder.SetNewDestination(roomTargets[selectedRoom].position);

            cameraController.LockCursor();
        }
    }
}
