using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : BaseSceneObject
{
    [SerializeField] private PlayerContainer _player;

    // Start is called before the first frame update
    void Start() => _player = FindObjectOfType<PlayerContainer>();

    public void LoadLevel(int num) => SceneManager.LoadScene(num);

    public void ChangePlayer(int num) => _player.SetCurrentChar(num);

    public void ExitGame() => Application.Quit();

}
