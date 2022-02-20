using DIO.Series.Interfaces;
namespace DIO.Series.Classes
{
    public class SerieRepository : IRepository<Serie>
    {

        private Dictionary<Guid, Serie> dictionarySerie = new Dictionary<Guid, Serie>();

        public void Delete(Guid id)
        {
            if (ValidateSerieID(id))
                dictionarySerie[id].Excluir();
        }

        public void Insert(Serie entity)
        {
            dictionarySerie.Add(entity.Id, entity);
        }

        public Dictionary<Guid, Serie> Dictionary()
        {
            Dictionary<Guid, Serie> cleanDictionary = new Dictionary<Guid, Serie>();
            foreach (KeyValuePair<Guid, Serie> serie in dictionarySerie)
            {
                if (!serie.Value.Excluido)
                    cleanDictionary.Add(serie.Key, serie.Value);
            }
            return cleanDictionary;
        }

        public Guid NextId()
        {
            throw new NotImplementedException();
        }

        ///Throws ArgumentException.
        public Serie ReturnByID(Guid id)
        {
            if (ValidateSerieID(id))
                return dictionarySerie[id];
            else
                throw new ArgumentException("ID (GUID) de série inválida.");
        }

        public void Update(Guid id, Serie entity)
        {
            if (ValidateSerieID(id))
                dictionarySerie[id] = entity;
        }

        private bool ValidateSerieID(Guid id)
        {
            if (dictionarySerie.TryGetValue(id, out Serie serie))
            {
                if (serie.Excluido)
                {
                    Console.WriteLine($"A série associada à chave GUID informada foi excluída.{Environment.NewLine}GUID Inválida: {id}");
                    return false;
                }
                return true;
            }
            else
            {
                Console.WriteLine($"Não foram encontradas séries associadas à chave GUID informada.{Environment.NewLine}GUID Inválida: {id}");
                return false;
            }
        }
    }
}