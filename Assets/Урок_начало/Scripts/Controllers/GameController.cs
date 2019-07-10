using UnityEngine;

public class GameController : BaseSceneObject
{
    [SerializeField] private GameObject _btn_start;
    [SerializeField] private GameObject _btn_exit;

    public static CharController LocalPlayer { get; private set; }

    void GameStart() {
        LocalPlayer.speed = 6;
    }

}
