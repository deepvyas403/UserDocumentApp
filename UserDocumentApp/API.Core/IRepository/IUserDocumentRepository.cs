using API.Core.Models;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.IRepository
{
    public interface IUserDocumentRepository
    {
        Task<IList<UserDocumentViewModel>> GetAll();

        Task<int> Delete(int documentID);

        Task<int> Add(UserDocumentRequest userDocumentReq);
    }
}
