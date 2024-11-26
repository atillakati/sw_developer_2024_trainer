namespace Wifi.PlaylistEditor.AdditionalRepositories.Json.Entities
{
    internal class PlaylistEntity
    {
        public int FileVersion { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CreateDate { get; set; }
        public string ClientApp { get; set; }
        public ItemEntity[] Items { get; set; }
    }

}
