﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Locations { SweetHome, Library, LectureRoom, PCRoom, Pub};
    public class GameController : MonoBehaviour
    {

    [SerializeField]
    private string[] arrayStudents;
    [SerializeField]
    private GameObject studentPrefab;
    private List<BaseGameEntity> entitys;

    private static bool IsGameStop { set; get; } = false;

    private void Awake()
    {
        entitys = new List<BaseGameEntity>();

        for (int i = 0; i < arrayStudents.Length; i++)
        {
            GameObject clone = Instantiate(studentPrefab);
            Student entity = clone.GetComponent<Student>();
            entity.Setup(arrayStudents[i]);
            entitys.Add(entity);
        }
       
    }

    private void Update()
    {
        if (IsGameStop == true) return;

        for (int i = 0; i < entitys.Count; i++)
        {
            entitys[i].Updated();
        }
    }

    public static void Stop(BaseGameEntity entity)
    {
        IsGameStop = true;

        entity.PrintText("프로그램 종료");
    }
}

