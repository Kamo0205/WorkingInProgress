using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public interface TemplateDataReciever
    {
        Dictionary<string, string> getData(object obj);
        object[] Get();
        void Add(Dictionary<string, string> entity);
        void Update(object oldData, Dictionary<string, string> newData);
        void Remove(string id);
    }
}
