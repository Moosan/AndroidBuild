using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    [SerializeField]private GameObject MoveFoward, MoveBack, MoveRight, MoveLeft,DrawButton;
    [SerializeField]private GameObject WebCameraPanel,Scene;
    [SerializeField] private GameObject PaintMarker,ShadowPanel,MarkerSlider;
    private GameMode Mode { get; set; }
    void Awake() {
        Mode = GameMode.Title;
    }

    private void EndNowMode(GameMode mode) {
        if (mode == GameMode.Title)
        {
            TitleEnd();
        }
        else if (mode == GameMode.Draw)
        {
            DrawEnd();
        }
        else if (mode == GameMode.Move)
        {
            MoveEnd();
        }
        else if (mode == GameMode.SelectColor) {
            SelectColorEnd();
        }
    }
    private void TitleStart() {
        EndNowMode(Mode);


        Mode = GameMode.Title;
    }
    private void TitleEnd()
    {

    }
    private void DrawStart() {
        EndNowMode(Mode);
        DrawButton.SetActive(true);
        PaintMarker.SetActive(true);
        MarkerSlider.SetActive(true);
        Mode = GameMode.Draw;
    }
    private void DrawEnd()
    {
        DrawButton.SetActive(false);
        PaintMarker.SetActive(false);
        MarkerSlider.SetActive(false);
    }
    private void MoveStart() {
        EndNowMode(Mode);
        MoveFoward.SetActive(true);
        MoveBack.SetActive(true);
        MoveRight.SetActive(true);
        MoveLeft.SetActive(true);
        Mode = GameMode.Move;
    }
    private void MoveEnd() {

        MoveFoward.SetActive(false);
        MoveBack.SetActive(false);
        MoveRight.SetActive(false);
        MoveLeft.SetActive(false);
    }
    private void SelectColorStart() {
        EndNowMode(Mode);


        Mode = GameMode.SelectColor;
    }
    private void SelectColorEnd() {

    }
    public void OnGameModeValueChanged(Dropdown drodow) {
        var value = drodow.value;
        if (value == 0) {
            TitleStart();
        }
        if (value == 1) {
            MoveStart();
        }
        if (value == 2) {
            DrawStart();
        }
        if (value == 3) {
            SelectColorStart();
        }
    }
    public void OnBackModeValueChnged(Dropdown drop) {
        var value = drop.value;
        if (value == 0)
        {
            Scene.SetActive(true);
            WebCameraPanel.SetActive(false);
            ShadowPanel.SetActive(false);
        }
        else if (value == 1) {
            Scene.SetActive(false);
            WebCameraPanel.SetActive(true);
            ShadowPanel.SetActive(false);
        }
    }
}
public enum GameMode {
    Title,Move,Draw,SelectColor
}
public enum BackMode {
    VR,AR
}
