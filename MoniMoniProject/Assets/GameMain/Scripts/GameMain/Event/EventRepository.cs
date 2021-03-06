﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// イベントにtagをつけて管理するクラス
/// </summary>
public class EventRepository : MonoBehaviour
{
    [SerializeField]
    EventsCreate events;

    public delegate int EventFunc();
    Dictionary<int, List<EventFunc>> eventdic = new Dictionary<int, List<EventFunc>>();
    Dictionary<int, EventTriggerType> event_trigger_type = new Dictionary<int, EventTriggerType>();

    public enum EventTriggerType
    {
        CHECK,
        OVERLAP,
    }

    void Awake()
    {
        schoolEventSetup();
    }

    void schoolEventSetup()
    {
        eventAdd(0, new List<EventFunc> { events.schoolEvent01 }, EventTriggerType.OVERLAP);

        //eventAdd(1, new List<EventFunc> { events.playerZombieHand1, events.playerZombieHand2 }, EventTriggerType.OVERLAP);
        eventAdd(1, new List<EventFunc> { events.schoolEvent02 }, EventTriggerType.CHECK);

        eventAdd(2, new List<EventFunc> { events.schoolEvent03 }, EventTriggerType.CHECK);
        eventAdd(3, new List<EventFunc> { events.schoolEvent04 }, EventTriggerType.OVERLAP);
        eventAdd(4, new List<EventFunc> { events.schoolEvent05, events.schoolEvent05, events.schoolEvent05_3 }, EventTriggerType.CHECK);
        eventAdd(5, new List<EventFunc> { events.schoolEvent06,events.schoolEvent06_2 }, EventTriggerType.CHECK);
        eventAdd(6, new List<EventFunc> { events.schoolEvent07, events.schoolEvent07_2 }, EventTriggerType.CHECK);
        eventAdd(7, new List<EventFunc> { events.schoolEvent08, events.schoolEvent08_2 }, EventTriggerType.CHECK);
        eventAdd(8, new List<EventFunc> { events.schoolEvent09,events.schoolEvent09_2 }, EventTriggerType.CHECK);
        eventAdd(9, new List<EventFunc> { events.schoolEvent10 }, EventTriggerType.CHECK);
        eventAdd(10, new List<EventFunc> { events.schoolEvent11,events.schoolEvent11_2,events.schoolEvent11_3}, EventTriggerType.CHECK);
        eventAdd(11, new List<EventFunc> { events.schoolEvent12 }, EventTriggerType.CHECK);
        eventAdd(12, new List<EventFunc> { events.schoolEvent13 }, EventTriggerType.CHECK);
        eventAdd(13, new List<EventFunc> { events.schoolEvent14 }, EventTriggerType.CHECK);
        eventAdd(14, new List<EventFunc> { events.schoolEvent15 }, EventTriggerType.CHECK);
        eventAdd(15, new List<EventFunc> { events.schoolEvent16 }, EventTriggerType.CHECK);
        eventAdd(16, new List<EventFunc> { events.schoolEvent17 }, EventTriggerType.CHECK);
        eventAdd(17, new List<EventFunc> { events.schoolEvent18 }, EventTriggerType.CHECK);
        eventAdd(18, new List<EventFunc> { events.schoolEvent19 }, EventTriggerType.CHECK);
        eventAdd(19, new List<EventFunc> { events.schoolEvent20 }, EventTriggerType.CHECK);
        eventAdd(20, new List<EventFunc> { events.schoolEvent21 }, EventTriggerType.CHECK);
        eventAdd(21, new List<EventFunc> { events.schoolEvent22 }, EventTriggerType.CHECK);
        eventAdd(22, new List<EventFunc> { events.schoolBossEvent }, EventTriggerType.CHECK);
    }

    /// <summary>
    /// イベント登録関数
    /// </summary>
    /// <param name="key_">イベントの番号</param>
    /// <param name="func_">イベントの関数</param>
    /// <param name="trigger_type_">トリガーの種類( 調べる系(0), 通過系(1) )</param>
    void eventAdd(int key_, List<EventFunc> func_, EventTriggerType trigger_type_)
    {
        eventdic.Add(key_, func_);
        event_trigger_type.Add(key_, trigger_type_);

    }

    /// <summary>
    /// イベント取得関数
    /// </summary>
    /// <param name="tag_">イベントのタグ</param>
    /// <returns>イベント関数</returns>
    public List<EventFunc> getEvent(int tag_)
    {
        List<EventFunc> func = eventdic[tag_];
        if (func.Count <= 0)
        {
            Debug.Assert(false, "Not Event Find!!");
        }
        return eventdic[tag_];
    }

    /// <summary>
    /// イベントのトリガー取得関数
    /// </summary>
    /// <param name="key_">トリガーの種類</param>
    /// <returns></returns>
    public EventTriggerType getEventTriggerType(int key_)
    {
        return event_trigger_type[key_];
    }
}
