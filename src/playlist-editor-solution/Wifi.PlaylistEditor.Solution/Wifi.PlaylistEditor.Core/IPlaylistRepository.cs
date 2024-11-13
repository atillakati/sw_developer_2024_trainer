namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistRepository : IFileDescriptor
    {
        IPlaylist Load(string filePath);

        void Save(IPlaylist playlist, string filePath);
    }
}
