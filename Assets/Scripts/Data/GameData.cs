using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public class GameData 
{
    public static void SaveDataHPPlayer(int hP)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dataHPPlayer.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        HPPlayer hPPlayer = new HPPlayer(hP);
        binaryFormatter.Serialize(stream, hPPlayer);
        stream.Close();
    }
    public static HPPlayer hPPlayer()
    {
        string path = Application.persistentDataPath + "/dataHPPlayer.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HPPlayer hPPlayer = binaryFormatter.Deserialize(stream) as HPPlayer;
            stream.Close();
            return hPPlayer;
        }
        else
            return null;
    }




    public static void SaveDataMaxHPPlayer(int maxHP)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dataMaxHPPlayer.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        MaxHPPlayer maxHPPlayer = new MaxHPPlayer(maxHP);
        binaryFormatter.Serialize(stream, maxHPPlayer);
        stream.Close();
    }
    public static MaxHPPlayer MaxHPPlayer()
    {
        string path = Application.persistentDataPath + "/dataMaxHPPlayer.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            MaxHPPlayer maxHPPlayer = binaryFormatter.Deserialize(stream) as MaxHPPlayer;
            stream.Close();
            return maxHPPlayer;
        }
        else
            return null;
    }



    public static void SaveDataDamgeSwordPlayer(float damge)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dataSaveDataDamgeSwordPlayer.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        DamgeSword damgeSword = new DamgeSword(damge);
        binaryFormatter.Serialize(stream, damgeSword);
        stream.Close();
    }
    public static DamgeSword damgeSword()
    {
        string path = Application.persistentDataPath + "/dataSaveDataDamgeSwordPlayer.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DamgeSword damgeSword = binaryFormatter.Deserialize(stream) as DamgeSword;
            stream.Close();
            return damgeSword;
        }
        else
            return null;
    }

    public static void SaveDataDamgeMagicdPlayer(float damge)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dataSaveDataDamgeMagicPlayer.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        DamgeMagic damgeMagic = new DamgeMagic(damge);
        binaryFormatter.Serialize(stream, damgeMagic);
        stream.Close();
    }
    public static DamgeMagic damgeMagic()
    {
        string path = Application.persistentDataPath + "/dataSaveDataDamgeMagicPlayer.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DamgeMagic damgeMagic = binaryFormatter.Deserialize(stream) as DamgeMagic;
            stream.Close();
            return damgeMagic;
        }
        else
            return null;
    }


    public static void SaveDataSpeedSpawnMagicBall(int speed)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dataSaveDataSpeedSpawnMagicBall.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        SpeedSpawnMagicBall speedSpawnMagicBall = new SpeedSpawnMagicBall(speed);
        binaryFormatter.Serialize(stream, speedSpawnMagicBall);
        stream.Close();
    }
    public static SpeedSpawnMagicBall speedSpawnMagicBall()
    {
        string path = Application.persistentDataPath + "/dataSaveDataSpeedSpawnMagicBall.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SpeedSpawnMagicBall speedSpawnMagicBall = binaryFormatter.Deserialize(stream) as SpeedSpawnMagicBall;
            stream.Close();
            return speedSpawnMagicBall;
        }
        else
            return null;
    }

    public static void SaveDataSpeedMagicBall(float speed)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dataSaveDataSpeedMagicBall.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        SpeedMagicBall speedMagicBall = new SpeedMagicBall(speed);
        binaryFormatter.Serialize(stream, speedMagicBall);
        stream.Close();
    }
    public static SpeedMagicBall speedMagicBall()
    {
        string path = Application.persistentDataPath + "/dataSaveDataSpeedMagicBall.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SpeedMagicBall speedMagicBall = binaryFormatter.Deserialize(stream) as SpeedMagicBall;
            stream.Close();
            return speedMagicBall;
        }
        else
            return null;
    }


    public static void SaveDataLevelPlayer(int level)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dataSaveDataLevelPlayer.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        LevelPlayer levelPlayer = new LevelPlayer(level);
        binaryFormatter.Serialize(stream, levelPlayer);
        stream.Close();
    }
    public static LevelPlayer levelPlayer()
    {
        string path = Application.persistentDataPath + "/dataSaveDataLevelPlayer.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelPlayer levelPlayer = binaryFormatter.Deserialize(stream) as LevelPlayer;
            stream.Close();
            return levelPlayer;
        }
        else
            return null;
    }

    public static void SaveDataExpPlayer(float exp)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dataSaveDataExpPlayer.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        ExpPlayer expPlayer = new ExpPlayer(exp);
        binaryFormatter.Serialize(stream, expPlayer);
        stream.Close();
    }
    public static ExpPlayer expPlayer()
    {
        string path = Application.persistentDataPath + "/dataSaveDataExpPlayer.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ExpPlayer expPlayer = binaryFormatter.Deserialize(stream) as ExpPlayer;
            stream.Close();
            return expPlayer;
        }
        else
            return null;
    }
}
