using System.Windows.Forms;
using Wifi.PlaylistEditor.CommonTypes;

namespace Wifi.PlaylistEditor
{
    internal class DummyPlaylistGenerator : ICreatePlaylist
    {
        public string Title => "Meine Top Hits 1980";

        public string Author => "Dj Gandalf";

        public DialogResult StartDialog()
        {
            return DialogResult.OK;
        }
    }
}
