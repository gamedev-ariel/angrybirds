using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] pigs; // Array to store all pig objects

    private void Update()
    {
        CheckLevelCompletion();
    }

    private void CheckLevelCompletion()
    {
        foreach (GameObject pig in pigs)
        {
            if (pig != null && IsPigVisible(pig))
            {
                return; // If any pig is still visible, level is not complete
            }
        }

        Debug.Log("Level Completed!");
        GameManager.Instance.LoadNextLevel();
    }

    private bool IsPigVisible(GameObject pig)
    {
        // Get the pig's position in screen space
        Vector3 pigScreenPosition = Camera.main.WorldToViewportPoint(pig.transform.position);

        // Check if the pig is outside the visible area of the camera
        return pigScreenPosition.x > 0 && pigScreenPosition.x < 1 &&
               pigScreenPosition.y > 0 && pigScreenPosition.y < 1 &&
               pigScreenPosition.z > 0; // Ensure it's in front of the camera
    }

}
