using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private PlayerContainer _player;
    [SerializeField] private Transform _spawnPoint;

    public GameObject SpawnedPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        _player = FindObjectOfType<PlayerContainer>();
        SpawnedPlayer = Instantiate(_player.GetCurrentChar(), _spawnPoint.position, _spawnPoint.rotation);
    }
}
