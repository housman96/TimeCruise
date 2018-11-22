using System;
using System.Collections.Generic;
using UnityEngine;

public class EventHandlerManager : MonoBehaviour {

    public static Dictionary<eventChannels, Dictionary<Enum, gameEventHandler>> ListenerFunctions = initializeDicts();

    public static void Broadcast(eventChannels evType, Enum ev, eventArgExtend e)
    {
        ListenerFunctions[evType][ev](e);
    }

    public static void AddListener(eventChannels evType, Enum ev, gameEventHandler eventListener)
    {
        ListenerFunctions[evType][ev] += eventListener;
    }
    public static void RemoveListener(eventChannels evType, Enum ev, gameEventHandler eventListener)
    {
        ListenerFunctions[evType][ev] -= eventListener;
    }

    public void OnDestroy()
    {
        ListenerFunctions = initializeDicts();
    }

    static Dictionary<eventChannels, Dictionary<Enum, gameEventHandler>> initializeDicts()
    {
        Dictionary<eventChannels, Array> enumChannelEventList = ChannelEnums.getChannelEnumList();
        Dictionary<eventChannels, Dictionary<Enum, gameEventHandler>> result = new Dictionary<eventChannels, Dictionary<Enum, gameEventHandler>>();
        foreach (var val in (eventChannels[])Enum.GetValues(typeof(eventChannels)))
        {
            result.Add(val, new Dictionary<Enum, gameEventHandler>());
            foreach (var ev in enumChannelEventList[val])
            {
                result[val].Add((Enum)ev, new gameEventHandler(delegate (eventArgExtend e) { }));
            }
        }
        return result;
    }
}

public enum eventChannels
{
    inGame
}

public enum inGameChannelEvents
{
    thing
}

public class eventArgExtend : System.EventArgs { }

public delegate void gameEventHandler(eventArgExtend e);

public class ChannelEnums
{
    public static Dictionary<eventChannels, System.Array> getChannelEnumList()
    {

        Dictionary<eventChannels, System.Array> enumChannelEventList = new Dictionary<eventChannels, System.Array>();
        enumChannelEventList.Add(eventChannels.inGame, System.Enum.GetValues(typeof(inGameChannelEvents)));
        return enumChannelEventList;
    }
}