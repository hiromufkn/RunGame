using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // プレイヤー
    private Transform player;

    // 50m区画を入れる配列
    private Transform[] sections;

    // 表示距離
    [Header("表示距離")]
    public float visibleDistance = 200f;

    // 通過後に消す距離
    [Header("後方削除距離")]
    public float removeDistance = 50f;

    // Destroyするか
    [Header("Destroyする？")]
    public bool destroySection = false;

    void Start()
    {
        // Playerタグ取得
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // 子オブジェクト数取得
        int childCount = transform.childCount;

        // 配列生成
        sections = new Transform[childCount];

        // 子を全部取得
        for (int i = 0; i < childCount; i++)
        {
            sections[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        foreach (Transform section in sections)
        {
            // Destroy後のエラー防止
            if (section == null)
                continue;

            // プレイヤーとのZ距離
            float distance =
                player.position.z - section.position.z;

            // 絶対距離
            float absDistance = Mathf.Abs(distance);

            // =========================
            // 200m以内なら表示
            // =========================

            if (absDistance <= visibleDistance)
            {
                if (!section.gameObject.activeSelf)
                {
                    section.gameObject.SetActive(true);
                }
            }
            else
            {
                if (section.gameObject.activeSelf)
                {
                    section.gameObject.SetActive(false);
                }
            }

            // =========================
            // 後方50m超えたら削除
            // =========================

            // distance > 0
            // → プレイヤーが前にいる

            if (distance > removeDistance)
            {
                if (destroySection)
                {
                    Destroy(section.gameObject);
                }
                else
                {
                    section.gameObject.SetActive(false);
                }
            }
        }
    }
}
