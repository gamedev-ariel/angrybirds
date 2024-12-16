using UnityEngine;
public class LevelManager : MonoBehaviour
{
    public GameObject[] pigs; // Array to store all pig objects
    private bool levelCompleted = false;

    private void Update()
    {
        if (!levelCompleted)
        {
            CheckLevelCompletion();
        }
    }

    private void CheckLevelCompletion()
    {
        // Check if ALL pigs are outside the camera view
        bool allPigsOutsideCamera = true;
        foreach (GameObject pig in pigs)
        {
            if (pig != null && IsPigVisible(pig))
            {
                allPigsOutsideCamera = false;
                break;
            }
        }

        if (allPigsOutsideCamera)
        {
            levelCompleted = true;
            Debug.Log("Level Completed!");
            Invoke("LoadNextLevel", 0.5f); // Small delay to ensure final physics calculations
        }
    }

    private bool IsPigVisible(GameObject pig)
    {
        // Get the pig's position in screen space
        Vector3 pigScreenPosition = Camera.main.WorldToViewportPoint(pig.transform.position);

        // Expand the check slightly to ensure complete exit
        return pigScreenPosition.x >= -0.1f && pigScreenPosition.x <= 1.1f &&
               pigScreenPosition.y >= -0.1f && pigScreenPosition.y <= 1.1f &&
               pigScreenPosition.z > 0; // Ensure it's in front of the camera
    }

    private void LoadNextLevel()
    {
        GameManager.Instance.LoadNextLevel();
    }
}