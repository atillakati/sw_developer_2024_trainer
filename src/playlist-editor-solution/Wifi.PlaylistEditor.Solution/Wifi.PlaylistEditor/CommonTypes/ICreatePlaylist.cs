using System.Windows.Forms;

namespace Wifi.PlaylistEditor.CommonTypes
{
    internal interface ICreatePlaylist
    {
        string Title { get; }
        string Author { get; }

        DialogResult StartDialog();
    }
}
