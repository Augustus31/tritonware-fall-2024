using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstractScript : MonoBehaviour
{
    public int room;
    public int speed;
    public int[,] grid;
    protected GameObject player;
    protected Rigidbody2D rb;
    protected SpriteRenderer rend;
    static readonly (int, int)[] directions = { (-1, 0), (1, 0), (0, -1), (0, 1) };

    public virtual void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    public virtual void Update()
    {
        if(rb.velocity.x < 0)
        {
            rend.flipX = false;
        }
        else
        {
            rend.flipX = true;
        }
    }

    public void death()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().death();
        }
    }

    public static Vector2 FindBestDirection(int[,] grid, (int, int) start, (int, int) target)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        // Queue to hold the position and the direction we took to get there
        Queue<((int, int), Vector2)> queue = new Queue<((int, int), Vector2)>();
        queue.Enqueue((start, new Vector2(0, 0))); // Start with no direction

        // Visited array to avoid revisiting cells
        bool[,] visited = new bool[rows, cols];
        visited[start.Item1, start.Item2] = true;

        while (queue.Count > 0)
        {
            var (currentPosition, firstDirection) = queue.Dequeue();
            int x = currentPosition.Item1;
            int y = currentPosition.Item2;

            // If we've reached the target, return the first direction we took
            if (currentPosition == target)
                return firstDirection;

            // Explore all four possible directions
            for (int i = 0; i < directions.Length; i++)
            {
                int newX = x + directions[i].Item1;
                int newY = y + directions[i].Item2;
                (int, int) newPos = (newX, newY);

                // Check if the new position is within the grid and is not visited or blocked
                if (checkBounds(rows, cols, newX, newY) && !visited[newX, newY])
                {
                    visited[newX, newY] = true;

                    // If this is the first move from the start, record the direction
                    if (firstDirection.x == 0 && firstDirection.y == 0)
                    {
                        queue.Enqueue((newPos, new Vector2(directions[i].Item1, directions[i].Item2)));
                    }
                    else
                    {
                        queue.Enqueue((newPos, firstDirection));
                    }
                }
            }
        }

        // If no path is found, return "No valid direction"
        return new Vector2(0, 0);
    }

    private static bool checkBounds(int rows, int cols, int x, int y)
    {
        if (x >= 0 && x < rows && y >= 0 && y < cols)
        {
            return true;
        }
        return false;
    }

}
