using Unreal.Core.Contracts;
using Unreal.Core.Models;

namespace PavlovReplayReader.Models.Events;

public abstract class BaseEvent : IEvent
{
    public EventInfo Info { get; set; }
}