using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vjezba0910.Dao;

namespace Vjezba0910.ViewModel
{
    public enum FILETYPE
    {
        JPEG, TIFF, PNG, SVG, GIF 
    }
    public class ItemsViewModel
    {
        public const string ForwardSlash = "/";

        public ObservableCollection<string> Directories{ get; }
        public ObservableCollection<BlobItem> Items{ get; }
        public string Directory 
        {
            get => directory; 
            set 
            {
                directory = value;
                Refresh();
            } 
        }

        public ItemsViewModel()
        {
            Items = new ObservableCollection<BlobItem>();
            Directories = new ObservableCollection<string>();
            Refresh();
        }

        private void Refresh()
        {
            Items.Clear();
            Directories.Clear();
            Repository.Container.GetBlobs().ToList().ForEach(item =>
            {
                if (item.Name.Contains(ForwardSlash))
                {
                    string dir = item.Name.Substring(0, item.Name.LastIndexOf(ForwardSlash));

                    if (!Directories.Contains(dir))
                    {
                        Directories.Add(dir); 
                    }
                }
                if (string.IsNullOrEmpty(Directory) && !item.Name.Contains(ForwardSlash))
                {
                    Items.Add(item);
                }
                else if (!string.IsNullOrEmpty(Directory) && item.Name.StartsWith($"{Directory}{ForwardSlash}"))
                {
                    Items.Add(item);
                }
            });
            
        }

        public async Task UploadAsync(string path)
        {
            string filename = 
                $"{Path.GetExtension(path).Remove(0, 1)}" +
                $"{ForwardSlash}" +
                $"{path.Substring(path.LastIndexOf(Path.DirectorySeparatorChar) + 1)}";        

            using (var fs = File.OpenRead(path))
            {
                await Repository.Container.GetBlobClient(filename).UploadAsync(fs, true);
            }
            Refresh();
        }

        public async Task DownloadAsync(BlobItem item, string path)
        {            
            using (var fs = File.OpenWrite(path))
            {
                await Repository.Container.GetBlobClient(item.Name).DownloadToAsync(fs);
            }
            Refresh();
        }

        public async Task DeleteAsync(BlobItem item)
        {            
            await Repository.Container.GetBlobClient(item.Name).DeleteAsync();            
            Refresh();
        }

        private string directory;
    }
}
