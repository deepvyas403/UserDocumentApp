using API.Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using API.Core.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using API.Core.Constants;
using System.Linq;

namespace API.Controllers
{
    [Route("api/UserDocument")]
    [ApiController]
    public class UserDocumentController : ControllerBase
    {
        readonly IUserDocumentRepository _userDocumentRepository;
        readonly IWebHostEnvironment _hostingEnvironment;

        public UserDocumentController(IUserDocumentRepository userDocumentRepository, IWebHostEnvironment hostingEnvironment)
        {
            _userDocumentRepository = userDocumentRepository;
            _hostingEnvironment = hostingEnvironment;
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

                foreach (var document in userDocuments)
                {
                    document.DocumentPath = $"{Request.Scheme}://{Request.Host.Value}/{document.DocumentPath}";
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
        public async Task<IActionResult> AddUserDocument([FromForm] UserDocumentRequest userDocumentRequest)
        {
            try
            {
                string extension = Path.GetExtension(userDocumentRequest.Document.FileName);

                if (extension != Constants.ALLOWED_EXTENSION)
                {
                    return BadRequest(new { ErrorMessage = ErrorMessages.ONLY_PDF_EXTENSION_ALLOWED });
                }

                userDocumentRequest.DocumentName = $"{Guid.NewGuid()}{extension}";

                string directory = Path.Combine(_hostingEnvironment.WebRootPath, Constants.DOCUMENT_PATH);
                string path = Path.Combine(directory, userDocumentRequest.DocumentName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    userDocumentRequest.Document.CopyTo(stream);
                }

                userDocumentRequest.DocumentPath = Path.Combine(Constants.DOCUMENT_PATH, userDocumentRequest.DocumentName);

                int result = await _userDocumentRepository.Add(userDocumentRequest);
                if (result == 0)
                {
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status201Created);
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
        [Route("{documentId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserDocument(int documentId)
        {
            try
            {
                int result = await _userDocumentRepository.Delete(documentId);
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
