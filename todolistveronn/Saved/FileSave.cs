using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolistveronn.Saved
{
    internal class FileSave
    {
        private readonly string PATH;

        public FileSave(string path)
        {
            PATH = path;
        }
        public ObservableCollection<Taskl> LoadData()
        {
            var fileExi=File.Exists(PATH);
            if (!fileExi) {
                File.CreateText(PATH).Dispose();
                return new ObservableCollection<Taskl>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<Taskl>>(fileText);
            }
        }
        public void SaveData(ObservableCollection<Taskl> todoData)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoData);
                writer.WriteLine(output);
            }
        }
    }
}
 