using System;
using System.Windows.Forms;
using Wifi.PlaylistEditor.CommonTypes;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.Factories;
using Wifi.PlaylistEditor.Properties;

namespace Wifi.PlaylistEditor
{
    public partial class frm_main : Form
    {
        private ICreatePlaylist _createNewPlaylistDialog;
        private IPlaylistFactory _playlistFactory;
        private IPlaylistItemFactory _playlistItemFactory;
        private IPlaylist _playlist;

        public frm_main()
        {
            InitializeComponent();

            //TODO Erzeugungsabhängigkeit!!!  
            //_createNewPlaylistDialog = new frm_CreateNewPlaylist();
            _createNewPlaylistDialog = new DummyPlaylistGenerator();
            _playlistFactory = new PlaylistFactory();
            _playlistItemFactory = new PlaylistItemFactory();
        }        

        private void frm_main_Load(object sender, EventArgs e)
        {
            lbl_title.Text = string.Empty;

            lbl_author.Text = "-";
            lbl_createDate.Text = "-";
            lbl_totalDuration.Text = "00:00:00";

            EnablePlaylistMenu(false);
            EnableItemsMenu(false);
        }

        private void EnableItemsMenu(bool isItemsMenuEnabled)
        {
            itemsToolStripMenuItem.Enabled = isItemsMenuEnabled;
        }

        private void EnablePlaylistMenu(bool isSaveEnabled)
        {
            saveToolStripMenuItem.Enabled = isSaveEnabled;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            var result = _createNewPlaylistDialog.StartDialog();
            if(result == DialogResult.Cancel)
            {
                return;
            }

            _playlist = _playlistFactory.Create(_createNewPlaylistDialog.Title,
                                                _createNewPlaylistDialog.Author);

            UpdateMetaDataView();
            UpdateItemsView();

            EnableItemsMenu(true);
            EnablePlaylistMenu(true);
        }

        private void UpdateItemsView()
        {
            var imageIndex = 0;

            lst_items.Items.Clear();
            img_list.Images.Clear();

            foreach (var playlistItem in _playlist.Items)
            {
                var viewItem = new ListViewItem(playlistItem.ToString());
                viewItem.ImageIndex = imageIndex++;

                //add thumbnail into image list
                if (playlistItem.Thumbnail != null)
                {
                    img_list.Images.Add(playlistItem.Thumbnail);
                }
                else
                {
                    img_list.Images.Add(Resources.No_Image_Available);
                }

                lst_items.Items.Add(viewItem);
            }
        }

        private void UpdateMetaDataView()
        {
            lbl_title.Text = _playlist.Title;
            lbl_author.Text = _playlist.Author;
            lbl_createDate.Text = _playlist.DateOfCreation.ToShortDateString();
            lbl_totalDuration.Text = _playlist.Duration.ToString();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = true;

            if(openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            foreach (var selectedFile in openFileDialog.FileNames)
            {
                var playlistItem = _playlistItemFactory.Create(selectedFile);
                if(playlistItem != null)
                {
                    _playlist.Add(playlistItem);
                }
            }

            UpdateMetaDataView();
            UpdateItemsView();
        }
    }
}
