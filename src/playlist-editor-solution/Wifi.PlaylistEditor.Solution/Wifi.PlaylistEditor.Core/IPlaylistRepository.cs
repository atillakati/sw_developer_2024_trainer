namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistRepository 
    {
        string Extension { get; }

        string Description { get; }

        IPlaylist Load(string filePath);

        void Save(IPlaylist playlist, string filePath);
    }
}
