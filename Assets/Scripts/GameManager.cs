using ProjectAU.Environment;
using ProjectAU.Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Start()
    {
        var player = FindObjectOfType<Player>();
        var tasks = FindObjectsOfType<Task>();
        foreach (var task in tasks)
            player.IncompleteTasks.Add(task);
    }
}
