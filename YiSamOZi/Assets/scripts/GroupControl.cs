using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yisamozi.model;   

[System.Serializable]
public class GroupControl : MonoBehaviour{
    public List<Wave> waveList;

    public float test;
    public float deltaLine;

    private Transform camera_trans;
    private float enemyTriggerLine;//跨过该坐标生成怪物
    private float waveStartTime;
    private int waveIndex;

    // Use this for initialization

    public int WaveIndex
    {
        get { return waveIndex; }
        set{
            waveIndex = value;
        }
    }

    void Start () {
        camera_trans = Camera.main.GetComponent<Transform>();
        enemyTriggerLine = camera_trans.position.y + deltaLine;
        waveIndex = 0;
        if (waveList.Count> 0)
        {
            waveStartTime = Time.time+waveList[waveIndex].waitForStart;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (camera_trans.position.y > enemyTriggerLine&&Time.time>waveStartTime)
        {
            
            enemyTriggerLine = camera_trans.position.y + deltaLine;
            if (!initEnemy(enemyTriggerLine, waveIndex))
            {
                waveIndex++;
                waveStartTime = Time.time + waveList[waveIndex].waitForStart;
            }
            
        }
        if (deltaLine > 10)
        {
            Debug.Log("1111");
        }

    }   

    //生成敌人，当对象池数量为空时返回false反之返回true
    private bool initEnemy(float posY,int waveIndex)
    {
        //int posProRes = Random.Range(-1, 2);
        //float typeProRes = Random.Range(0, 1f);
        //float formaProRes = Random.Range(0, 1f);
        //Debug.Log(posFac);
        //Vector3 m_pos = new Vector3(posProRes * StaticVar.WIDTH / 3, posY, 0);
        //GameObject enemy = Instantiate(poolList[waveIndex].iniReList[0].enemy, m_pos, Quaternion.identity);
        return true;
    }
}
