using System.Collections;
using UnityEngine;

public class GameController : BaseSceneObject
{
    //[SerializeField] private GameObject _btn_start;
    //[SerializeField] private GameObject _btn_exit;

    //public static CharController LocalPlayer { get; private set; }

    //void GameStart() {
    //    LocalPlayer.speed = 6;
    //}

    [SerializeField] private GameObject MenuLabel;
    [SerializeField] private GameObject YouLooseLabel;
    [SerializeField] private GameObject YouWinLabel;

    [SerializeField] private float _timeToLoadMenu = 2;

    [SerializeField] private PlayerContainer _playerContainer;

    [SerializeField] private MenuController _menuController;

    void Start()
    {
        _playerContainer = FindObjectOfType<PlayerContainer>();
        MenuLabel.SetActive(false);
        YouLooseLabel.SetActive(false);
        YouWinLabel.SetActive(false);

        _menuController = FindObjectOfType<MenuController>();
    }

    public void YouWin()
    {
        StopGame(YouWinLabel);
    }

    public void YouLoose()
    {
        StopGame(YouLooseLabel);
    }

    private void StopGame(GameObject go)
    {
        MenuLabel.SetActive(true);
        go.SetActive(true);
        StartCoroutine(BackToMenu());
    }

    private IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(_timeToLoadMenu);
        _menuController.LoadLevel((int)_playerContainer._currentChar);

        yield break;
    }
}
