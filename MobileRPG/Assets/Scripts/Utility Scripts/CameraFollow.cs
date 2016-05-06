using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    // Distance in the x axis the player can move before being followed by camera
    public float xMargin = 1.5f;

    // Distance in the y axis the player can move before being followed by camera
    public float yMargin = 1.5f;

    // How smooth the camera catches its target (x axis)
    public float xSmooth = 1.5f;

    // How smooth camera catches its target (y axis)
    public float ySmooth = 1.5f;

    // The maximum x and y coordinates the camera can have
    private Vector2 maxXandY;

    // The minimum x and y coordinates the camera can have
    private Vector2 minXandY;

    // Reference the players transform
    public Transform player;

	// Use this for initialization
	void Awake ()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (player == null)
            Debug.LogError("Player Object Not Found");

        // Resolution independence solution A

        // Getting the bounds for background in WORLD size
        var leftBackgroundBounds = GameObject.Find("LeftBackground").GetComponent<SpriteRenderer>().bounds;
        var rightBackgroundBounds = GameObject.Find("RightBackground").GetComponent<SpriteRenderer>().bounds;

        // Get viewable bounds of camera in WORLD size
        var cameraTopLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        var cameraBottomRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        // Set the min and max X for the camera
        minXandY.x = leftBackgroundBounds.min.x - cameraTopLeft.x;
        maxXandY.x = rightBackgroundBounds.max.x - cameraBottomRight.x;

        // Set the min and max Y for the camera
        minXandY.y = leftBackgroundBounds.min.y - cameraTopLeft.y;
        maxXandY.y = rightBackgroundBounds.max.y - cameraBottomRight.y;

        // End of resolution solution
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
	    if(player != null)
        {
            // Check if the player is close to the edge and update the cameras position
            // Also check if the camera bounds have reached the edge of the screen and don't move beyond it

            float targetX = transform.position.x;
            float targetY = transform.position.y;

            if(CheckXMargin())
                // Lerp between the current position and the player position, using xSmooth
                targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);

            if (CheckYMargin())
                // Lerp between the current position and the player position, using xSmooth
                targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.fixedDeltaTime);

            targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);
            targetY = Mathf.Clamp(targetY, minXandY.y, maxXandY.y);

            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
	}

    /// <summary>
    /// Check if the player has moved near the edge of the cameras bounds.
    /// </summary>
    /// <returns>If the player has moved near the X edge of the cameras bounds.</returns>
    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }
    
    /// <summary>
    /// Check if the player has moved near the edge of the cameras bounds.
    /// </summary>
    /// <returns>If the player has moved near the Y edge of the cameras bounds.</returns>
    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }
}
