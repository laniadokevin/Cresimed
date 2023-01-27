using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using TestYourself.Core.Services;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Interfaces
{
    public interface IKeyWordRepository : IGenericService<KeyWord>
    {

        KeyWord GetById(int id);
        List<KeyWord> GetAll ();
        KeyWord GetOrSave(KeyWord keyWord);
        List<KeyWord> GetKeyWordsForQuestion(int id);
        int UpdateKeyWord(KeyWord keyWord);
        int DeleteKeyWord(int id);


    }
}
