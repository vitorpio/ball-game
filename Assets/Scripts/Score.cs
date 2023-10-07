using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Score : MonoBehaviour
{
    private int _boxesActivated = 0;
    public int boxesActivated
    {
        get => _boxesActivated;
        set
        {
            _boxesActivated = value;
            updateScore();
            if (_boxesActivated == totalBoxes)
            {
                allBoxesActivated.Invoke();
            }
        }
    }
    private int _coinsCollected = 0;
    public int coinsCollected
    {
        get => _coinsCollected;
        set
        {
            _coinsCollected = value;
            updateScore();
            if (_coinsCollected == (totalCoins - 1))
            {
                canGetFinalCoin = true;
            }
        }
    }

    public TMP_Text textPoints;
    public WallController wallController;

    public delegate void AllBoxesActivated();
    public event AllBoxesActivated allBoxesActivated;

    internal int totalBoxes = 5;
    internal int totalCoins = 10;
    internal bool canGetFinalCoin = false;

    // Start is called before the first frame update
    void Start()
    {
        updateScore();
        allBoxesActivated += wallController.DestroyWall;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void updateScore()
    {
        textPoints.text = "Caixas: " + boxesActivated.ToString() + "/" + totalBoxes.ToString() + "\nMoedas: " + coinsCollected.ToString() + "/" + totalCoins.ToString();
    }

}
