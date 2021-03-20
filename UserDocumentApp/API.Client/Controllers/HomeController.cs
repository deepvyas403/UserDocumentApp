using API.Core.Constants;
using API.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace API.Client.Controllers
{
    public class HomeController : Controller
    {
        ILogger<HomeController> _logger;
        IConfiguration _configuration;
        string apiBaseUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            apiBaseUrl = _configuration.GetValue<string>("WebAPIEndPoint");
        }

        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To render Index view with User Document Form and Grid with details
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userDocuments = new List<UserDocumentViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        userDocuments = JsonConvert.DeserializeObject<List<UserDocumentViewModel>>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return View(userDocuments);
        }


        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To save User Document details
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Index(UserDocumentRequest userDocument)
        {
            if (userDocument.Document == null)
            {
                ViewBag.Error = ErrorMessages.DOCUMENT_REQUIRED;
                return View("Index");
            }

            using (var memoryStream = new MemoryStream())
            {
                //Get the file steam from the multiform data uploaded from the browser
                await userDocument.Document.CopyToAsync(memoryStream);

                //Build an multipart/form-data request to upload the file to Web API
                using var form = new MultipartFormDataContent();
                using var fileContent = new ByteArrayContent(memoryStream.ToArray());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, "Document", userDocument.Document.FileName);
                var userName = new StringContent(userDocument.UserName);
                form.Add(userName, "UserName");

                var client = new HttpClient();
                var response = await client.PostAsync(apiBaseUrl, form);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To delete document (Soft Delete)
        /// </summary>
        public async Task<IActionResult> Delete(int documentId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"{apiBaseUrl}/{documentId}"))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }

            return RedirectToAction("Index");
        }


        #region - Common -

        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To redirect to error page
        /// </summary>
        [Route("500")]
        public IActionResult Error()
        {
            return View();
        }

        #endregion

    }
}