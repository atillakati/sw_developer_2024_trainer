using System;

namespace Wifi.PlaylistEditor.Core
{
    public interface IRefreshableItem
    {
        event EventHandler ItemUpdated;
    }
}
