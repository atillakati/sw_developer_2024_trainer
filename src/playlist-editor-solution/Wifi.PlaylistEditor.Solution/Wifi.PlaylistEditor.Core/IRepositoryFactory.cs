namespace Wifi.PlaylistEditor.Core
{
    public interface IRepositoryFactory
    {
        IPlaylistRepository Create(string filePath);
    }
}
