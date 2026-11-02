using UnityEngine;

public class PawnSpawnPoint : MonoBehaviour
{
    public enum SpawnPointType { Player, Enemy, Both };
    [Header("Spawn Point Type")]
    public SpawnPointType type;
    [Header("Gizmo Data")]
    public float gizmoBoxHeight = 2.0f;
    public float gizmoBoxWidth = 1.0f;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.spawnPoints.Add(this);
        }
    }

    public void OnDrawGizmos()
    {
        // Create a color for our gizmo
        Color boxColor = new Color(); 

        if (type == SpawnPointType.Player)
        {
            boxColor = Color.green;
        }
        else if (type == SpawnPointType.Enemy)
        {
            boxColor = Color.red;
        }
        else if (type == SpawnPointType.Both)
        {
            boxColor = Color.rebeccaPurple;
        }

        // Make it transparent
        boxColor.a = 0.9f;

        // Set the color for our gizmos to draw
        Gizmos.color = boxColor;

        // Since our box's position is the CENTER of the box, we will want to draw the box 1/2 the height of the box off the ground.
        // Gizmos are drawn in WORLD space, so you need to access the transform component to set their relative position.
        // We will start at our position and then move up.
        Vector3 boxPosition = transform.position;
        boxPosition += Vector3.up * (gizmoBoxHeight / 2);

        // Our size will be square on the X/Z, and only use the height
        Vector3 boxSize = new Vector3(gizmoBoxWidth, gizmoBoxHeight, gizmoBoxWidth);

        Gizmos.DrawCube(boxPosition, boxSize);

        // DRAW THE RAY (LINE) pointing forward
        Gizmos.color = Color.red;
        Gizmos.DrawRay(boxPosition, transform.forward);
    }


    public void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.spawnPoints.Remove(this);
        }
    }
}
