﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDIeModel : BaseDice
{

    public float getForce()
    {
        return force;
    }

    public void setForce(float fc)
    {
        this.force = fc;
    }

    public float getTorque()
    {
        return torque;
    }

    public void setTorque(float tq)
    {
        this.torque = tq;
    }

    public int getRedValue()
    {
        return redValue;
    }

    public void setRedValue(int red)
    {
        this.redValue = red;
    }

    public int getGreenValue()
    {
        return greenValue;
    }

    public void setGreenValue(int green)
    {
        this.greenValue = green;
    }


    /* ************* Class Stuff ************/
    public void SetClassValue(int val)
    {
        classValue = val;
    }
    public int GetClassValue()
    {
        return classValue;
    }

    public void SetClassSum(int sum)
    {
        classSum = sum;
    }

    public int GetClassSum()
    {
        return classSum;
    }

    public string GetClassName()
    {
        return diceClassName;
    }


    /* *************** Level Stuff *********/
    public void SetLevelValue(int val)
    {
        levelValue = val;
    }
    public int GetLevelValue()
    {
        return levelValue;
    }
    public void SetLevelSum(int sum)
    {
        levelSum = sum;
    }

    public int GetLevelSum()
    {
        return levelSum;
    }

    public string GetLevelName()
    {
        return diceLevelName;
    }

    /* *************Blue Stuff ********/

    public int getBlueValue()
    {
        return blueValue;
    }
    public void setBlueValue(int blue)
    {
        this.blueValue = blue;
    }

    public int getRedSum()
    {
        return redSum;
    }
    public void setRedSum(int rs)
    {
        this.redSum = rs;
    }

    public int getBlueSum()
    {
        return blueSum;
    }

    public void setBlueSum(int bs)
    {
        this.blueSum = bs;
    }

    public int getGreenSum()
    {
        return greenSum;
    }

    public void setGreenSum(int gs)
    {
        this.greenSum = gs;
    }

   
    public void setRedDiceName(string redStringName)
    {
        this.redName = redStringName;
    }

    public string getRedDiceName()
    {
        return redName;
    }

    public void setBlueDiceName(string blueStringName)
    {
        this.blueName = blueStringName;
    }

    public string getBlueDiceName()
    {
        return blueName;
    }
    
    public void setGreenName(string greenStringName)
    {
        this.greenName = greenStringName;
    }

    public string getGreenName()
    {
        return greenName;
    }    
    
    public void resetDiceSums(int Sblue, int Sred, int Sgreen, int SClass, int SLevel)
    {
        this.redSum = Sred;
        this.blueSum = Sblue;
        this.greenSum = Sgreen;
        this.classSum = SClass;
        this.levelSum = SLevel;      
    }

    public void initialValues(string sGreen, string sRed, string sBlue, float sTorque, float sForce, 
        int sGreenValue, int sRedValue, int sBlueValue )
    {
        this.greenName = sGreen;
        this.redName = sRed;
        this.blueName = sBlue;
        this.torque = sTorque;
        this.force = sForce;
        this.greenValue = sGreenValue;
        this.blueValue = sBlueValue;
        this.redValue = sRedValue;
    }
}


