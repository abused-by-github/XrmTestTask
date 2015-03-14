using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DomainModel;
using Newtonsoft.Json;
using XrmTestTask.E1Client.E1Api;
using XrmTestTask.E1ClientApi;

namespace XrmTestTask.E1Client
{
    public class ResumeClient : IResumeClient
    {
        public List<Resume> Grab()
        {
            string json;
            using (var client = new WebClient())
            {
                json = client.DownloadString("http://rabota.e1.ru/api/v1/resumes/?limit=10&offset=0");
            }
            var data = JsonConvert.DeserializeObject<E1Response>(json);
            var result = data.resumes.Select(r => new Resume
            {
                Header = r.header,
                DateAdded = r.add_date,
                Url = r.url
            }).ToList();
            return result;
        }
    }
}
