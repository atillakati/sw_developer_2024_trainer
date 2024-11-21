namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistRepository : IFileTypeInfo
    {        
        IPlaylist Load(string filePath);

        void Save(IPlaylist playlist, string filePath);
    }
}
