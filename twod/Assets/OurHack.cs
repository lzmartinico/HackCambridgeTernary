using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurHack {
    static float[] LHorizontal = new float[4];
    static float[] LVe = new float[4];
    static float[] RHo = new float[4];
    static float[] RVe = new float[4];

    public static float sens = 40;

    public static float getLH(int port)
    {
        return LHorizontal[port-25000];
    }
    public static void setLH(float LH, int port)
    {
        LHorizontal[port - 25000] = LH;
    }

    public static float getLV(int port)
    {
        return LVe[port - 25000];
    }
    public static void setLV(float LH, int port)
    {
        LVe[port - 25000] = LH;
    }

    public static float getRH(int port)
    {
        return RHo[port - 25000];
    }
    public static void setRH(float LH, int port)
    {
        RHo[port - 25000] = LH;
    }

    public static float getRV(int port)
    {
        return RVe[port - 25000];
    }
    public static void setRV(float LH, int port)
    {
        RVe[port - 25000] = LH;
    }
}


