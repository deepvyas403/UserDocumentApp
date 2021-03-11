using API.Core.IRepository;
using API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Data.Repository
{
    public class DocumentRepository : IDataRepository<Document>
    {
        readonly UserDocumentDBContext _dbContext;
        public DocumentRepository(UserDocumentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Document document)
        {
            _dbContext.Documents.Add(document);
            _dbContext.SaveChanges();
        }

        public void Delete(Document document)
        {
            Document documentInfo = this.Get(document.DocumentId);
            documentInfo.IsActive = false;
            _dbContext.SaveChanges();
        }

        public Document Get(int id)
        {
            return _dbContext.Documents.FirstOrDefault(x => x.DocumentId == id);
        }

        public IEnumerable<Document> GetAll()
        {
            return _dbContext.Documents.Select(x => Convert.ToBoolean(x.IsActive)) as IEnumerable<Document>;
        }
    }
}
