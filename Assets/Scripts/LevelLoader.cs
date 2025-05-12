using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader mInstance;

    public List<GameObject> mCoins;

    private SaveSystem mSaveSystem;

    private void Awake()
    {
        mInstance = this;
    }

    private void Start()
    {
        mSaveSystem = SaveSystem.instance;
        LoadLevel();
    }

    private void LoadLevel()
    {
        if (mSaveSystem.HasASave(PlayerPrefs.GetInt("SaveIndex")))
        {
            foreach (GameObject coin in mCoins)
            {
                Debug.Log("destroy coin");
                Destroy(coin);
            }

            mCoins.Clear();

            foreach (ActorInfo coin in mSaveSystem.data.levelInfo.CoinsInfos)
            {
                mCoins.Add(Instantiate(Resources.Load<GameObject>("coin"), new Vector3(coin.x, coin.y, 0), Quaternion.identity));
            }
        }        
    }

}
