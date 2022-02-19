using DIO.Series.Interfaces;
namespace DIO.Series.Classes
{
    public class SerieRepository : IRepository<Serie>
    {

        private Dictionary<Guid, Serie> dictionarySerie = new Dictionary<Guid, Serie>();

        public void Delete(Guid id)
        {
            dictionarySerie[id].Excluir();
        }

        public void Insert(Serie entity)
        {
            dictionarySerie.Add(entity.Id, entity);
        }

        public Dictionary<Guid, Serie> Dictionary()
        {
            Dictionary<Guid, Serie> cleanDictionary = new Dictionary<Guid, Serie>();
            foreach(KeyValuePair<Guid, Serie> serie in dictionarySerie)
            {
                if (!serie.Value.Excluido)
                    cleanDictionary.Add(serie.Key, serie.Value);
            }
            return cleanDictionary;
        }

        public Guid NextId()
        {
            //throw new NotImplementedException();
        }

        public Serie ReturnByID(Guid id)
        {
            if(dictionarySerie[id].Excluido)
                throw new UnauthorizedAccessException("Essa Série Foi Excluída e Não Se Encontra Mais Disponível.");
            
            return dictionarySerie[id];
        }

        public void Update(Guid id, Serie entity)
        {
            dictionarySerie[id] = entity;
        }
    }
}