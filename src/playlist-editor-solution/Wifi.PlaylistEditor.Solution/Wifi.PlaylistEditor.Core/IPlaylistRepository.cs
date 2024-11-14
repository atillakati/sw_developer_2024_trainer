namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistRepository 
    {
        IPlaylist Load(string filePath);

        void Save(IPlaylist playlist, string filePath);
    }
}
