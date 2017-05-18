using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    [SerializeField]
    private Scrolling _scrolling;
    private GameData _gameData;
    [SerializeField]
    private float _maxYCoords;
    [SerializeField]
    private GameObject[] _backgrounds;
    private Transform[] _backgroundTrans;
    private SpriteRenderer[] _backgroundrenderers = new SpriteRenderer[2];
    [SerializeField]
    private Sprite[] _backgroundSprites;
    [SerializeField]
    private Sprite[] _foregroundSprites;
    private int _currentBackgroundSprite = 0;
    private int _currentForegroundSprite = 0;

    private void Awake()
    {
        _gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
        _backgroundTrans = new Transform[_backgrounds.Length];
        _backgroundrenderers = new SpriteRenderer[_backgrounds.Length];
        for (int i = 0; i < _backgrounds.Length; i++)
        {
            _backgroundTrans[i] = _backgrounds[i].transform;
            _backgroundrenderers[i] = _backgrounds[i].GetComponent<SpriteRenderer>();
        }
    }

    private void FixedUpdate()
    {
        if(_gameData.direction == Direction.DOWN || _gameData.direction == Direction.HEADSTART)
        {
            for (int i = 0; i < _backgroundTrans.Length; i++)
            {
                if(_backgroundTrans[i].position.y > _maxYCoords)
                {
                    _backgroundTrans[i].position = new Vector2(0, _backgroundTrans[i].position.y - (_maxYCoords * 2));
                    if (i < 2)
                    {
                        if (_backgroundrenderers[i].sprite != _backgroundSprites[_currentBackgroundSprite])
                        {
                            _backgroundrenderers[i].sprite = _backgroundSprites[_currentBackgroundSprite];
                        }

                        if (_currentBackgroundSprite % 2 == 0 && _currentBackgroundSprite < _backgroundSprites.Length -1)
                        {
                            _currentBackgroundSprite++;
                            _backgroundrenderers[i].sprite = _backgroundSprites[_currentBackgroundSprite];
                        }
                        else
                        {
                            switch (_currentBackgroundSprite)
                            {
                                case 1:
                                if (_scrolling.percentage > 0.33f)
                                {
                                    _currentBackgroundSprite++;
                                    _backgroundrenderers[i].sprite = _backgroundSprites[_currentBackgroundSprite];
                                }
                                break;
                                case 3:
                                if (_scrolling.percentage > 0.66f)
                                {
                                    _currentBackgroundSprite++;
                                    _backgroundrenderers[i].sprite = _backgroundSprites[_currentBackgroundSprite];
                                }
                                break;
                                case 5:
                                if (_scrolling.percentage > 0.975f)
                                {
                                    _currentBackgroundSprite++;
                                    _backgroundrenderers[i].sprite = _backgroundSprites[_currentBackgroundSprite];
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (_backgroundrenderers[i].sprite != _foregroundSprites[_currentForegroundSprite])
                        {
                            _backgroundrenderers[i].sprite = _foregroundSprites[_currentForegroundSprite];
                        }

                        if (_currentForegroundSprite % 2 == 0 && _currentBackgroundSprite < _backgroundSprites.Length - 1)
                        {
                            _currentForegroundSprite++;
                            _backgroundrenderers[i].sprite = _foregroundSprites[_currentForegroundSprite];
                        }
                        else
                        {
                            switch (_currentForegroundSprite)
                            {
                                case 1:
                                if (_scrolling.percentage > 0.34f)
                                {
                                    _currentForegroundSprite++;
                                    _backgroundrenderers[i].sprite = _foregroundSprites[_currentForegroundSprite];
                                }
                                break;
                                case 3:
                                if (_scrolling.percentage > 0.67f)
                                {
                                    _currentForegroundSprite++;
                                    _backgroundrenderers[i].sprite = _foregroundSprites[_currentForegroundSprite];
                                }
                                break;
                                case 5:
                                if (_scrolling.percentage > 0.985f)
                                {
                                    _currentForegroundSprite++;
                                    _backgroundrenderers[i].sprite = _foregroundSprites[_currentForegroundSprite];
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
        else if(_gameData.direction == Direction.UP)
        {
            for (int i = 0; i < _backgroundTrans.Length; i++)
            {
                if (_backgroundTrans[i].position.y < -_maxYCoords)
                {
                    _backgroundTrans[i].position = new Vector2(0, _backgroundTrans[i].position.y + (_maxYCoords * 2));
                    if (i < 2)
                    {
                        if (_backgroundrenderers[i].sprite != _backgroundSprites[_currentBackgroundSprite])
                        {
                            _backgroundrenderers[i].sprite = _backgroundSprites[_currentBackgroundSprite];
                        }

                        if (_currentBackgroundSprite % 2 == 0 && _currentBackgroundSprite > 0)
                        {
                            _currentBackgroundSprite--;
                            _backgroundrenderers[i].sprite = _backgroundSprites[_currentBackgroundSprite];
                        }
                        else
                        {
                            switch (_currentBackgroundSprite)
                            {
                                case 1:
                                if (_scrolling.percentage < 0.025f)
                                {
                                    _currentBackgroundSprite--;
                                    _backgroundrenderers[i].sprite = _backgroundSprites[_currentBackgroundSprite];
                                }
                                break;
                                case 3:
                                if (_scrolling.percentage < 0.33f)
                                {
                                    _currentBackgroundSprite--;
                                    _backgroundrenderers[i].sprite = _backgroundSprites[_currentBackgroundSprite];
                                }
                                break;
                                case 5:
                                if (_scrolling.percentage < 0.66f)
                                {
                                    _currentBackgroundSprite--;
                                    _backgroundrenderers[i].sprite = _backgroundSprites[_currentBackgroundSprite];
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (_backgroundrenderers[i].sprite != _foregroundSprites[_currentForegroundSprite])
                        {
                            _backgroundrenderers[i].sprite = _foregroundSprites[_currentForegroundSprite];
                        }

                        if (_currentForegroundSprite % 2 == 0 && _currentBackgroundSprite > 0)
                        {
                            _currentForegroundSprite--;
                            _backgroundrenderers[i].sprite = _foregroundSprites[_currentForegroundSprite];
                        }
                        else
                        {
                            switch (_currentForegroundSprite)
                            {
                                case 1:
                                if (_scrolling.percentage < 0.015f)
                                {
                                    _currentForegroundSprite--;
                                    _backgroundrenderers[i].sprite = _foregroundSprites[_currentForegroundSprite];
                                }
                                break;
                                case 3:
                                if (_scrolling.percentage < 0.32f)
                                {
                                    _currentForegroundSprite--;
                                    _backgroundrenderers[i].sprite = _foregroundSprites[_currentForegroundSprite];
                                }
                                break;
                                case 5:
                                if (_scrolling.percentage < 0.67f)
                                {
                                    _currentForegroundSprite--;
                                    _backgroundrenderers[i].sprite = _foregroundSprites[_currentForegroundSprite];
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
