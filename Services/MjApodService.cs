﻿using mjapi_conexion.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mjapi_conexion.Services
{
    public class MjApodService
    {
        public async Task<MjApod> GetImage(DateTime dt)
        {
            MjApod dto = null;
            HttpResponseMessage response;
            string requestUrl = $"https://api.nasa.gov/planetary/apod?date={dt.ToString("yyyy-MMdd")}&api_key={{\"copyright\":\"\\nMartin Pugh &  \\nRocco Sung\\n\",\"date\":\"2024-06-25\",\"explanation\":\"What is that strange brown ribbon on the sky?  When observing the star cluster NGC 4372, observers frequently take note of an unusual dark streak nearby running about three degrees in length. The streak, actually a long molecular cloud, has become known as the Dark Doodad Nebula.  (Doodad is slang for a thingy or a whatchamacallit.)  Pictured here, the Dark Doodad Nebula sweeps across the center of a rich and colorful starfield.  Its dark color comes from a high concentration of interstellar dust that preferentially scatters visible light.  The globular star cluster NGC 4372 is visible as the fuzzy white spot on the far left, while the bright blue star gamma Muscae is seen to the cluster's upper right. The Dark Doodad Nebula can be found with strong binoculars toward the southern constellation of the Fly (Musca).\",\"hdurl\":\"https://apod.nasa.gov/apod/image/2406/Doodad_PughSung_9193.jpg\",\"media_type\":\"image\",\"service_version\":\"v1\",\"title\":\"The Dark Doodad Nebula\",\"url\":\"https://apod.nasa.gov/apod/image/2406/Doodad_PughSung_1080.jpg\"}}";
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                HttpClient client = new HttpClient();
                response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dto = JsonConvert.DeserializeObject<MjApod>(json);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return dto;
        }
    }
}
