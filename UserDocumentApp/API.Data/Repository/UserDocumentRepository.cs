using API.Core.IRepository;
using API.Core.Models;
using API.Data.Models;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class UserDocumentRepository : IUserDocumentRepository
    {
        readonly UserDocumentDBContext _dbContext;
        public UserDocumentRepository(UserDocumentDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDocumentReq"></param>
        /// <returns></returns>
        public async Task<int> Add(UserDocumentRequest userDocumentReq)
        {
            int result = 0;
            User user = new User() { Name = userDocumentReq.UserName };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            if (user.UserId > 0)
            {
                Document document = new Document()
                {
                    FileName = userDocumentReq.DocumentName,
                    Path = userDocumentReq.DocumentPath,
                    UserId = user.UserId
                };

                await _dbContext.Documents.AddAsync(document);
                result = await _dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<int> Delete(int documentID)
        {
            int result = 0;

            Document document = await _dbContext.Documents.SingleOrDefaultAsync(x => x.DocumentId == documentID);
            if (document != null)
            {
                document.IsActive = false;
                _dbContext.Documents.Update(document);
                result = await _dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IList<UserDocumentViewModel>> GetAll()
        {
            return await (from user in _dbContext.Users
                          join doc in _dbContext.Documents on user.UserId equals doc.UserId
                          where doc.IsActive == true
                          select new UserDocumentViewModel
                          {
                              DocumentID = doc.DocumentId,
                              DocumentName = doc.FileName,
                              DocumentPath = doc.Path,
                              UserName = user.Name,
                              DocumentUploadedDateTime = doc.CreatedDate
                          }).ToListAsync();
        }
    }
}
