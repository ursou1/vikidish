using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Controllers
{
    public class JsonDB<T> : IDB<T> where T :DBOject
    {
        string pathJson;
        int autoincrement;

        public JsonDB(string pathJson)
        {
            this.pathJson = pathJson;
            if (!File.Exists(pathJson))
            {
                autoincrement = 1;
                Save(new List<T>());
                return;
            }
            using (var f = File.OpenRead(pathJson))
            using (var br = new BinaryReader(f))
            {
                autoincrement = br.ReadInt32();
            }
        }

        public void Update(T obj)
        {
            var all = GetAll().ToList();
            var edit = all.FirstOrDefault(g => g.ID == obj.ID);
            if (edit == null)
                return;
            all.Remove(edit);
            all.Add(obj);
            Save(all);
        }

        public T Create()
        {
            T obj =(T)Activator.CreateInstance(typeof(T));
            obj.ID = autoincrement++;
            var all = GetAll().ToList();
            all.Add(obj);
            Save(all);
            return obj;
        }


        public void Delete(T obj)
        {
            var all = GetAll().ToList();
            var edit = all.FirstOrDefault(g => g.ID == obj.ID);
            if (edit == null)
                return;
            all.Remove(edit);
            Save(all);
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> result = null;
            using (var f = File.OpenRead(pathJson))
            using (var br = new BinaryReader(f))
            {
                f.Seek(4, SeekOrigin.Begin);
                result = (List<T>)
                JsonSerializer.Deserialize(br.ReadString(), typeof(List<T>));
            }
            return result;
        }

       

        void Save(List<T> all)
        {
            using (var fs = File.Create(pathJson))
            using (var bw = new BinaryWriter(fs))
            {
                bw.Write(autoincrement);
                bw.Write(JsonSerializer.Serialize(all));
            }
        }

        

        
    }
}
