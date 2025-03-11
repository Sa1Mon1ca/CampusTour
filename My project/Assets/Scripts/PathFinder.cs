using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PathFinder : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool hasReached = false;
    public CameraController cameraController;

    public Text roomDescriptionText;
    public GameObject descriptionPanel;

    private string currentRoomCode;

    private Dictionary<string, string> roomDescriptions = new Dictionary<string, string>
{
    //Teaching and Learning Spaces
    {"2Q048", "Type: Standard Teaching Room\nDepartment: Engineering, Design, and Mathematics\nSeats: Estimated 40-60\nPurpose: Used for regular classes, lectures, and seminars."},
    {"2Q049", "Type: Large Lecture Hall\nDepartment: Central Exams and Teaching Timetabling Services\nSeats: 100+ tiered seating\nPurpose: Used for large lectures, exams, and events."},
    {"2Q050", "Type: Large Teaching Room\nDepartment: Faculty of Environment and Technology\nSeats: 80+\nPurpose: Large lecture-based classes and interactive teaching."},
    {"2Q047", "Type: Medium-Sized Teaching Room\nDepartment: Geography and Environmental Management\nSeats: 15-25\nPurpose: Small group lectures and discussions."},
    {"2Q046", "Type: Seminar Room\nDepartment: Geography and Environmental Management\nSeats: 15-25\nPurpose: Tutorials, project discussions, and small-group teaching."},
    {"2Q043", "Type: Standard Teaching Room\nDepartment: Computer Science and Creative Technology\nSeats: 30-40\nPurpose: Regular IT-focused lectures."},
    {"2Q042", "Type: Standard Classroom\nDepartment: Geography and Environmental Management\nSeats: 50+\nPurpose: Used for geography/environmental sciences lectures."},

    //Storage and Utility Rooms
    {"2Q041", "Type: Storage Room\nDepartment: Faculty of Environment and Technology\nPurpose: Storage for academic materials and equipment."},
    {"2Q044A", "Type: Storage Room\nDepartment: Geography and Environmental Management\nPurpose: Storage for departmental materials."},
    {"2Q044B", "Type: Storage Room\nDepartment: Hospitality Services\nPurpose: Storage for café and hospitality equipment."},
    {"2Q054", "Type: Cleaning Services Store\nDepartment: Cleaning Services\nPurpose: Storage of cleaning supplies."},

    //Computer Labs
    {"2Q052", "Type: IT Lab\nDepartment: Computer Science and Creative Technology\nSeats: 30+ workstations\nPurpose: Programming, software training, and hands-on IT learning."},
    {"2Q053", "Type: IT Lab\nDepartment: Computer Science and Creative Technology\nSeats: 25+ workstations\nPurpose: Practical IT-related sessions."},
    {"2Q012", "Type: Computer Lab\nSeats: 40+ IT workstations\nPurpose: Computer Science training."},
    {"2Q028", "Type: Computer Lab\nSeats: 35+\nPurpose: Software and IT courses."},

    //Administrative Offices
    {"2Q045", "Type: Faculty Office\nDepartment: Computer Science and Creative Technology\nSeats: Office desks for faculty members\nPurpose: Faculty workspace and administrative tasks."},
    {"2Q035", "Type: IT Services Office\nDepartment: IT Services\nSeats: Several desks for IT staff\nPurpose: IT support, troubleshooting, and administration."},
    {"2Q034", "Type: IT Technicians’ Workspace\nDepartment: IT Services Technicians\nSeats: Office desks for IT staff\nPurpose: Administrative work and tech support."},
    {"2Q033", "Type: Student Information Desk\nDepartment: IT Services\nSeats: Service desk area\nPurpose: Student queries, IT support, and information assistance."},

    //Student Support and Consultation Spaces
    {"2Q056", "Type: Student Support Advice Information Point\nDepartment: Student Support Advice\nPurpose: Guidance and assistance for students."},
    {"2Q056A", "Type: Private Consultation Room\nDepartment: Student Support Advice\nPurpose: One-on-one student support meetings."},
    {"2Q056B", "Type: Private Consultation Room\nDepartment: Student Support Advice\nPurpose: Personal advisory sessions."},
    {"2Q056C", "Type: Private Consultation Room\nDepartment: Student Support Advice\nPurpose: Academic and personal guidance sessions."},

    //Facilities and Utility Spaces
    {"2Q032", "Type: Utility Room\nDepartment: Estates Balance\nPurpose: Housing technical and mechanical systems."},
    {"2Q055", "Type: Restroom\nDepartment: Estates Balance²\nPurpose: Restroom for staff and students."},
    {"2Q002", "Type: Mail Sorting Room\nDepartment: Faculty of Environment and Technology\nPurpose: Sorting and handling university mail."},
    {"2Q001A", "Type: IT Plant Room\nDepartment: IT Services\nPurpose: Houses IT-related infrastructure."},

    //Learning and Social Spaces
    {"2Q008", "Type: Study Area\nDepartment: Library Services\nSeats: 50+ desks and study pods\nPurpose: Individual and group study."},
    {"2Q030", "Type: Library Study Space\nDepartment: Library Services\nSeats: 60+ seating areas\nPurpose: Research and independent study."},
    {"2Q006A", "Type: Dining Area\nDepartment: Hospitality Services\nSeats: 20+ seating arrangements\nPurpose: Food service for students and staff."},

    //Other Spaces
    {"2Q029", "Type: Laboratory\nPurpose: Geography and Environmental research."}
};


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        descriptionPanel.SetActive(false);
    }

    void Update()
    {
        if (!hasReached && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            hasReached = true;
            ShowRoomDescription();
            UnlockCursor();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && descriptionPanel.activeSelf)
        {
            descriptionPanel.SetActive(false);
        }
    }


    public void SetNewDestination(Vector3 newTarget, string roomCode)
    {
        if (agent != null)
        {
            agent.SetDestination(newTarget);
            hasReached = false;
            descriptionPanel.SetActive(false);
            currentRoomCode = roomCode;
        }
    }

    void ShowRoomDescription()
    {
        if (string.IsNullOrEmpty(currentRoomCode))
        {
            return;
        }

        if (roomDescriptions.ContainsKey(currentRoomCode))
        {
            roomDescriptionText.text = roomDescriptions[currentRoomCode];
        }
        else
        {
            roomDescriptionText.text = "No description available for this room.";
        }

        descriptionPanel.SetActive(true);
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
