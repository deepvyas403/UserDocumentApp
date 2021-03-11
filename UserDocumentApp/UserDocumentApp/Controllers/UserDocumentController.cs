using API.Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.Models;
using System.IO;
using System.Net.Http.Headers;

namespace API.Controllers
{
    [Route("api/UserDocument")]
    [ApiController]
    public class UserDocumentController : ControllerBase
    {
        readonly IUserDocumentRepository _userDocumentRepository;
        public UserDocumentController(IUserDocumentRepository userDocumentRepository)
        {
            _userDocumentRepository = userDocumentRepository;
        }

        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To get user documents
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUserDocuments()
        {
            try
            {
                var userDocuments = await _userDocumentRepository.GetAll();
                if (userDocuments == null)
                {
                    return NotFound();
                }
                return Ok(userDocuments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To add user documents
        /// </summary>
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> AddUserDocument(UserDocumentRequest userDocumentRequest)
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = "DocBank";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    userDocumentRequest.DocumentPath = fullPath;
                }

                int result = await _userDocumentRepository.Add(userDocumentRequest);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To delete user document
        /// </summary>
        [Route("{documentID}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserDocument(int documentID)
        {
            try
            {
                int result = await _userDocumentRepository.Delete(documentID);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
