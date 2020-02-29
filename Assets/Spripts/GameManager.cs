﻿using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] notes;
    private float[] _timing;
    private int[] _lineNum;

    public string filePass;
    private int _notesCount = 0;

    private AudioSource _audioSource;
    private float _startTime = 0;

    public float timeOffset = -1;

    private bool _isPlaying = false;
    public GameObject startButton;


    void Start()
    {
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        _timing = new float[1024];
        _lineNum = new int[1024];
        LoadCSV();
    }

    void Update()
    {
        if (_isPlaying)
        {
            CheckNextNotes();
        }

    }

    public void StartGame()
    {
        startButton.SetActive(false);
        _startTime = Time.time;
        _audioSource.Play();
        _isPlaying = true;
    }

    void CheckNextNotes()
    {
        while (_timing[_notesCount] + timeOffset < GetMusicTime() && _timing[_notesCount] != 0)
        {
            SpawnNotes(_lineNum[_notesCount]);
            _notesCount++;
        }
    }

    void SpawnNotes(int num)
    {
        //Debug.Log(num);
        switch (num)
        {
            case 0:
                Instantiate(notes[0], new Vector3(-2, 0.5f,15), Quaternion.identity);
                break;
            case 1:
                Instantiate(notes[1], new Vector3(-1,0.5f,15), Quaternion.identity);
                break;
            case 2:
                Instantiate(notes[2], new Vector3(0,0.5f,15), Quaternion.identity);
                break;
            case 3:
                Instantiate(notes[3], new Vector3(1,0.5f,15), Quaternion.identity);
                break;
            case 4:
                Instantiate(notes[4], new Vector3(2, 0.5f,15), Quaternion.identity);
                break;

        }

        //Instantiate(notes[num],new Vector3(-4.0f + (5.0f * num), 10.0f, 0),Quaternion.identity);
    }

    void LoadCSV()
    {

        TextAsset csv = Resources.Load(filePass) as TextAsset;
        Debug.Log(csv.text);
        StringReader reader = new StringReader(csv.text);

        int i = 0;
        while (reader.Peek() > -1)
        {

            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                _timing[i] = float.Parse(values[0]);
                _lineNum[i] = int.Parse(values[1]);
            }
            i++;
        }
    }

    float GetMusicTime()
    {
        return Time.time - _startTime;
    }
}
