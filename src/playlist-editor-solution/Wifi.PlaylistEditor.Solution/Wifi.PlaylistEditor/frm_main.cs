using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wifi.PlaylistEditor.CommonTypes;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.Factories;
using Wifi.PlaylistEditor.Properties;

namespace Wifi.PlaylistEditor
{
    internal partial class frm_main : Form
    {
        private ICreatePlaylist _createNewPlaylistDialog;
        private IPlaylistFactory _playlistFactory;
        private IPlaylistItemFactory _playlistItemFactory;
        private IRepositoryFactory _repositoryFactory;

        private IPlaylist _playlist;

        public frm_main(ICreatePlaylist createPlaylist, 
                        IPlaylistFactory playlistFactory, 
                        IPlaylistItemFactory playlistItemFactory, 
                        IRepositoryFactory repositoryFactory)
        {
            InitializeComponent();

            _createNewPlaylistDialog = createPlaylist;
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
            _repositoryFactory = repositoryFactory;            
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
                viewItem.Tag = playlistItem;

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
            //configure open file dialog
            ConfigureFileDialog(openFileDialog, "Select item for playlist", _playlistItemFactory.AvailableTypes);

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
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

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedItems();
        }
        
        private void frm_main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                DeleteSelectedItems();
            }
        }

        private void DeleteSelectedItems()
        {
            if (lst_items.SelectedItems == null || lst_items.SelectedItems.Count == 0)
            {
                return;
            }

            foreach (ListViewItem viewItem in lst_items.SelectedItems)
            {
                var playlistItem = viewItem.Tag as IPlaylistItem;
                if (playlistItem != null)
                {
                    _playlist.Remove(playlistItem);
                }
            }

            UpdateMetaDataView();
            UpdateItemsView();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Wollen Sie wirklich die Playlist leeren?", "Playlist leeren",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _playlist.Clear();

                UpdateMetaDataView();
                UpdateItemsView();
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //configure save file dialog
            ConfigureFileDialog(saveFileDialog, "Save playlist as", _repositoryFactory.AvailableTypes);

            //select file to save as
            if(saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //save file
            var repository = _repositoryFactory.Create(saveFileDialog.FileName);
            if(repository != null)
            {
                repository.Save(_playlist, saveFileDialog.FileName);
            }
        }

        private void ConfigureFileDialog(FileDialog fileDialog, string title, IEnumerable<IFileTypeInfo> availableTypes)
        {
            fileDialog.Title = title;
            if (_playlist != null)
            {
                fileDialog.FileName = _playlist.Title;
            }
            fileDialog.Filter = CreateFilterString(availableTypes);
            fileDialog.FilterIndex = 1;
        }

        private string CreateFilterString(IEnumerable<IFileTypeInfo> availableTypes)
        {
            string filter = string.Empty;
            string allSupportedFilesFilter = string.Empty;

            //"BMP Files|*.bmp|GIF Files|*.gif
            //"All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff"
            foreach (var type in availableTypes)
            {
                filter += $"{type.Description}|*{type.Extension}|";
                allSupportedFilesFilter += $"*{type.Extension};";
            }

            //add all supported files filter
            filter = $"All supported files|{allSupportedFilesFilter}|" + filter;

            //remove last pipe (;)
            filter = filter.Remove(filter.Length - 1);

            return filter;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //configure open file dialog
            ConfigureFileDialog(openFileDialog, "Select playlist file", 
                                _repositoryFactory.AvailableTypes);

            //select playlist file to load
            if(openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //load playlist
            var repository = _repositoryFactory.Create(openFileDialog.FileName);
            if(repository != null)
            {
                _playlist = repository.Load(openFileDialog.FileName);

                //update view
                UpdateMetaDataView();
                UpdateItemsView();
                EnablePlaylistMenu(true);
                EnableItemsMenu(true);
            }
        }
    }
}
