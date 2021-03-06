﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StagingController : MonoBehaviour
{
    [SerializeField]
    GameObject stagingcanvas;
    [SerializeField]
    Image fadeblack;

    [SerializeField]
    Image fadewhite;

    int fadecount;
    public int fadetime;
    public float fadespeed;

    void Awake()
    {
        fadecount = 0;
        fadetime = 150;
        stagingcanvas.SetActive(true);
    }


    void Update()
    {
        if (fadecount < fadetime)
        {
            fadecount++;
            var color = fadeblack.color;
            color.a -= fadespeed;
            fadeblack.color = color;
        }
        else if (fadecount == fadetime)
        {
            stagingcanvas.SetActive(false);
            fadecount++;
        }
    }

    public int flushcount = 0;
    public bool flushStart()
    {
        if (flushcount < 80)
        {
            stagingcanvas.SetActive(true);
            var color = fadewhite.color;
            color.a += 0.05f;
            if (color.a >= 1.0f)
                color.a = 1.0f;
            fadewhite.color = color;
            flushcount++;
            return false;
        }
        flushcount = 0;
        return true;
    }
    public bool flushEnd()
    {
        if (flushcount < 80)
        {
            var color = fadewhite.color;
            color.a -= 0.05f;
            if (color.a <= 0.0f)
                color.a = 0.0f;
            fadewhite.color = color;
            flushcount++;
            return false;
        }
        flushcount = 0;
        stagingcanvas.SetActive(false);
        return true;
    }

    public bool fadeOutBlack()
    {
        if (flushcount < 200)
        {
            stagingcanvas.SetActive(true);
            var color = fadeblack.color;
            color.a += 0.01f;
            fadeblack.color = color;
            flushcount++;
            return false;
        }
        flushcount = 0;
        return true;
    }

    public bool fadeInBlack()
    {
        if (flushcount < 200)
        {
            var color = fadeblack.color;
            color.a -= 0.01f;
            fadeblack.color = color;
            flushcount++;
            return false;
        }
        flushcount = 0;
        stagingcanvas.SetActive(false);
        return true;
    }

}
